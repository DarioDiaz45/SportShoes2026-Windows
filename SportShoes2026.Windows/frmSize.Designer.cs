namespace SportShoes2026.Windows
{
    partial class frmSize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSize));
            pnlCrud = new Panel();
            toolStrip1 = new ToolStrip();
            tsbNew = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            tsbEdit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFilter = new ToolStripDropDownButton();
            activeToolStripMenuItem = new ToolStripMenuItem();
            noActiveToolStripMenuItem = new ToolStripMenuItem();
            tsbUpdate = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbClose = new ToolStripButton();
            pnlCantidad = new Panel();
            lblCantidad = new Label();
            label1 = new Label();
            dgvDatos = new DataGridView();
            colIdSize = new DataGridViewTextBoxColumn();
            colNumber = new DataGridViewTextBoxColumn();
            colActive = new DataGridViewCheckBoxColumn();
            pnlCrud.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnlCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // pnlCrud
            // 
            pnlCrud.Controls.Add(toolStrip1);
            pnlCrud.Dock = DockStyle.Top;
            pnlCrud.Location = new Point(0, 0);
            pnlCrud.Name = "pnlCrud";
            pnlCrud.Size = new Size(800, 77);
            pnlCrud.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNew, tsbDelete, tsbEdit, toolStripSeparator1, tsbFilter, tsbUpdate, toolStripSeparator2, tsbClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 70);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            tsbNew.Image = (Image)resources.GetObject("tsbNew.Image");
            tsbNew.ImageScaling = ToolStripItemImageScaling.None;
            tsbNew.ImageTransparentColor = Color.Magenta;
            tsbNew.Name = "tsbNew";
            tsbNew.Size = new Size(52, 67);
            tsbNew.Text = "New";
            tsbNew.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsbDelete
            // 
            tsbDelete.Image = (Image)resources.GetObject("tsbDelete.Image");
            tsbDelete.ImageScaling = ToolStripItemImageScaling.None;
            tsbDelete.ImageTransparentColor = Color.Magenta;
            tsbDelete.Name = "tsbDelete";
            tsbDelete.Size = new Size(52, 67);
            tsbDelete.Text = "Delete";
            tsbDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDelete.Click += tsbDelete_Click;
            // 
            // tsbEdit
            // 
            tsbEdit.Image = (Image)resources.GetObject("tsbEdit.Image");
            tsbEdit.ImageScaling = ToolStripItemImageScaling.None;
            tsbEdit.ImageTransparentColor = Color.Magenta;
            tsbEdit.Name = "tsbEdit";
            tsbEdit.Size = new Size(52, 67);
            tsbEdit.Text = "Edit";
            tsbEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
            // 
            // tsbFilter
            // 
            tsbFilter.DropDownItems.AddRange(new ToolStripItem[] { activeToolStripMenuItem, noActiveToolStripMenuItem });
            tsbFilter.Image = (Image)resources.GetObject("tsbFilter.Image");
            tsbFilter.ImageScaling = ToolStripItemImageScaling.None;
            tsbFilter.ImageTransparentColor = Color.Magenta;
            tsbFilter.Name = "tsbFilter";
            tsbFilter.Size = new Size(61, 67);
            tsbFilter.Text = "Filter";
            tsbFilter.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // activeToolStripMenuItem
            // 
            activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            activeToolStripMenuItem.Size = new Size(123, 22);
            activeToolStripMenuItem.Text = "Active";
            activeToolStripMenuItem.Click += activeToolStripMenuItem_Click;
            // 
            // noActiveToolStripMenuItem
            // 
            noActiveToolStripMenuItem.Name = "noActiveToolStripMenuItem";
            noActiveToolStripMenuItem.Size = new Size(123, 22);
            noActiveToolStripMenuItem.Text = "NoActive";
            noActiveToolStripMenuItem.Click += noActiveToolStripMenuItem_Click;
            // 
            // tsbUpdate
            // 
            tsbUpdate.Image = (Image)resources.GetObject("tsbUpdate.Image");
            tsbUpdate.ImageScaling = ToolStripItemImageScaling.None;
            tsbUpdate.ImageTransparentColor = Color.Magenta;
            tsbUpdate.Name = "tsbUpdate";
            tsbUpdate.Size = new Size(52, 67);
            tsbUpdate.Text = "Update";
            tsbUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbUpdate.Click += tsbUpdate_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 70);
            // 
            // tsbClose
            // 
            tsbClose.Image = (Image)resources.GetObject("tsbClose.Image");
            tsbClose.ImageScaling = ToolStripItemImageScaling.None;
            tsbClose.ImageTransparentColor = Color.Magenta;
            tsbClose.Name = "tsbClose";
            tsbClose.Size = new Size(52, 67);
            tsbClose.Text = "Close";
            tsbClose.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbClose.Click += tsbClose_Click;
            // 
            // pnlCantidad
            // 
            pnlCantidad.Controls.Add(lblCantidad);
            pnlCantidad.Controls.Add(label1);
            pnlCantidad.Dock = DockStyle.Bottom;
            pnlCantidad.Location = new Point(0, 424);
            pnlCantidad.Name = "pnlCantidad";
            pnlCantidad.Size = new Size(800, 36);
            pnlCantidad.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(73, 12);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad:";
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colIdSize, colNumber, colActive });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 77);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(800, 347);
            dgvDatos.TabIndex = 2;
            // 
            // colIdSize
            // 
            colIdSize.HeaderText = "Id";
            colIdSize.Name = "colIdSize";
            colIdSize.Visible = false;
            // 
            // colNumber
            // 
            colNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNumber.HeaderText = "Number";
            colNumber.Name = "colNumber";
            // 
            // colActive
            // 
            colActive.HeaderText = "Active";
            colActive.Name = "colActive";
            // 
            // frmSize
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(dgvDatos);
            Controls.Add(pnlCantidad);
            Controls.Add(pnlCrud);
            Name = "frmSize";
            Text = "frmSize";
            Load += frmSize_Load;
            pnlCrud.ResumeLayout(false);
            pnlCrud.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlCantidad.ResumeLayout(false);
            pnlCantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCrud;
        private Panel pnlCantidad;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNew;
        private ToolStripButton tsbDelete;
        private ToolStripButton tsbEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbUpdate;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbClose;
        private Label lblCantidad;
        private Label label1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colIdSize;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewCheckBoxColumn colActive;
        private ToolStripDropDownButton tsbFilter;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem noActiveToolStripMenuItem;
    }
}