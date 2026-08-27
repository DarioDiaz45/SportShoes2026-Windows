using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.Common;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Size;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;
using System.ComponentModel;

namespace SportShoes2026.Windows
{
    public partial class frmSize : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SizeListDto>? _listSizes;
        private bool? filtroActivo = null;
        private int _paginaActual = 1;
        private int _totalRegistros = 0;
        private int _totalPaginas = 0;
        private int _cantidadPorPagina = 10;

        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private BindingSource _bindingSource = new BindingSource();
        public frmSize(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSize_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeServicio = scope.ServiceProvider
                    .GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = sizeServicio
                        .ObtenerPagina(_paginaActual, _cantidadPorPagina,
                        campoOrdenar, esAscendente, filtroActivo);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    MostrarDatosEnGrilla(resultadoConsulta.Value!);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosEnGrilla(PaginationResultDto<SizeListDto> resultado)
        {
            if (resultado.Items is null ||
                resultado.Items.Count == 0) return;

            _totalPaginas = resultado.TotalPaginas;
            _totalRegistros = resultado.CantidadRegistros;

            _bindingSource.DataSource = resultado.Items;
            dgvDatos.DataSource = _bindingSource;

            int desde = 1 + (_paginaActual - 1) * _cantidadPorPagina;
            int hasta = desde + _cantidadPorPagina - 1;
            if (hasta > _totalRegistros)
            {
                hasta = _totalRegistros;
            }
            lblCantidad.Text = $"Del {desde} a {hasta} de {_totalRegistros}";
            lblCantidadPaginas.Text = $"{_paginaActual} de {_totalPaginas}";

            btnPrimero.Enabled = resultado.TieneRegistrosAnteriores;
            btnAnterior.Enabled = resultado.TieneRegistrosAnteriores;
            btnSiguiente.Enabled = resultado.TieneRegistrosSiguientes;
            btnUltimo.Enabled = resultado.TieneRegistrosSiguientes;
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            _paginaActual = 1;
            tsbFilter.BackColor = Color.Orange;
            RecargarGrilla();
        }

        private void ManejarControles(bool v)
        {
            filtroActivo = v;
            tsbFilter.BackColor = v ? Color.Orange : SystemColors.Control;
            tsbEdit.Enabled = !v;
        }

        private void noActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            _paginaActual = 1;
            tsbFilter.BackColor = Color.Orange;
            RecargarGrilla();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            _paginaActual = 1;
            tsbFilter.BackColor = SystemColors.Control;
            RecargarGrilla();
        }



        private void tsbNew_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmSizeAe frm = scope.ServiceProvider.GetRequiredService<frmSizeAe>())
                {
                    frm.Text = "New Size";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var tipoServicio = scope.ServiceProvider
                                .GetRequiredService<ISizeService>();
                            var resultado = tipoServicio.ObtenerPaginaRegistro(nuevoId, _cantidadPorPagina);
                            if (resultado.IsFailure)
                            {
                                ErrorHelper.MostrarErrores(resultado.Errors);
                                return;
                            }
                            _paginaActual = resultado.Value;
                        }
                        RecargarGrilla();
                        if (sePuedeVer)
                        {
                            var nuevoTipo = _bindingSource.List
                                .Cast<SizeListDto>()
                                .FirstOrDefault(tp => tp.SizeId == nuevoId);
                            if (nuevoTipo is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(nuevoTipo);

                        }
                        else
                        {
                            MessageBox.Show("Los registros agregados no se pueden mostrar\npor condición de filtro o búsqueda",
                                "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sizeListDto = (SizeListDto)_bindingSource.Current;
            var seleccionadoId = sizeListDto.SizeId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var sizeServicio = scope.ServiceProvider
                .GetRequiredService<ISizeService>();
                    var resultadoConsulta = sizeServicio
                        .GetForUpdate(sizeListDto.SizeId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var sizeUpdateDto = resultadoConsulta.Value;
                    using (frmSizeAe frm = scope.ServiceProvider
                        .GetRequiredService<frmSizeAe>())
                    {
                        frm.Text = "Editar Talla";
                        frm.SetSize(sizeUpdateDto);
                        frm.ShowDialog();
                        var sizeEditado = frm.GetSize();
                        if (sizeEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == sizeEditado.IsActive;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = sizeServicio
                                .ObtenerPaginaRegistro(seleccionadoId, _cantidadPorPagina,
                                filtroActivo);
                            if (resultadoConsulta.IsFailure)
                            {
                                ErrorHelper.MostrarErrores(resultadoPagina.Errors);
                                return;
                            }
                            _paginaActual = resultadoPagina.Value;
                        }

                        if (frm.ConcurrencyConflict)
                        {
                            RecargarGrilla();
                        }
                        if (frm.DataChanged)
                        {
                            RecargarGrilla();
                        }
                        if (sePuedeVer)
                        {
                            var registroEditado = _bindingSource.List
                                .Cast<SizeListDto>()
                                .FirstOrDefault(b => b.SizeId == seleccionadoId);
                            if (registroEditado is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(registroEditado);

                        }
                        else
                        {
                            MessageBox.Show("El registro editado no se puede mostrar\npor condición de filtro o búsqueda",
                                "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbDelete_Click_1(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SizeListDto sizeSeleccionado = (SizeListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider.GetRequiredService<ISizeService>();
                var resultadoConsulta = sizeService.GetForDelete(sizeSeleccionado.SizeId);
                if (resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tipoDeleteDto = resultadoConsulta.Value;
                var dr = (MessageBox.Show($"Are you sure you want to delete size {sizeSeleccionado.Number}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dr == DialogResult.No)
                {
                    return;
                }


                try
                {
                    var resultadoEliminacion = sizeService.Delete(tipoDeleteDto!);
                    if (resultadoEliminacion.IsConcurrencyConflict)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (resultadoEliminacion.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("The sport was successfully eliminated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _paginaActual = 1;
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _paginaActual--;
            if (_paginaActual == 0)
            {
                _paginaActual = 1;
            }
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _paginaActual++;
            if (_paginaActual > _totalPaginas)
            {
                _paginaActual = _totalPaginas;
            }
            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _paginaActual = _totalPaginas;
            RecargarGrilla();
        }
    }
}
