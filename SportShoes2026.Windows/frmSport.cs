using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmSport : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SportListDto>? _listSports;
        private bool filtroActivo = false;
        public frmSport(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSport_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Sportservice = scope.ServiceProvider.GetRequiredService<ISportService>();
                try
                {
                    var resultadoConsulta = Sportservice.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSports);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void MostrarDatosEnGrillas(List<SportListDto>? listSports)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listSports is null || listSports.Count == 0)
            {
                return;
            }
            foreach (var item in listSports)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidad.Text = listSports.Count.ToString();
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var Sportservice = scope.ServiceProvider.GetRequiredService<ISportService>();
                try
                {
                    var resultadoConsulta = Sportservice.FilterByAsset(true);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSports);
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
                var Sportservice = scope.ServiceProvider.GetRequiredService<ISportService>();
                try
                {
                    var resultadoConsulta = Sportservice.FilterByAsset(false);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSports);
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

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if(dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            if(filaSeleccionada.Tag is null)
            {
                return;
            }
            SportListDto sportSeleccionado = (SportListDto)filaSeleccionada.Tag;
            using (var scope=_serviceProvider.CreateScope())
            {   var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                var resultadoConsulta=sportService.GetForDelete(sportSeleccionado.SportId);
                if(resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tipoDeleteDto = resultadoConsulta.Value;
                var dr=(MessageBox.Show($"¿Está seguro que desea eliminar el deporte {sportSeleccionado.SportName}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if(dr == DialogResult.No)
                {
                    return;
                }
           
                
                try
                {
                    var resultadoEliminacion = sportService.Delete(tipoDeleteDto!);
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
