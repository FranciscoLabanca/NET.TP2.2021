
namespace UI.Desktop
{
    partial class ModuloUsuarioDesktop
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
            this.tlpMUDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.cbModulo = new System.Windows.Forms.ComboBox();
            this.checkBaja = new System.Windows.Forms.CheckBox();
            this.checkModificacion = new System.Windows.Forms.CheckBox();
            this.checkConsulta = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkAlta = new System.Windows.Forms.CheckBox();
            this.tlpMUDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMUDesktop
            // 
            this.tlpMUDesktop.ColumnCount = 4;
            this.tlpMUDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMUDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMUDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMUDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMUDesktop.Controls.Add(this.lblID, 0, 0);
            this.tlpMUDesktop.Controls.Add(this.tbID, 1, 0);
            this.tlpMUDesktop.Controls.Add(this.lblUsuario, 2, 0);
            this.tlpMUDesktop.Controls.Add(this.lblModulo, 0, 1);
            this.tlpMUDesktop.Controls.Add(this.cbUsuario, 3, 0);
            this.tlpMUDesktop.Controls.Add(this.cbModulo, 1, 1);
            this.tlpMUDesktop.Controls.Add(this.checkBaja, 1, 2);
            this.tlpMUDesktop.Controls.Add(this.checkModificacion, 3, 2);
            this.tlpMUDesktop.Controls.Add(this.checkConsulta, 2, 2);
            this.tlpMUDesktop.Controls.Add(this.btnGuardar, 2, 3);
            this.tlpMUDesktop.Controls.Add(this.btnCancelar, 3, 3);
            this.tlpMUDesktop.Controls.Add(this.checkAlta, 0, 2);
            this.tlpMUDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMUDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlpMUDesktop.Name = "tlpMUDesktop";
            this.tlpMUDesktop.RowCount = 4;
            this.tlpMUDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMUDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMUDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMUDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMUDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMUDesktop.Size = new System.Drawing.Size(389, 110);
            this.tlpMUDesktop.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(29, 7);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(53, 3);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(121, 20);
            this.tbID.TabIndex = 10;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(212, 7);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblModulo
            // 
            this.lblModulo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblModulo.AutoSize = true;
            this.lblModulo.Location = new System.Drawing.Point(5, 34);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(42, 13);
            this.lblModulo.TabIndex = 12;
            this.lblModulo.Text = "Modulo";
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(261, 3);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(121, 21);
            this.cbUsuario.TabIndex = 13;
            // 
            // cbModulo
            // 
            this.cbModulo.FormattingEnabled = true;
            this.cbModulo.Location = new System.Drawing.Point(53, 30);
            this.cbModulo.Name = "cbModulo";
            this.cbModulo.Size = new System.Drawing.Size(121, 21);
            this.cbModulo.TabIndex = 14;
            // 
            // checkBaja
            // 
            this.checkBaja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBaja.AutoSize = true;
            this.checkBaja.Location = new System.Drawing.Point(90, 57);
            this.checkBaja.Name = "checkBaja";
            this.checkBaja.Size = new System.Drawing.Size(47, 17);
            this.checkBaja.TabIndex = 15;
            this.checkBaja.Text = "Baja";
            this.checkBaja.UseVisualStyleBackColor = true;
            // 
            // checkModificacion
            // 
            this.checkModificacion.AutoSize = true;
            this.checkModificacion.Location = new System.Drawing.Point(261, 57);
            this.checkModificacion.Name = "checkModificacion";
            this.checkModificacion.Size = new System.Drawing.Size(86, 17);
            this.checkModificacion.TabIndex = 16;
            this.checkModificacion.Text = "Modificacion";
            this.checkModificacion.UseVisualStyleBackColor = true;
            // 
            // checkConsulta
            // 
            this.checkConsulta.AutoSize = true;
            this.checkConsulta.Location = new System.Drawing.Point(180, 57);
            this.checkConsulta.Name = "checkConsulta";
            this.checkConsulta.Size = new System.Drawing.Size(67, 17);
            this.checkConsulta.TabIndex = 17;
            this.checkConsulta.Text = "Consulta";
            this.checkConsulta.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(180, 80);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(261, 80);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkAlta
            // 
            this.checkAlta.AutoSize = true;
            this.checkAlta.Location = new System.Drawing.Point(3, 57);
            this.checkAlta.Name = "checkAlta";
            this.checkAlta.Size = new System.Drawing.Size(44, 17);
            this.checkAlta.TabIndex = 9;
            this.checkAlta.Text = "Alta";
            this.checkAlta.UseVisualStyleBackColor = true;
            // 
            // ModuloUsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 110);
            this.Controls.Add(this.tlpMUDesktop);
            this.Name = "ModuloUsuarioDesktop";
            this.Text = "ModuloUsuarioDesktop";
            this.tlpMUDesktop.ResumeLayout(false);
            this.tlpMUDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMUDesktop;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.CheckBox checkAlta;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.ComboBox cbModulo;
        private System.Windows.Forms.CheckBox checkBaja;
        private System.Windows.Forms.CheckBox checkModificacion;
        private System.Windows.Forms.CheckBox checkConsulta;
    }
}