namespace SportShoes2026.Windows
{
    partial class frmSport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSport));
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
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            lblPaginas = new Label();
            label2 = new Label();
            label1 = new Label();
            lblCantidad = new Label();
            pnlGrilla = new Panel();
            dgvDatos = new DataGridView();
            colIdSport = new DataGridViewTextBoxColumn();
            colSportName = new DataGridViewTextBoxColumn();
            colActive = new DataGridViewCheckBoxColumn();
            pnlCrud.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnlCantidad.SuspendLayout();
            pnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // pnlCrud
            // 
            pnlCrud.Controls.Add(toolStrip1);
            pnlCrud.Dock = DockStyle.Top;
            pnlCrud.Location = new Point(0, 0);
            pnlCrud.Name = "pnlCrud";
            pnlCrud.Size = new Size(800, 70);
            pnlCrud.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ControlDark;
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
            tsbNew.Click += tsbNew_Click;
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
            tsbEdit.Click += tsbEdit_Click;
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
            pnlCantidad.BackColor = SystemColors.ControlDark;
            pnlCantidad.Controls.Add(btnPrimero);
            pnlCantidad.Controls.Add(btnAnterior);
            pnlCantidad.Controls.Add(btnSiguiente);
            pnlCantidad.Controls.Add(btnUltimo);
            pnlCantidad.Controls.Add(lblPaginas);
            pnlCantidad.Controls.Add(label2);
            pnlCantidad.Controls.Add(label1);
            pnlCantidad.Controls.Add(lblCantidad);
            pnlCantidad.Dock = DockStyle.Bottom;
            pnlCantidad.Location = new Point(0, 388);
            pnlCantidad.Name = "pnlCantidad";
            pnlCantidad.Size = new Size(800, 45);
            pnlCantidad.TabIndex = 1;
            // 
            // btnPrimero
            // 
            btnPrimero.BackColor = SystemColors.ControlDark;
            btnPrimero.Image = (Image)resources.GetObject("btnPrimero.Image");
            btnPrimero.Location = new Point(522, 10);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(44, 32);
            btnPrimero.TabIndex = 11;
            btnPrimero.UseVisualStyleBackColor = false;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackColor = SystemColors.ButtonShadow;
            btnAnterior.Image = (Image)resources.GetObject("btnAnterior.Image");
            btnAnterior.ImageAlign = ContentAlignment.BottomCenter;
            btnAnterior.Location = new Point(563, 10);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(44, 32);
            btnAnterior.TabIndex = 10;
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackColor = SystemColors.ControlDark;
            btnSiguiente.Image = Properties.Resources.Right_Button;
            btnSiguiente.Location = new Point(613, 10);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(44, 33);
            btnSiguiente.TabIndex = 9;
            btnSiguiente.UseVisualStyleBackColor = false;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.BackColor = SystemColors.ControlDark;
            btnUltimo.Image = (Image)resources.GetObject("btnUltimo.Image");
            btnUltimo.Location = new Point(663, 10);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(44, 33);
            btnUltimo.TabIndex = 8;
            btnUltimo.UseVisualStyleBackColor = false;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(143, 28);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 3;
            lblPaginas.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 28);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 2;
            label2.Text = "Cantidad de Paginas:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 1;
            label1.Text = "Cantidad de Registros:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(143, 12);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "0";
            // 
            // pnlGrilla
            // 
            pnlGrilla.Controls.Add(dgvDatos);
            pnlGrilla.Dock = DockStyle.Fill;
            pnlGrilla.Location = new Point(0, 70);
            pnlGrilla.Name = "pnlGrilla";
            pnlGrilla.Size = new Size(800, 318);
            pnlGrilla.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.BackgroundColor = SystemColors.ControlDarkDark;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colIdSport, colSportName, colActive });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 318);
            dgvDatos.TabIndex = 0;
            // 
            // colIdSport
            // 
            colIdSport.DataPropertyName = "SportId";
            colIdSport.HeaderText = "Id";
            colIdSport.Name = "colIdSport";
            colIdSport.ReadOnly = true;
            colIdSport.Visible = false;
            // 
            // colSportName
            // 
            colSportName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSportName.DataPropertyName = "SportName";
            colSportName.HeaderText = "Sport";
            colSportName.Name = "colSportName";
            colSportName.ReadOnly = true;
            // 
            // colActive
            // 
            colActive.DataPropertyName = "IsActive";
            colActive.HeaderText = "Active";
            colActive.Name = "colActive";
            colActive.ReadOnly = true;
            // 
            // frmSport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 433);
            Controls.Add(pnlGrilla);
            Controls.Add(pnlCantidad);
            Controls.Add(pnlCrud);
            Name = "frmSport";
            Text = "frmSport";
            Load += frmSport_Load;
            pnlCrud.ResumeLayout(false);
            pnlCrud.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlCantidad.ResumeLayout(false);
            pnlCantidad.PerformLayout();
            pnlGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCrud;
        private Panel pnlCantidad;
        private Panel pnlGrilla;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNew;
        private ToolStripButton tsbDelete;
        private ToolStripButton tsbEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbUpdate;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbClose;
        private DataGridView dgvDatos;
        private Label lblCantidad;
        private Label label1;
        private ToolStripDropDownButton tsbFilter;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem noActiveToolStripMenuItem;
        private DataGridViewTextBoxColumn colIdSport;
        private DataGridViewTextBoxColumn colSportName;
        private DataGridViewCheckBoxColumn colActive;
        private Label label2;
        private Label lblPaginas;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltimo;
    }
}