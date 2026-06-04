namespace SportShoes2026.Windows
{
    partial class frmBrand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrand));
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
            pnlGrid = new Panel();
            dgvDatos = new DataGridView();
            colBrandId = new DataGridViewTextBoxColumn();
            ColBrandName = new DataGridViewTextBoxColumn();
            colActive = new DataGridViewCheckBoxColumn();
            pnlCrud.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnlCantidad.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // pnlCrud
            // 
            pnlCrud.Controls.Add(toolStrip1);
            pnlCrud.Dock = DockStyle.Top;
            pnlCrud.Location = new Point(0, 0);
            pnlCrud.Name = "pnlCrud";
            pnlCrud.Size = new Size(799, 71);
            pnlCrud.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNew, tsbDelete, tsbEdit, toolStripSeparator1, tsbFilter, tsbUpdate, toolStripSeparator2, tsbClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(799, 70);
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
            activeToolStripMenuItem.Size = new Size(180, 22);
            activeToolStripMenuItem.Text = "Active";
            activeToolStripMenuItem.Click += activeToolStripMenuItem_Click;
            // 
            // noActiveToolStripMenuItem
            // 
            noActiveToolStripMenuItem.Name = "noActiveToolStripMenuItem";
            noActiveToolStripMenuItem.Size = new Size(180, 22);
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
            pnlCantidad.Location = new Point(0, 400);
            pnlCantidad.Name = "pnlCantidad";
            pnlCantidad.Size = new Size(799, 50);
            pnlCantidad.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(76, 16);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad:";
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvDatos);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 71);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(799, 329);
            pnlGrid.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colBrandId, ColBrandName, colActive });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(799, 329);
            dgvDatos.TabIndex = 0;
            // 
            // colBrandId
            // 
            colBrandId.HeaderText = "Id";
            colBrandId.Name = "colBrandId";
            colBrandId.Visible = false;
            // 
            // ColBrandName
            // 
            ColBrandName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColBrandName.HeaderText = "Name";
            ColBrandName.Name = "ColBrandName";
            // 
            // colActive
            // 
            colActive.HeaderText = "Active";
            colActive.Name = "colActive";
            // 
            // frmBrand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 450);
            Controls.Add(pnlGrid);
            Controls.Add(pnlCantidad);
            Controls.Add(pnlCrud);
            Name = "frmBrand";
            Text = "frmBrand";
            Load += frmBrand_Load;
            pnlCrud.ResumeLayout(false);
            pnlCrud.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlCantidad.ResumeLayout(false);
            pnlCantidad.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCrud;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNew;
        private ToolStripButton tsbDelete;
        private ToolStripButton tsbEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbUpdate;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbClose;
        private Panel pnlCantidad;
        private Panel pnlGrid;
        private Label lblCantidad;
        private Label label1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colBrandId;
        private DataGridViewTextBoxColumn ColBrandName;
        private DataGridViewCheckBoxColumn colActive;
        private ToolStripDropDownButton tsbFilter;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem noActiveToolStripMenuItem;
    }
}