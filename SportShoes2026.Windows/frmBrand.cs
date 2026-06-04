using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmBrand : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<BrandListDto>? _listBrands;
        private bool filtroActivo = false;
        public frmBrand(IServiceProvider serviceprovider)
        {
            InitializeComponent();
            _serviceProvider = serviceprovider;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Brandservice = scope.ServiceProvider.GetRequiredService<IBrandService>();
                try
                {
                    var resultadoConsulta = Brandservice.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listBrands = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listBrands);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void MostrarDatosEnGrillas(List<BrandListDto>? listBrands)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listBrands is null || listBrands.Count == 0)
            {
                return;
            }
            foreach (var item in listBrands)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidad.Text = listBrands.Count.ToString();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            if (filaSeleccionada.Tag is null)
            {
                return;
            }
            BrandListDto brandSeleccionado = (BrandListDto)filaSeleccionada.Tag;
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                var resultadoConsulta = brandService.GetForDelete(brandSeleccionado.BrandId);
                if (resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tipoDeleteDto = resultadoConsulta.Value;
                var dr = (MessageBox.Show($"¿Está seguro que desea eliminar la marca {brandSeleccionado.BrandName}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dr == DialogResult.No)
                {
                    return;
                }


                try
                {
                    var resultadoEliminacion = brandService.Delete(tipoDeleteDto!);
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

                    MessageBox.Show("The brand was successfully eliminated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Brandservice = scope.ServiceProvider.GetRequiredService<IBrandService>();
                try
                {
                    var resultadoConsulta = Brandservice.FilterByAsset(true);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listBrands = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listBrands);
                    ManejarControles(true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ManejarControles(bool v)
        {
            filtroActivo = v;
            tsbFilter.BackColor = v ? Color.Orange : SystemColors.Control;

            tsbNew.Enabled = !v;
            tsbDelete.Enabled = !v;
            tsbEdit.Enabled = !v;
        }

        private void noActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Brandservice = scope.ServiceProvider.GetRequiredService<IBrandService>();
                try
                {
                    var resultadoConsulta = Brandservice.FilterByAsset(false);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listBrands = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listBrands);
                    ManejarControles(true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            ManejarControles(false);
        }
    }
}
