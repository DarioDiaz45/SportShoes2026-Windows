namespace SportShoes2026.Windows
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnLogin = new Button();
            btnSalir = new Button();
            lblUser = new Label();
            lblPassword = new Label();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(81, 165);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(91, 67);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(305, 165);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 67);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(81, 41);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(33, 15);
            lblUser.TabIndex = 2;
            lblUser.Text = "User:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(54, 92);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(120, 38);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(241, 23);
            txtUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 89);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(241, 23);
            txtPassword.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 268);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(lblPassword);
            Controls.Add(lblUser);
            Controls.Add(btnSalir);
            Controls.Add(btnLogin);
            Name = "frmLogin";
            Text = "frmLogin";
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnSalir;
        private Label lblUser;
        private Label lblPassword;
        private TextBox txtUser;
        private TextBox txtPassword;
        private ErrorProvider errorProvider1;
    }
}