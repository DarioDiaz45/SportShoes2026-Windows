using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Size;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmSize : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SizeListDto>? _listSizes;
        private bool filtroActivo = false;
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
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listSizes is null || listSizes.Count == 0)
            {
                return;
            }
            foreach (var item in listSizes)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
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

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
