namespace SportShoes2026.Windows
{
    partial class frmSportAe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSportAe));
            lblNameSport = new Label();
            chkActiveSport = new CheckBox();
            txtSportName = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblNameSport
            // 
            lblNameSport.AutoSize = true;
            lblNameSport.Location = new Point(31, 31);
            lblNameSport.Name = "lblNameSport";
            lblNameSport.Size = new Size(42, 15);
            lblNameSport.TabIndex = 0;
            lblNameSport.Text = "Name:";
            // 
            // chkActiveSport
            // 
            chkActiveSport.AutoSize = true;
            chkActiveSport.Location = new Point(31, 81);
            chkActiveSport.Name = "chkActiveSport";
            chkActiveSport.Size = new Size(64, 19);
            chkActiveSport.TabIndex = 1;
            chkActiveSport.Text = "Active?";
            chkActiveSport.UseVisualStyleBackColor = true;
            // 
            // txtSportName
            // 
            txtSportName.Location = new Point(79, 28);
            txtSportName.Name = "txtSportName";
            txtSportName.Size = new Size(411, 23);
            txtSportName.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ControlDark;
            btnOK.Image = (Image)resources.GetObject("btnOK.Image");
            btnOK.Location = new Point(55, 162);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 66);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(363, 162);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 66);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancel";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSportAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(519, 259);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtSportName);
            Controls.Add(chkActiveSport);
            Controls.Add(lblNameSport);
            Name = "frmSportAe";
            Text = "frmSportAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNameSport;
        private CheckBox chkActiveSport;
        private TextBox txtSportName;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}