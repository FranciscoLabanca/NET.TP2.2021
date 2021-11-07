
namespace UI.Desktop
{
    partial class ModulosUsuarios
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
            this.tscModulosUsuarios = new System.Windows.Forms.ToolStripContainer();
            this.tlpModulosUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.id_modulo_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.baja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.consulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tsModulosUsuarios = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscModulosUsuarios.ContentPanel.SuspendLayout();
            this.tscModulosUsuarios.TopToolStripPanel.SuspendLayout();
            this.tscModulosUsuarios.SuspendLayout();
            this.tlpModulosUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.tsModulosUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscModulosUsuarios
            // 
            // 
            // tscModulosUsuarios.ContentPanel
            // 
            this.tscModulosUsuarios.ContentPanel.Controls.Add(this.tlpModulosUsuarios);
            this.tscModulosUsuarios.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tscModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tscModulosUsuarios.Name = "tscModulosUsuarios";
            this.tscModulosUsuarios.Size = new System.Drawing.Size(800, 450);
            this.tscModulosUsuarios.TabIndex = 0;
            this.tscModulosUsuarios.Text = "toolStripContainer1";
            // 
            // tscModulosUsuarios.TopToolStripPanel
            // 
            this.tscModulosUsuarios.TopToolStripPanel.Controls.Add(this.tsModulosUsuarios);
            // 
            // tlpModulosUsuarios
            // 
            this.tlpModulosUsuarios.ColumnCount = 2;
            this.tlpModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpModulosUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlpModulosUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlpModulosUsuarios.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlpModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlpModulosUsuarios.Name = "tlpModulosUsuarios";
            this.tlpModulosUsuarios.RowCount = 2;
            this.tlpModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpModulosUsuarios.Size = new System.Drawing.Size(800, 425);
            this.tlpModulosUsuarios.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulosUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_modulo_usuario,
            this.id_modulo,
            this.id_usuario,
            this.alta,
            this.baja,
            this.consulta,
            this.modificacion});
            this.tlpModulosUsuarios.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.ReadOnly = true;
            this.dgvModulosUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(794, 390);
            this.dgvModulosUsuarios.TabIndex = 2;
            // 
            // id_modulo_usuario
            // 
            this.id_modulo_usuario.DataPropertyName = "ID";
            this.id_modulo_usuario.HeaderText = "ID";
            this.id_modulo_usuario.Name = "id_modulo_usuario";
            this.id_modulo_usuario.ReadOnly = true;
            // 
            // id_modulo
            // 
            this.id_modulo.DataPropertyName = "DescripcionModulo";
            this.id_modulo.HeaderText = "Modulo";
            this.id_modulo.Name = "id_modulo";
            this.id_modulo.ReadOnly = true;
            // 
            // id_usuario
            // 
            this.id_usuario.DataPropertyName = "NombreUsuario";
            this.id_usuario.HeaderText = "Usuario";
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.ReadOnly = true;
            // 
            // alta
            // 
            this.alta.DataPropertyName = "PermiteAlta";
            this.alta.HeaderText = "Alta";
            this.alta.Name = "alta";
            this.alta.ReadOnly = true;
            // 
            // baja
            // 
            this.baja.DataPropertyName = "PermiteBaja";
            this.baja.HeaderText = "Baja";
            this.baja.Name = "baja";
            this.baja.ReadOnly = true;
            // 
            // consulta
            // 
            this.consulta.DataPropertyName = "PermiteConsulta";
            this.consulta.HeaderText = "Consulta";
            this.consulta.Name = "consulta";
            this.consulta.ReadOnly = true;
            // 
            // modificacion
            // 
            this.modificacion.DataPropertyName = "PermiteModificacion";
            this.modificacion.HeaderText = "Modificacion";
            this.modificacion.Name = "modificacion";
            this.modificacion.ReadOnly = true;
            // 
            // tsModulosUsuarios
            // 
            this.tsModulosUsuarios.Dock = System.Windows.Forms.DockStyle.None;
            this.tsModulosUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnEditar,
            this.btnEliminar});
            this.tsModulosUsuarios.Location = new System.Drawing.Point(3, 0);
            this.tsModulosUsuarios.Name = "tsModulosUsuarios";
            this.tsModulosUsuarios.Size = new System.Drawing.Size(112, 25);
            this.tsModulosUsuarios.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregar.Image = global::UI.Desktop.Properties.Resources.icono_agregar;
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(23, 22);
            this.btnAgregar.Text = "Nuevo";
            this.btnAgregar.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::UI.Desktop.Properties.Resources.icono_editar;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = global::UI.Desktop.Properties.Resources.icono_eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.tsbElminar_Click);
            // 
            // ModulosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscModulosUsuarios);
            this.Name = "ModulosUsuarios";
            this.Text = "ModulosUsuarios";
            this.Load += new System.EventHandler(this.ModulosUsuarios_Load);
            this.tscModulosUsuarios.ContentPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.PerformLayout();
            this.tscModulosUsuarios.ResumeLayout(false);
            this.tscModulosUsuarios.PerformLayout();
            this.tlpModulosUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.tsModulosUsuarios.ResumeLayout(false);
            this.tsModulosUsuarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscModulosUsuarios;
        private System.Windows.Forms.TableLayoutPanel tlpModulosUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.ToolStrip tsModulosUsuarios;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_modulo_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn baja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consulta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn modificacion;
    }
}