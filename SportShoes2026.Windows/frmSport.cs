using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;
using System.ComponentModel;

namespace SportShoes2026.Windows
{
    public partial class frmSport : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SportListDto>? _listSports;
        private bool filtroActivo = false;

        private BindingSource _bindingSource = new BindingSource();
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
           
            if (listSports is null || listSports.Count == 0)
            {
                return;
            }
            
            var bindingList=new BindingList<SportListDto>(listSports);
            _bindingSource.DataSource = bindingList;
            dgvDatos.DataSource = _bindingSource;
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
            if (_bindingSource.Current==null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SportListDto sportSeleccionado = (SportListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                var resultadoConsulta = sportService.GetForDelete(sportSeleccionado.SportId);
                if (resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tipoDeleteDto = resultadoConsulta.Value;
                var dr = (MessageBox.Show($"¿Está seguro que desea eliminar el deporte {sportSeleccionado.SportName}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dr == DialogResult.No)
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

        private void tsbNew_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmSportAe frm = scope.ServiceProvider.GetRequiredService<frmSportAe>())
                {
                    frm.Text = "New Sport";
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
                MessageBox.Show("Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SportListDto sportListDto = (SportListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var SportServicio = scope.ServiceProvider
                     .GetRequiredService<ISportService>();
                    var resultadoConsulta = SportServicio
                        .GetForUpdate(sportListDto.SportId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var sportEditDto = resultadoConsulta.Value;
                    using (frmSportAe frm = scope.ServiceProvider
                        .GetRequiredService<frmSportAe>())
                    {
                        frm.Text = "Editar Tipo de Bombón";
                        frm.SetTipo(sportEditDto);
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
    }
}
