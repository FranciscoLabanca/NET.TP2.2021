
namespace UI.Desktop
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesoAModulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosPorUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CursostoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1055, 466);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1055, 490);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosNIToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.personasToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.comisionesToolStripMenuItem,
            this.CursostoolStripMenuItem,
            this.especialidadesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosNIToolStripMenuItem
            // 
            this.usuariosNIToolStripMenuItem.Enabled = false;
            this.usuariosNIToolStripMenuItem.Name = "usuariosNIToolStripMenuItem";
            this.usuariosNIToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosNIToolStripMenuItem.Text = "Usuarios";
            this.usuariosNIToolStripMenuItem.Click += new System.EventHandler(this.usuariosNIToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Enabled = false;
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesNIToolStripMenuItem_Click_1);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accesoAModulosToolStripMenuItem,
            this.permisosPorUsuarioToolStripMenuItem});
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.permisosToolStripMenuItem.Text = "Permisos";
            // 
            // accesoAModulosToolStripMenuItem
            // 
            this.accesoAModulosToolStripMenuItem.Name = "accesoAModulosToolStripMenuItem";
            this.accesoAModulosToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.accesoAModulosToolStripMenuItem.Text = "Acceso a Modulos (Modulos)";
            this.accesoAModulosToolStripMenuItem.Click += new System.EventHandler(this.accesoAModulosToolStripMenuItem_Click);
            // 
            // permisosPorUsuarioToolStripMenuItem
            // 
            this.permisosPorUsuarioToolStripMenuItem.Name = "permisosPorUsuarioToolStripMenuItem";
            this.permisosPorUsuarioToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.permisosPorUsuarioToolStripMenuItem.Text = "Permisos por Usuario";
            this.permisosPorUsuarioToolStripMenuItem.Click += new System.EventHandler(this.permisosPorUsuarioToolStripMenuItem_Click);
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.Enabled = false;
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.personasToolStripMenuItem_Click);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Enabled = false;
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.materiasToolStripMenuItem.Text = "Materias";
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.materiasNIToolStripMenuItem_Click);
            // 
            // comisionesToolStripMenuItem
            // 
            this.comisionesToolStripMenuItem.Enabled = false;
            this.comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            this.comisionesToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.comisionesToolStripMenuItem.Text = "Comisiones";
            this.comisionesToolStripMenuItem.Click += new System.EventHandler(this.comisionesNIToolStripMenuItem_Click);
            // 
            // CursostoolStripMenuItem
            // 
            this.CursostoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignarDocentesToolStripMenuItem,
            this.administrarCursosToolStripMenuItem});
            this.CursostoolStripMenuItem.Enabled = false;
            this.CursostoolStripMenuItem.Name = "CursostoolStripMenuItem";
            this.CursostoolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.CursostoolStripMenuItem.Text = "Cursos";
            // 
            // asignarDocentesToolStripMenuItem
            // 
            this.asignarDocentesToolStripMenuItem.Name = "asignarDocentesToolStripMenuItem";
            this.asignarDocentesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asignarDocentesToolStripMenuItem.Text = "Asignar Docentes";
            this.asignarDocentesToolStripMenuItem.Click += new System.EventHandler(this.asignarDocentesToolStripMenuItem_Click);
            // 
            // administrarCursosToolStripMenuItem
            // 
            this.administrarCursosToolStripMenuItem.Name = "administrarCursosToolStripMenuItem";
            this.administrarCursosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.administrarCursosToolStripMenuItem.Text = "Administrar Cursos";
            this.administrarCursosToolStripMenuItem.Click += new System.EventHandler(this.administrarCursosToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Enabled = false;
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.especialidadesNIToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 490);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Sistema Academia";
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accesoAModulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CursostoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarDocentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosPorUsuarioToolStripMenuItem;
    }
}

