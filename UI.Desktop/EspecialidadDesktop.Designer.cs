
namespace UI.Desktop
{
    partial class EspecialidadDesktop
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
            this.tlpEspecialidad = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tlpEspecialidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpEspecialidad
            // 
            this.tlpEspecialidad.ColumnCount = 4;
            this.tlpEspecialidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEspecialidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEspecialidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEspecialidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEspecialidad.Controls.Add(this.btnGuardar, 2, 1);
            this.tlpEspecialidad.Controls.Add(this.btnCancelar, 3, 1);
            this.tlpEspecialidad.Controls.Add(this.lblId, 0, 0);
            this.tlpEspecialidad.Controls.Add(this.lbDesc, 2, 0);
            this.tlpEspecialidad.Controls.Add(this.tbId, 1, 0);
            this.tlpEspecialidad.Controls.Add(this.tbDesc, 3, 0);
            this.tlpEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEspecialidad.Location = new System.Drawing.Point(0, 0);
            this.tlpEspecialidad.Name = "tlpEspecialidad";
            this.tlpEspecialidad.RowCount = 2;
            this.tlpEspecialidad.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEspecialidad.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEspecialidad.Size = new System.Drawing.Size(330, 57);
            this.tlpEspecialidad.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(133, 29);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(214, 29);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(3, 6);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "ID";
            // 
            // lbDesc
            // 
            this.lbDesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(145, 6);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(63, 13);
            this.lbDesc.TabIndex = 3;
            this.lbDesc.Text = "Descripcion";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(27, 3);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(100, 20);
            this.tbId.TabIndex = 4;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(214, 3);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(100, 20);
            this.tbDesc.TabIndex = 5;
            // 
            // EspecialidadDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 57);
            this.Controls.Add(this.tlpEspecialidad);
            this.Name = "EspecialidadDesktop";
            this.Text = "EspecialidadDesktop";
            this.tlpEspecialidad.ResumeLayout(false);
            this.tlpEspecialidad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpEspecialidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbDesc;
    }
}