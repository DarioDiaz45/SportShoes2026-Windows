namespace SportShoes2026.Windows
{
    partial class frmSizeAe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSizeAe));
            lblNumber = new Label();
            chkActiveSize = new CheckBox();
            btnOK = new Button();
            btnCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            nudNumberSize = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberSize).BeginInit();
            SuspendLayout();
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(38, 25);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(54, 15);
            lblNumber.TabIndex = 0;
            lblNumber.Text = "Number:";
            // 
            // chkActiveSize
            // 
            chkActiveSize.AutoSize = true;
            chkActiveSize.Location = new Point(38, 73);
            chkActiveSize.Name = "chkActiveSize";
            chkActiveSize.Size = new Size(64, 19);
            chkActiveSize.TabIndex = 2;
            chkActiveSize.Text = "Active?";
            chkActiveSize.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Image = (Image)resources.GetObject("btnOK.Image");
            btnOK.Location = new Point(38, 163);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 55);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(203, 163);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 55);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // nudNumberSize
            // 
            nudNumberSize.Location = new Point(98, 23);
            nudNumberSize.Name = "nudNumberSize";
            nudNumberSize.Size = new Size(97, 23);
            nudNumberSize.TabIndex = 5;
            // 
            // frmSizeAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 251);
            Controls.Add(nudNumberSize);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(chkActiveSize);
            Controls.Add(lblNumber);
            Name = "frmSizeAe";
            Text = "frmSizeAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumber;
        private CheckBox chkActiveSize;
        private Button btnOK;
        private Button btnCancel;
        private ErrorProvider errorProvider1;
        private NumericUpDown nudNumberSize;
    }
}