namespace SportShoes2026.Windows
{
    partial class frmBrandAe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandAe));
            lblName = new Label();
            chkActive = new CheckBox();
            txtNameBrand = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(37, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Location = new Point(37, 75);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(64, 19);
            chkActive.TabIndex = 1;
            chkActive.Text = "Active?";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // txtNameBrand
            // 
            txtNameBrand.Location = new Point(85, 30);
            txtNameBrand.Name = "txtNameBrand";
            txtNameBrand.Size = new Size(388, 23);
            txtNameBrand.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.Image = (Image)resources.GetObject("btnOK.Image");
            btnOK.Location = new Point(64, 142);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(82, 65);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(357, 142);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 65);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmBrandAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 230);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtNameBrand);
            Controls.Add(chkActive);
            Controls.Add(lblName);
            Name = "frmBrandAe";
            Text = "frmBrandAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private CheckBox chkActive;
        private TextBox txtNameBrand;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}