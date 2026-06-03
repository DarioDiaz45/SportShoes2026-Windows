namespace SportShoes2026.Windows
{
    partial class frmPrincipal
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
            pnlPrincipal = new Panel();
            pnlMensaje = new Panel();
            label2 = new Label();
            label1 = new Label();
            pnlOpciones = new Panel();
            btnBrand = new Button();
            btnSport = new Button();
            btnSize = new Button();
            btnShoes = new Button();
            pnlUsuario = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblUsuario = new ToolStripStatusLabel();
            pnlShoes2026 = new Panel();
            btnLogout = new Button();
            lblFechaTime = new Label();
            lblFecha = new Label();
            lblShoes2026 = new Label();
            pnlPrincipal.SuspendLayout();
            pnlMensaje.SuspendLayout();
            pnlOpciones.SuspendLayout();
            pnlUsuario.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlShoes2026.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.Controls.Add(pnlMensaje);
            pnlPrincipal.Controls.Add(pnlOpciones);
            pnlPrincipal.Controls.Add(pnlUsuario);
            pnlPrincipal.Controls.Add(pnlShoes2026);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(893, 517);
            pnlPrincipal.TabIndex = 0;
            // 
            // pnlMensaje
            // 
            pnlMensaje.Controls.Add(label2);
            pnlMensaje.Controls.Add(label1);
            pnlMensaje.Dock = DockStyle.Fill;
            pnlMensaje.Location = new Point(200, 65);
            pnlMensaje.Name = "pnlMensaje";
            pnlMensaje.Size = new Size(693, 430);
            pnlMensaje.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 141);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 1;
            label2.Text = "Shoe Management System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 161);
            label1.Name = "label1";
            label1.Size = new Size(225, 15);
            label1.TabIndex = 0;
            label1.Text = "Select an option from the menu to begin.";
            // 
            // pnlOpciones
            // 
            pnlOpciones.Controls.Add(btnBrand);
            pnlOpciones.Controls.Add(btnSport);
            pnlOpciones.Controls.Add(btnSize);
            pnlOpciones.Controls.Add(btnShoes);
            pnlOpciones.Dock = DockStyle.Left;
            pnlOpciones.Location = new Point(0, 65);
            pnlOpciones.Name = "pnlOpciones";
            pnlOpciones.Size = new Size(200, 430);
            pnlOpciones.TabIndex = 2;
            // 
            // btnBrand
            // 
            btnBrand.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrand.Location = new Point(25, 209);
            btnBrand.Name = "btnBrand";
            btnBrand.Size = new Size(147, 33);
            btnBrand.TabIndex = 0;
            btnBrand.Text = "Brand";
            btnBrand.UseVisualStyleBackColor = true;
            // 
            // btnSport
            // 
            btnSport.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSport.Location = new Point(25, 151);
            btnSport.Name = "btnSport";
            btnSport.Size = new Size(147, 33);
            btnSport.TabIndex = 0;
            btnSport.Text = "Sport";
            btnSport.UseVisualStyleBackColor = true;
            btnSport.Click += btnSport_Click;
            // 
            // btnSize
            // 
            btnSize.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSize.Location = new Point(25, 93);
            btnSize.Name = "btnSize";
            btnSize.Size = new Size(147, 33);
            btnSize.TabIndex = 1;
            btnSize.Text = "Size";
            btnSize.UseVisualStyleBackColor = true;
            btnSize.Click += btnSize_Click;
            // 
            // btnShoes
            // 
            btnShoes.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShoes.Location = new Point(25, 38);
            btnShoes.Name = "btnShoes";
            btnShoes.Size = new Size(147, 33);
            btnShoes.TabIndex = 0;
            btnShoes.Text = "Shoes";
            btnShoes.UseVisualStyleBackColor = true;
            btnShoes.Click += btnShoes_Click;
            // 
            // pnlUsuario
            // 
            pnlUsuario.Controls.Add(statusStrip1);
            pnlUsuario.Dock = DockStyle.Bottom;
            pnlUsuario.Location = new Point(0, 495);
            pnlUsuario.Name = "pnlUsuario";
            pnlUsuario.Size = new Size(893, 22);
            pnlUsuario.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblUsuario });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(893, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(33, 17);
            toolStripStatusLabel1.Text = "User:";
            // 
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(71, 17);
            lblUsuario.Text = "User Conect";
            // 
            // pnlShoes2026
            // 
            pnlShoes2026.Controls.Add(btnLogout);
            pnlShoes2026.Controls.Add(lblFechaTime);
            pnlShoes2026.Controls.Add(lblFecha);
            pnlShoes2026.Controls.Add(lblShoes2026);
            pnlShoes2026.Dock = DockStyle.Top;
            pnlShoes2026.Location = new Point(0, 0);
            pnlShoes2026.Name = "pnlShoes2026";
            pnlShoes2026.Size = new Size(893, 65);
            pnlShoes2026.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(753, 23);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 31);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblFechaTime
            // 
            lblFechaTime.AutoSize = true;
            lblFechaTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaTime.Location = new Point(515, 31);
            lblFechaTime.Name = "lblFechaTime";
            lblFechaTime.Size = new Size(73, 15);
            lblFechaTime.TabIndex = 2;
            lblFechaTime.Text = "02/06/2026";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(477, 31);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // lblShoes2026
            // 
            lblShoes2026.AutoSize = true;
            lblShoes2026.Font = new Font("Arial Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShoes2026.Location = new Point(25, 19);
            lblShoes2026.Name = "lblShoes2026";
            lblShoes2026.Size = new Size(157, 30);
            lblShoes2026.TabIndex = 0;
            lblShoes2026.Text = "SHOES 2026";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 517);
            Controls.Add(pnlPrincipal);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            pnlPrincipal.ResumeLayout(false);
            pnlMensaje.ResumeLayout(false);
            pnlMensaje.PerformLayout();
            pnlOpciones.ResumeLayout(false);
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlShoes2026.ResumeLayout(false);
            pnlShoes2026.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private Panel pnlShoes2026;
        private Panel pnlMensaje;
        private Panel pnlOpciones;
        private Panel pnlUsuario;
        private Label lblFechaTime;
        private Label lblFecha;
        private Label lblShoes2026;
        private Button btnSize;
        private Button btnShoes;
        private Button btnLogout;
        private Button btnBrand;
        private Button btnSport;
        private Label label2;
        private Label label1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblUsuario;
    }
}