using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Windows.Classes;

namespace SportShoes2026.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShoes_Click(object sender, EventArgs e)
        {

        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmSport>())
            {
                frm.Text = "Sports List";
                frm.ShowDialog();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"{Session.UsuarioActual!.UserName}";
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmSize>())
            {
                frm.Text = "Sizes List";
                frm.ShowDialog();
            }
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmBrand>())
            {
                frm.Text = "Brands  List";
                frm.ShowDialog();
            }
        }
    }
}
