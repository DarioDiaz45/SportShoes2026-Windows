using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmBrand : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<BrandListDto>? _listSports;
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
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrillas(_listSports);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void MostrarDatosEnGrillas(List<BrandListDto>? listSports)
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
    }
}
