
namespace UI.Desktop
{
    partial class Planes
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
            this.tscPlanes = new System.Windows.Forms.ToolStripContainer();
            this.tlpPlanes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAgregar = new System.Windows.Forms.ToolStripButton();
            this.BtnEditar = new System.Windows.Forms.ToolStripButton();
            this.BtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscPlanes.ContentPanel.SuspendLayout();
            this.tscPlanes.TopToolStripPanel.SuspendLayout();
            this.tscPlanes.SuspendLayout();
            this.tlpPlanes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscPlanes
            // 
            // 
            // tscPlanes.ContentPanel
            // 
            this.tscPlanes.ContentPanel.Controls.Add(this.tlpPlanes);
            this.tscPlanes.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tscPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscPlanes.Location = new System.Drawing.Point(0, 0);
            this.tscPlanes.Name = "tscPlanes";
            this.tscPlanes.Size = new System.Drawing.Size(800, 450);
            this.tscPlanes.TabIndex = 0;
            this.tscPlanes.Text = "toolStripContainer1";
            // 
            // tscPlanes.TopToolStripPanel
            // 
            this.tscPlanes.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlpPlanes
            // 
            this.tlpPlanes.ColumnCount = 2;
            this.tlpPlanes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlanes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanes.Controls.Add(this.dgvPlanes, 0, 0);
            this.tlpPlanes.Controls.Add(this.btnActualizar, 0, 1);
            this.tlpPlanes.Controls.Add(this.btnSalir, 1, 1);
            this.tlpPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlanes.Location = new System.Drawing.Point(0, 0);
            this.tlpPlanes.Name = "tlpPlanes";
            this.tlpPlanes.RowCount = 2;
            this.tlpPlanes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlanes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanes.Size = new System.Drawing.Size(800, 425);
            this.tlpPlanes.TabIndex = 0;
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.id_especialidad});
            this.tlpPlanes.SetColumnSpan(this.dgvPlanes, 2);
            this.dgvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanes.Location = new System.Drawing.Point(3, 3);
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(794, 390);
            this.dgvPlanes.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "Descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // id_especialidad
            // 
            this.id_especialidad.DataPropertyName = "DescripcionEspecialidad";
            this.id_especialidad.HeaderText = "Especialidad";
            this.id_especialidad.Name = "id_especialidad";
            this.id_especialidad.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAgregar,
            this.BtnEditar,
            this.BtnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAgregar.Image = global::UI.Desktop.Properties.Resources.icono_agregar;
            this.BtnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(23, 22);
            this.BtnAgregar.Text = "Nuevo";
            this.BtnAgregar.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEditar.Image = global::UI.Desktop.Properties.Resources.icono_editar;
            this.BtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(23, 22);
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEliminar.Image = global::UI.Desktop.Properties.Resources.icono_eliminar;
            this.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(23, 22);
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Planes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscPlanes);
            this.Name = "Planes";
            this.Text = "Planes";
            this.Load += new System.EventHandler(this.Planes_Load);
            this.tscPlanes.ContentPanel.ResumeLayout(false);
            this.tscPlanes.TopToolStripPanel.ResumeLayout(false);
            this.tscPlanes.TopToolStripPanel.PerformLayout();
            this.tscPlanes.ResumeLayout(false);
            this.tscPlanes.PerformLayout();
            this.tlpPlanes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscPlanes;
        private System.Windows.Forms.TableLayoutPanel tlpPlanes;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAgregar;
        private System.Windows.Forms.ToolStripButton BtnEditar;
        private System.Windows.Forms.ToolStripButton BtnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_especialidad;
    }
}