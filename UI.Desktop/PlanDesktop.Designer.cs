
namespace UI.Desktop
{
    partial class PlanDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbId = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbIdEspecialidad = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.cbIdEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDesc, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbIdEspecialidad, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbDesc, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbIdEspecialidad, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbId
            // 
            this.lbId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(66, 6);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(18, 13);
            this.lbId.TabIndex = 0;
            this.lbId.Text = "ID";
            // 
            // lbDesc
            // 
            this.lbDesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(266, 6);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(63, 13);
            this.lbDesc.TabIndex = 1;
            this.lbDesc.Text = "Descripcion";
            // 
            // lbIdEspecialidad
            // 
            this.lbIdEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbIdEspecialidad.AutoSize = true;
            this.lbIdEspecialidad.Location = new System.Drawing.Point(3, 33);
            this.lbIdEspecialidad.Name = "lbIdEspecialidad";
            this.lbIdEspecialidad.Size = new System.Drawing.Size(81, 13);
            this.lbIdEspecialidad.TabIndex = 2;
            this.lbIdEspecialidad.Text = "ID Especialidad";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(90, 3);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(158, 20);
            this.tbId.TabIndex = 3;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(335, 3);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(151, 20);
            this.tbDesc.TabIndex = 4;
            // 
            // cbIdEspecialidad
            // 
            this.cbIdEspecialidad.FormattingEnabled = true;
            this.cbIdEspecialidad.Location = new System.Drawing.Point(90, 29);
            this.cbIdEspecialidad.Name = "cbIdEspecialidad";
            this.cbIdEspecialidad.Size = new System.Drawing.Size(158, 21);
            this.cbIdEspecialidad.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(254, 56);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(335, 56);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // PlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 84);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlanDesktop";
            this.Text = "PlanDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Label lbIdEspecialidad;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.ComboBox cbIdEspecialidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
    }
}