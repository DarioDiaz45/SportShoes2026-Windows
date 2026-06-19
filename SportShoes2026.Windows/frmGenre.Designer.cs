namespace SportShoes2026.Windows
{
    partial class frmGenre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenre));
            toolStrip1 = new ToolStrip();
            tsbUpdate = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbClose = new ToolStripButton();
            pnlGrid = new Panel();
            dgvDatos = new DataGridView();
            colIdGenre = new DataGridViewTextBoxColumn();
            colTypeGenre = new DataGridViewTextBoxColumn();
            colActive = new DataGridViewCheckBoxColumn();
            toolStrip1.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbUpdate, toolStripSeparator1, tsbClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(775, 70);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
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
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvDatos);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 70);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(775, 235);
            pnlGrid.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colIdGenre, colTypeGenre, colActive });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(775, 235);
            dgvDatos.TabIndex = 0;
            // 
            // colIdGenre
            // 
            colIdGenre.HeaderText = "IdGenre";
            colIdGenre.Name = "colIdGenre";
            colIdGenre.ReadOnly = true;
            colIdGenre.Visible = false;
            // 
            // colTypeGenre
            // 
            colTypeGenre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTypeGenre.HeaderText = "Genre";
            colTypeGenre.Name = "colTypeGenre";
            colTypeGenre.ReadOnly = true;
            // 
            // colActive
            // 
            colActive.HeaderText = "Active";
            colActive.Name = "colActive";
            colActive.ReadOnly = true;
            // 
            // frmGenre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 305);
            Controls.Add(pnlGrid);
            Controls.Add(toolStrip1);
            Name = "frmGenre";
            Text = "frmGenre";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbUpdate;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbClose;
        private Panel pnlGrid;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colIdGenre;
        private DataGridViewTextBoxColumn colTypeGenre;
        private DataGridViewCheckBoxColumn colActive;
    }
}