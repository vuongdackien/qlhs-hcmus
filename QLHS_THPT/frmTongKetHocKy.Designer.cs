namespace QLHS
{
    partial class frmTongKetHocKy
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
            this.gridControlTongKetHocKy = new DevExpress.XtraGrid.GridControl();
            this.gridViewTongKetHocKy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSiSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSoLuongDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTyLe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControlHocKy_MonHoc = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditHocKy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControlChonHocKy = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControlTitle = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonXuatBD = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDong = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlTenHocKy = new DevExpress.XtraEditors.LabelControl();
            this.labelControlHocKy = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTenHocKyTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTongKetHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTongKetHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHocKy_MonHoc)).BeginInit();
            this.panelControlHocKy_MonHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHocKy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTitle)).BeginInit();
            this.panelControlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlTongKetHocKy
            // 
            this.gridControlTongKetHocKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTongKetHocKy.Location = new System.Drawing.Point(0, 115);
            this.gridControlTongKetHocKy.MainView = this.gridViewTongKetHocKy;
            this.gridControlTongKetHocKy.Name = "gridControlTongKetHocKy";
            this.gridControlTongKetHocKy.Size = new System.Drawing.Size(834, 277);
            this.gridControlTongKetHocKy.TabIndex = 4;
            this.gridControlTongKetHocKy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTongKetHocKy});
            // 
            // gridViewTongKetHocKy
            // 
            this.gridViewTongKetHocKy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSTT,
            this.gridColumnTenLop,
            this.gridColumnSiSo,
            this.gridColumnSoLuongDat,
            this.gridColumnTyLe});
            this.gridViewTongKetHocKy.GridControl = this.gridControlTongKetHocKy;
            this.gridViewTongKetHocKy.Name = "gridViewTongKetHocKy";
            this.gridViewTongKetHocKy.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnSTT
            // 
            this.gridColumnSTT.Caption = "STT";
            this.gridColumnSTT.Name = "gridColumnSTT";
            this.gridColumnSTT.Visible = true;
            this.gridColumnSTT.VisibleIndex = 0;
            // 
            // gridColumnTenLop
            // 
            this.gridColumnTenLop.Caption = "Lớp";
            this.gridColumnTenLop.Name = "gridColumnTenLop";
            this.gridColumnTenLop.Visible = true;
            this.gridColumnTenLop.VisibleIndex = 1;
            // 
            // gridColumnSiSo
            // 
            this.gridColumnSiSo.Caption = "Sĩ số";
            this.gridColumnSiSo.Name = "gridColumnSiSo";
            this.gridColumnSiSo.Visible = true;
            this.gridColumnSiSo.VisibleIndex = 2;
            // 
            // gridColumnSoLuongDat
            // 
            this.gridColumnSoLuongDat.Caption = "Số lượng đạt";
            this.gridColumnSoLuongDat.Name = "gridColumnSoLuongDat";
            this.gridColumnSoLuongDat.Visible = true;
            this.gridColumnSoLuongDat.VisibleIndex = 3;
            // 
            // gridColumnTyLe
            // 
            this.gridColumnTyLe.Caption = "Tỷ lệ";
            this.gridColumnTyLe.Name = "gridColumnTyLe";
            this.gridColumnTyLe.Visible = true;
            this.gridColumnTyLe.VisibleIndex = 4;
            // 
            // panelControlHocKy_MonHoc
            // 
            this.panelControlHocKy_MonHoc.Controls.Add(this.comboBoxEditHocKy);
            this.panelControlHocKy_MonHoc.Controls.Add(this.labelControlChonHocKy);
            this.panelControlHocKy_MonHoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlHocKy_MonHoc.Location = new System.Drawing.Point(3, 3);
            this.panelControlHocKy_MonHoc.Name = "panelControlHocKy_MonHoc";
            this.panelControlHocKy_MonHoc.Size = new System.Drawing.Size(180, 109);
            this.panelControlHocKy_MonHoc.TabIndex = 0;
            // 
            // comboBoxEditHocKy
            // 
            this.comboBoxEditHocKy.Location = new System.Drawing.Point(16, 50);
            this.comboBoxEditHocKy.Name = "comboBoxEditHocKy";
            this.comboBoxEditHocKy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditHocKy.Size = new System.Drawing.Size(144, 20);
            this.comboBoxEditHocKy.TabIndex = 1;
            // 
            // labelControlChonHocKy
            // 
            this.labelControlChonHocKy.Location = new System.Drawing.Point(16, 28);
            this.labelControlChonHocKy.Name = "labelControlChonHocKy";
            this.labelControlChonHocKy.Size = new System.Drawing.Size(36, 13);
            this.labelControlChonHocKy.TabIndex = 0;
            this.labelControlChonHocKy.Text = "Học kỳ:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControlTitle);
            this.panelControl2.Controls.Add(this.panelControlHocKy_MonHoc);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(834, 115);
            this.panelControl2.TabIndex = 3;
            // 
            // panelControlTitle
            // 
            this.panelControlTitle.Controls.Add(this.simpleButtonXuatBD);
            this.panelControlTitle.Controls.Add(this.simpleButtonDong);
            this.panelControlTitle.Controls.Add(this.labelControlTenHocKy);
            this.panelControlTitle.Controls.Add(this.labelControlHocKy);
            this.panelControlTitle.Controls.Add(this.labelControlTenHocKyTitle);
            this.panelControlTitle.Controls.Add(this.labelControlTitle);
            this.panelControlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlTitle.Location = new System.Drawing.Point(183, 3);
            this.panelControlTitle.Name = "panelControlTitle";
            this.panelControlTitle.Size = new System.Drawing.Size(648, 109);
            this.panelControlTitle.TabIndex = 1;
            // 
            // simpleButtonXuatBD
            // 
            this.simpleButtonXuatBD.Image = global::QLHS.Properties.Resources.chuyenlop_small;
            this.simpleButtonXuatBD.Location = new System.Drawing.Point(337, 56);
            this.simpleButtonXuatBD.Name = "simpleButtonXuatBD";
            this.simpleButtonXuatBD.Size = new System.Drawing.Size(128, 35);
            this.simpleButtonXuatBD.TabIndex = 22;
            this.simpleButtonXuatBD.Text = "Xuất bảng điểm";
            // 
            // simpleButtonDong
            // 
            this.simpleButtonDong.Image = global::QLHS.Properties.Resources.chuyenlop_small;
            this.simpleButtonDong.Location = new System.Drawing.Point(500, 56);
            this.simpleButtonDong.Name = "simpleButtonDong";
            this.simpleButtonDong.Size = new System.Drawing.Size(128, 35);
            this.simpleButtonDong.TabIndex = 21;
            this.simpleButtonDong.Text = "Đóng";
            // 
            // labelControlTenHocKy
            // 
            this.labelControlTenHocKy.Location = new System.Drawing.Point(69, 66);
            this.labelControlTenHocKy.Name = "labelControlTenHocKy";
            this.labelControlTenHocKy.Size = new System.Drawing.Size(42, 13);
            this.labelControlTenHocKy.TabIndex = 2;
            this.labelControlTenHocKy.Text = "_______";
            // 
            // labelControlHocKy
            // 
            this.labelControlHocKy.Location = new System.Drawing.Point(15, 66);
            this.labelControlHocKy.Name = "labelControlHocKy";
            this.labelControlHocKy.Size = new System.Drawing.Size(36, 13);
            this.labelControlHocKy.TabIndex = 2;
            this.labelControlHocKy.Text = "Học kỳ:";
            // 
            // labelControlTenHocKyTitle
            // 
            this.labelControlTenHocKyTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTenHocKyTitle.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControlTenHocKyTitle.Location = new System.Drawing.Point(253, 16);
            this.labelControlTenHocKyTitle.Name = "labelControlTenHocKyTitle";
            this.labelControlTenHocKyTitle.Size = new System.Drawing.Size(40, 19);
            this.labelControlTenHocKyTitle.TabIndex = 1;
            this.labelControlTenHocKyTitle.Text = "____";
            // 
            // labelControlTitle
            // 
            this.labelControlTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTitle.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControlTitle.Location = new System.Drawing.Point(15, 16);
            this.labelControlTitle.Name = "labelControlTitle";
            this.labelControlTitle.Size = new System.Drawing.Size(231, 19);
            this.labelControlTitle.TabIndex = 1;
            this.labelControlTitle.Text = "BÁO CÁO TỔNG KẾT HỌC KỲ";
            // 
            // frmTongKetHocKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 392);
            this.Controls.Add(this.gridControlTongKetHocKy);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmTongKetHocKy";
            this.Text = "Báo cáo tổng kết học kỳ";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTongKetHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTongKetHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHocKy_MonHoc)).EndInit();
            this.panelControlHocKy_MonHoc.ResumeLayout(false);
            this.panelControlHocKy_MonHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHocKy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTitle)).EndInit();
            this.panelControlTitle.ResumeLayout(false);
            this.panelControlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTongKetHocKy;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTongKetHocKy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSTT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTenLop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSiSo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSoLuongDat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTyLe;
        private DevExpress.XtraEditors.PanelControl panelControlHocKy_MonHoc;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlChonHocKy;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControlTitle;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXuatBD;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDong;
        private DevExpress.XtraEditors.LabelControl labelControlTenHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlTenHocKyTitle;
        private DevExpress.XtraEditors.LabelControl labelControlTitle;

    }
}