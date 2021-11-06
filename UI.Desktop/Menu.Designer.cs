
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
            this.alumnosNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesoAModulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosPorUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportePlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.alumnosNIToolStripMenuItem,
            this.usuariosNIToolStripMenuItem,
            this.planesNIToolStripMenuItem,
            this.modulosToolStripMenuItem,
            this.personasToolStripMenuItem,
            this.profesoresToolStripMenuItem,
            this.materiasNIToolStripMenuItem,
            this.inscripcionesNIToolStripMenuItem,
            this.comisionesNIToolStripMenuItem,
            this.toolStripMenuItem1,
            this.especialidadesNIToolStripMenuItem,
            this.reportePlanesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // alumnosNIToolStripMenuItem
            // 
            this.alumnosNIToolStripMenuItem.Name = "alumnosNIToolStripMenuItem";
            this.alumnosNIToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.alumnosNIToolStripMenuItem.Text = "Alumnos NI";
            // 
            // usuariosNIToolStripMenuItem
            // 
            this.usuariosNIToolStripMenuItem.Name = "usuariosNIToolStripMenuItem";
            this.usuariosNIToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosNIToolStripMenuItem.Text = "Usuarios";
            this.usuariosNIToolStripMenuItem.Click += new System.EventHandler(this.usuariosNIToolStripMenuItem_Click);
            // 
            // planesNIToolStripMenuItem
            // 
            this.planesNIToolStripMenuItem.Name = "planesNIToolStripMenuItem";
            this.planesNIToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.planesNIToolStripMenuItem.Text = "Planes";
            this.planesNIToolStripMenuItem.Click += new System.EventHandler(this.planesNIToolStripMenuItem_Click_1);
            // 
            // modulosToolStripMenuItem
            // 
            this.modulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accesoAModulosToolStripMenuItem,
            this.permisosPorUsuarioToolStripMenuItem});
            this.modulosToolStripMenuItem.Name = "modulosToolStripMenuItem";
            this.modulosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.modulosToolStripMenuItem.Text = "Permisos";
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
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.personasToolStripMenuItem_Click);
            // 
            // profesoresToolStripMenuItem
            // 
            this.profesoresToolStripMenuItem.Name = "profesoresToolStripMenuItem";
            this.profesoresToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.profesoresToolStripMenuItem.Text = "Profesores NI";
            // 
            // materiasNIToolStripMenuItem
            // 
            this.materiasNIToolStripMenuItem.Name = "materiasNIToolStripMenuItem";
            this.materiasNIToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.materiasNIToolStripMenuItem.Text = "Materias";
            this.materiasNIToolStripMenuItem.Click += new System.EventHandler(this.materiasNIToolStripMenuItem_Click);
            // 
            // inscripcionesNIToolStripMenuItem
            // 
            this.inscripcionesNIToolStripMenuItem.Name = "inscripcionesNIToolStripMenuItem";
            this.inscripcionesNIToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.inscripcionesNIToolStripMenuItem.Text = "Inscripciones NI";
            // 
            // comisionesNIToolStripMenuItem
            // 
            this.comisionesNIToolStripMenuItem.Name = "comisionesNIToolStripMenuItem";
            this.comisionesNIToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.comisionesNIToolStripMenuItem.Text = "Comisiones";
            this.comisionesNIToolStripMenuItem.Click += new System.EventHandler(this.comisionesNIToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignarDocentesToolStripMenuItem,
            this.administrarCursosToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItem1.Text = "Cursos";
            // 
            // asignarDocentesToolStripMenuItem
            // 
            this.asignarDocentesToolStripMenuItem.Name = "asignarDocentesToolStripMenuItem";
            this.asignarDocentesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.asignarDocentesToolStripMenuItem.Text = "Asignar Docentes";
            this.asignarDocentesToolStripMenuItem.Click += new System.EventHandler(this.asignarDocentesToolStripMenuItem_Click);
            // 
            // administrarCursosToolStripMenuItem
            // 
            this.administrarCursosToolStripMenuItem.Name = "administrarCursosToolStripMenuItem";
            this.administrarCursosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.administrarCursosToolStripMenuItem.Text = "Administrar Cursos";
            this.administrarCursosToolStripMenuItem.Click += new System.EventHandler(this.administrarCursosToolStripMenuItem_Click);
            // 
            // especialidadesNIToolStripMenuItem
            // 
            this.especialidadesNIToolStripMenuItem.Name = "especialidadesNIToolStripMenuItem";
            this.especialidadesNIToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.especialidadesNIToolStripMenuItem.Text = "Especialidades";
            this.especialidadesNIToolStripMenuItem.Click += new System.EventHandler(this.especialidadesNIToolStripMenuItem_Click);
            // 
            // reportePlanesToolStripMenuItem
            // 
            this.reportePlanesToolStripMenuItem.Name = "reportePlanesToolStripMenuItem";
            this.reportePlanesToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.reportePlanesToolStripMenuItem.Text = "Reporte Planes";
            this.reportePlanesToolStripMenuItem.Click += new System.EventHandler(this.reportePlanesToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 490);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Form1";
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
        private System.Windows.Forms.ToolStripMenuItem alumnosNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accesoAModulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionesNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asignarDocentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosPorUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportePlanesToolStripMenuItem;
    }
}

