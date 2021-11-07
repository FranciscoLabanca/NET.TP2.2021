
namespace UI.Desktop
{
    partial class ReportePlanes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RVPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataPlanes = new UI.Desktop.DataPlanes();
            this.DataTable1TableAdapter = new UI.Desktop.DataPlanesTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataPlanes)).BeginInit();
            this.SuspendLayout();
            // 
            // RVPlanes
            // 
            this.RVPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataPlanes";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.RVPlanes.LocalReport.DataSources.Add(reportDataSource1);
            this.RVPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportePlanes.rdlc";
            this.RVPlanes.Location = new System.Drawing.Point(0, 0);
            this.RVPlanes.Name = "RVPlanes";
            this.RVPlanes.ServerReport.BearerToken = null;
            this.RVPlanes.Size = new System.Drawing.Size(800, 450);
            this.RVPlanes.TabIndex = 0;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataPlanes;
            // 
            // DataPlanes
            // 
            this.DataPlanes.DataSetName = "DataPlanes";
            this.DataPlanes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // ReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RVPlanes);
            this.Name = "ReportePlanes";
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.ReportePlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataPlanes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVPlanes;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataPlanes DataPlanes;
        private DataPlanesTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}