
namespace UI.Desktop
{
    partial class ComisionDesktop
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
            this.tlpComision = new System.Windows.Forms.TableLayoutPanel();
            this.lbId = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbAnioEsp = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbAnio = new System.Windows.Forms.TextBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lbIdPlan = new System.Windows.Forms.Label();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.lbEspecialidad = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.tlpComision.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpComision
            // 
            this.tlpComision.ColumnCount = 4;
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpComision.Controls.Add(this.lbId, 0, 0);
            this.tlpComision.Controls.Add(this.lbDesc, 2, 0);
            this.tlpComision.Controls.Add(this.lbAnioEsp, 0, 1);
            this.tlpComision.Controls.Add(this.tbId, 1, 0);
            this.tlpComision.Controls.Add(this.tbAnio, 1, 1);
            this.tlpComision.Controls.Add(this.tbDescripcion, 3, 0);
            this.tlpComision.Controls.Add(this.btnGuardar, 2, 3);
            this.tlpComision.Controls.Add(this.btnSalir, 3, 3);
            this.tlpComision.Controls.Add(this.lbIdPlan, 2, 2);
            this.tlpComision.Controls.Add(this.cbPlan, 3, 2);
            this.tlpComision.Controls.Add(this.lbEspecialidad, 2, 1);
            this.tlpComision.Controls.Add(this.cbEspecialidad, 3, 1);
            this.tlpComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpComision.Location = new System.Drawing.Point(0, 0);
            this.tlpComision.Name = "tlpComision";
            this.tlpComision.RowCount = 4;
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.Size = new System.Drawing.Size(447, 111);
            this.tlpComision.TabIndex = 0;
            // 
            // lbId
            // 
            this.lbId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(74, 6);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(18, 13);
            this.lbId.TabIndex = 2;
            this.lbId.Text = "ID";
            // 
            // lbDesc
            // 
            this.lbDesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(216, 6);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(63, 13);
            this.lbDesc.TabIndex = 3;
            this.lbDesc.Text = "Descripcion";
            // 
            // lbAnioEsp
            // 
            this.lbAnioEsp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAnioEsp.AutoSize = true;
            this.lbAnioEsp.Location = new System.Drawing.Point(3, 33);
            this.lbAnioEsp.Name = "lbAnioEsp";
            this.lbAnioEsp.Size = new System.Drawing.Size(89, 13);
            this.lbAnioEsp.TabIndex = 4;
            this.lbAnioEsp.Text = "Año Especialidad";
            // 
            // tbId
            // 
            this.tbId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbId.Location = new System.Drawing.Point(98, 3);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(100, 20);
            this.tbId.TabIndex = 6;
            // 
            // tbAnio
            // 
            this.tbAnio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAnio.Location = new System.Drawing.Point(98, 29);
            this.tbAnio.Name = "tbAnio";
            this.tbAnio.Size = new System.Drawing.Size(100, 20);
            this.tbAnio.TabIndex = 8;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDescripcion.Location = new System.Drawing.Point(285, 3);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(121, 20);
            this.tbDescripcion.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(204, 83);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(285, 83);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lbIdPlan
            // 
            this.lbIdPlan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbIdPlan.AutoSize = true;
            this.lbIdPlan.Location = new System.Drawing.Point(251, 60);
            this.lbIdPlan.Name = "lbIdPlan";
            this.lbIdPlan.Size = new System.Drawing.Size(28, 13);
            this.lbIdPlan.TabIndex = 5;
            this.lbIdPlan.Text = "Plan";
            // 
            // cbPlan
            // 
            this.cbPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(285, 56);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(121, 21);
            this.cbPlan.TabIndex = 9;
            // 
            // lbEspecialidad
            // 
            this.lbEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEspecialidad.AutoSize = true;
            this.lbEspecialidad.Location = new System.Drawing.Point(212, 33);
            this.lbEspecialidad.Name = "lbEspecialidad";
            this.lbEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lbEspecialidad.TabIndex = 10;
            this.lbEspecialidad.Text = "Especialidad";
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(285, 29);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cbEspecialidad.TabIndex = 11;
            this.cbEspecialidad.SelectedValueChanged += new System.EventHandler(this.cbEspecialidad_SelectedValueChanged);
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 111);
            this.Controls.Add(this.tlpComision);
            this.Name = "ComisionDesktop";
            this.Text = "ComisionDesktop";
            this.tlpComision.ResumeLayout(false);
            this.tlpComision.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpComision;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Label lbAnioEsp;
        private System.Windows.Forms.Label lbIdPlan;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbAnio;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lbEspecialidad;
        private System.Windows.Forms.ComboBox cbEspecialidad;
    }
}