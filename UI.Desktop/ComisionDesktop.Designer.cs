
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lbId = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbAnioEsp = new System.Windows.Forms.Label();
            this.lbIdPlan = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbPlan = new System.Windows.Forms.ComboBox();
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
            this.tlpComision.Controls.Add(this.btnGuardar, 2, 2);
            this.tlpComision.Controls.Add(this.btnSalir, 3, 2);
            this.tlpComision.Controls.Add(this.lbId, 0, 0);
            this.tlpComision.Controls.Add(this.lbDesc, 2, 0);
            this.tlpComision.Controls.Add(this.lbAnioEsp, 0, 1);
            this.tlpComision.Controls.Add(this.lbIdPlan, 2, 1);
            this.tlpComision.Controls.Add(this.textBox1, 1, 0);
            this.tlpComision.Controls.Add(this.textBox3, 1, 1);
            this.tlpComision.Controls.Add(this.cbPlan, 3, 1);
            this.tlpComision.Controls.Add(this.tbDescripcion, 3, 0);
            this.tlpComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpComision.Location = new System.Drawing.Point(0, 0);
            this.tlpComision.Name = "tlpComision";
            this.tlpComision.RowCount = 3;
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComision.Size = new System.Drawing.Size(447, 85);
            this.tlpComision.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(204, 56);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(285, 56);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
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
            // lbIdPlan
            // 
            this.lbIdPlan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbIdPlan.AutoSize = true;
            this.lbIdPlan.Location = new System.Drawing.Point(251, 33);
            this.lbIdPlan.Name = "lbIdPlan";
            this.lbIdPlan.Size = new System.Drawing.Size(28, 13);
            this.lbIdPlan.TabIndex = 5;
            this.lbIdPlan.Text = "Plan";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(285, 3);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(121, 20);
            this.tbDescripcion.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(98, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            // 
            // cbPlan
            // 
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(285, 29);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(121, 21);
            this.cbPlan.TabIndex = 9;
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 85);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.TextBox tbDescripcion;
    }
}