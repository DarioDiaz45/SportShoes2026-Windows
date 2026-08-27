using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Size;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;
using System.ComponentModel;

namespace SportShoes2026.Windows
{
    public partial class frmSize : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SizeListDto>? _listSizes;
        private bool filtroActivo = false;
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
                var Sizeservice = scope.ServiceProvider.GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = Sizeservice.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSizes = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSizes);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosEnGrillas(List<SizeListDto>? listSizes)
        {
            
            if (listSizes is null || listSizes.Count == 0)
            {
                return;
            }
            var bindingList = new BindingList<SizeListDto>(listSizes);
            _bindingSource.DataSource = bindingList;
            dgvDatos.DataSource = _bindingSource;
            lblCantidad.Text = listSizes.Count.ToString();
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Sizeservice = scope.ServiceProvider.GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = Sizeservice.FilterByAsset(true);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSizes = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSizes);
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
            tsbEdit.Enabled = !v;
        }

        private void noActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Sizeservice = scope.ServiceProvider.GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = Sizeservice.FilterByAsset(false);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSizes = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSizes);
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
                        RecargarGrilla();
                    }

                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("You must select a row from the grid.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SizeListDto sizeListDto = (SizeListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var SizeServicio = scope.ServiceProvider
                     .GetRequiredService<ISizeService>();
                    var resultadoConsulta = SizeServicio
                        .GetForUpdate(sizeListDto.SizeId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var sizeEditDto = resultadoConsulta.Value;
                    using (frmSizeAe frm = scope.ServiceProvider.GetRequiredService<frmSizeAe>())
                    {
                        frm.Text = "Editar Tipo de Bombón";
                        frm.SetTipo(sizeEditDto);
                        frm.ShowDialog();
                        if (frm.ConcurrencyConflict)
                        {
                            RecargarGrilla();
                        }
                        if (frm.DataChanged)
                        {
                            RecargarGrilla();
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
    }
}
