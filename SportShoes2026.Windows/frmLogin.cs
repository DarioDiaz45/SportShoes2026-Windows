using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Entities;
using SportShoes2026.Windows.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportShoes2026.Windows
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider _provider;
        public frmLogin(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                User? usuario = SystemUser.Users
                    .FirstOrDefault(u => u.UserName == txtUser.Text &&
                        u.Password == txtPassword.Text);
                if (usuario is null)
                {
                    MessageBox.Show("Usuario inexistente o datos no válidos", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.SelectAll();
                    txtUser.Select();
                    return;
                }
                Session.UsuarioActual = usuario;
                this.Hide();
                frmPrincipal frm = _provider.GetRequiredService<frmPrincipal>();
                frm.ShowDialog();
                InicializarControles();
                this.Show();
            }
        }
        private void InicializarControles()
        {
            txtPassword.Clear();
            txtUser.Clear();
            txtUser.Select();
        }

        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                valido = false;
                errorProvider1.SetError(txtUser, "The user is required");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPassword, "The password is required");
            }
            return valido;
        }
    }
}
