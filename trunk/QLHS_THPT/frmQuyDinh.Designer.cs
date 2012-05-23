namespace QLHS
{
    partial class frmQuyDinh
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
            this.gridControlQuyDinh = new DevExpress.XtraGrid.GridControl();
            this.gridViewQuyDinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlQuyDinh
            // 
            this.gridControlQuyDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQuyDinh.Location = new System.Drawing.Point(0, 0);
            this.gridControlQuyDinh.MainView = this.gridViewQuyDinh;
            this.gridControlQuyDinh.Name = "gridControlQuyDinh";
            this.gridControlQuyDinh.Size = new System.Drawing.Size(559, 344);
            this.gridControlQuyDinh.TabIndex = 0;
            this.gridControlQuyDinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQuyDinh});
            // 
            // gridViewQuyDinh
            // 
            this.gridViewQuyDinh.GridControl = this.gridControlQuyDinh;
            this.gridViewQuyDinh.Name = "gridViewQuyDinh";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(559, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 244);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(559, 100);
            this.panelControl2.TabIndex = 2;
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 344);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControlQuyDinh);
            this.Name = "frmQuyDinh";
            this.Text = "Quy định";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlQuyDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQuyDinh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}