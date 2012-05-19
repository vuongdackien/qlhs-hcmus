namespace QLHS
{
    partial class frmBC_TongKetMon
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
            this.gridControlTongKetMonHoc = new DevExpress.XtraGrid.GridControl();
            this.gridViewMonHoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGiaoVienCN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSiSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSoLuongDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTyLe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControlTopRight = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonDong = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonXuatBD = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlHocKy = new DevExpress.XtraEditors.LabelControl();
            this.labelControlHocKyTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlKhoiLop = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNamHoc = new DevExpress.XtraEditors.LabelControl();
            this.labelControlKhoiLopTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNamHocTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlMonHocTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTitle = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditNamHoc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.treeMonHoc = new DevExpress.XtraTreeList.TreeList();
            this.labelControlChonNamHoc = new DevExpress.XtraEditors.LabelControl();
            this.panelControlChooseYear = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditKhoiLop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControlChonKhoi = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditHocKy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControlChonHocKy = new DevExpress.XtraEditors.LabelControl();
            this.panelControlRight = new DevExpress.XtraEditors.PanelControl();
            this.panelControlLeft = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTongKetMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTopRight)).BeginInit();
            this.panelControlTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNamHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlChooseYear)).BeginInit();
            this.panelControlChooseYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditKhoiLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHocKy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRight)).BeginInit();
            this.panelControlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).BeginInit();
            this.panelControlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlTongKetMonHoc
            // 
            this.gridControlTongKetMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTongKetMonHoc.Location = new System.Drawing.Point(2, 106);
            this.gridControlTongKetMonHoc.MainView = this.gridViewMonHoc;
            this.gridControlTongKetMonHoc.Name = "gridControlTongKetMonHoc";
            this.gridControlTongKetMonHoc.Size = new System.Drawing.Size(809, 284);
            this.gridControlTongKetMonHoc.TabIndex = 1;
            this.gridControlTongKetMonHoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMonHoc});
            // 
            // gridViewMonHoc
            // 
            this.gridViewMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSTT,
            this.gridColumnTenLop,
            this.gridColumnGiaoVienCN,
            this.gridColumnSiSo,
            this.gridColumnSoLuongDat,
            this.gridColumnTyLe});
            this.gridViewMonHoc.GridControl = this.gridControlTongKetMonHoc;
            this.gridViewMonHoc.Name = "gridViewMonHoc";
            this.gridViewMonHoc.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnSTT
            // 
            this.gridColumnSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSTT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnSTT.Caption = "STT";
            this.gridColumnSTT.FieldName = "STT";
            this.gridColumnSTT.Name = "gridColumnSTT";
            this.gridColumnSTT.OptionsColumn.AllowEdit = false;
            this.gridColumnSTT.OptionsColumn.AllowFocus = false;
            this.gridColumnSTT.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSTT.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumnSTT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSTT.OptionsColumn.AllowMove = false;
            this.gridColumnSTT.OptionsColumn.AllowShowHide = false;
            this.gridColumnSTT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSTT.OptionsColumn.ReadOnly = true;
            this.gridColumnSTT.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnSTT.OptionsFilter.AllowFilter = false;
            this.gridColumnSTT.Visible = true;
            this.gridColumnSTT.VisibleIndex = 0;
            this.gridColumnSTT.Width = 52;
            // 
            // gridColumnTenLop
            // 
            this.gridColumnTenLop.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnTenLop.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnTenLop.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnTenLop.Caption = "Tên lớp";
            this.gridColumnTenLop.FieldName = "TenLop";
            this.gridColumnTenLop.Name = "gridColumnTenLop";
            this.gridColumnTenLop.Visible = true;
            this.gridColumnTenLop.VisibleIndex = 1;
            this.gridColumnTenLop.Width = 141;
            // 
            // gridColumnGiaoVienCN
            // 
            this.gridColumnGiaoVienCN.Caption = "Giáo viên chủ nhiệm";
            this.gridColumnGiaoVienCN.FieldName = "TenGiaoVien";
            this.gridColumnGiaoVienCN.Name = "gridColumnGiaoVienCN";
            this.gridColumnGiaoVienCN.Visible = true;
            this.gridColumnGiaoVienCN.VisibleIndex = 2;
            this.gridColumnGiaoVienCN.Width = 135;
            // 
            // gridColumnSiSo
            // 
            this.gridColumnSiSo.Caption = "Sĩ số";
            this.gridColumnSiSo.FieldName = "SiSo";
            this.gridColumnSiSo.Name = "gridColumnSiSo";
            this.gridColumnSiSo.Visible = true;
            this.gridColumnSiSo.VisibleIndex = 3;
            // 
            // gridColumnSoLuongDat
            // 
            this.gridColumnSoLuongDat.Caption = "Số lượng đạt";
            this.gridColumnSoLuongDat.FieldName = "SoLuongDat";
            this.gridColumnSoLuongDat.Name = "gridColumnSoLuongDat";
            this.gridColumnSoLuongDat.Visible = true;
            this.gridColumnSoLuongDat.VisibleIndex = 4;
            // 
            // gridColumnTyLe
            // 
            this.gridColumnTyLe.Caption = "Tỷ lệ";
            this.gridColumnTyLe.FieldName = "TyLe";
            this.gridColumnTyLe.Name = "gridColumnTyLe";
            this.gridColumnTyLe.Visible = true;
            this.gridColumnTyLe.VisibleIndex = 5;
            // 
            // panelControlTopRight
            // 
            this.panelControlTopRight.Controls.Add(this.simpleButtonDong);
            this.panelControlTopRight.Controls.Add(this.simpleButtonXuatBD);
            this.panelControlTopRight.Controls.Add(this.labelControlHocKy);
            this.panelControlTopRight.Controls.Add(this.labelControlHocKyTT);
            this.panelControlTopRight.Controls.Add(this.labelControlKhoiLop);
            this.panelControlTopRight.Controls.Add(this.labelControlNamHoc);
            this.panelControlTopRight.Controls.Add(this.labelControlKhoiLopTT);
            this.panelControlTopRight.Controls.Add(this.labelControlNamHocTT);
            this.panelControlTopRight.Controls.Add(this.labelControlMonHocTT);
            this.panelControlTopRight.Controls.Add(this.labelControlTitle);
            this.panelControlTopRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlTopRight.Location = new System.Drawing.Point(2, 2);
            this.panelControlTopRight.Name = "panelControlTopRight";
            this.panelControlTopRight.Size = new System.Drawing.Size(809, 104);
            this.panelControlTopRight.TabIndex = 0;
            // 
            // simpleButtonDong
            // 
            this.simpleButtonDong.Image = global::QLHS.Properties.Resources.chuyenlop_small;
            this.simpleButtonDong.Location = new System.Drawing.Point(651, 28);
            this.simpleButtonDong.Name = "simpleButtonDong";
            this.simpleButtonDong.Size = new System.Drawing.Size(128, 35);
            this.simpleButtonDong.TabIndex = 18;
            this.simpleButtonDong.Text = "Đóng";
            this.simpleButtonDong.Click += new System.EventHandler(this.simpleButtonDong_Click);
            // 
            // simpleButtonXuatBD
            // 
            this.simpleButtonXuatBD.Image = global::QLHS.Properties.Resources.chuyenlop_small;
            this.simpleButtonXuatBD.Location = new System.Drawing.Point(492, 28);
            this.simpleButtonXuatBD.Name = "simpleButtonXuatBD";
            this.simpleButtonXuatBD.Size = new System.Drawing.Size(128, 35);
            this.simpleButtonXuatBD.TabIndex = 18;
            this.simpleButtonXuatBD.Text = "Lập báo cáo";
            this.simpleButtonXuatBD.Click += new System.EventHandler(this.simpleButtonXuatBD_Click);
            // 
            // labelControlHocKy
            // 
            this.labelControlHocKy.Location = new System.Drawing.Point(226, 50);
            this.labelControlHocKy.Name = "labelControlHocKy";
            this.labelControlHocKy.Size = new System.Drawing.Size(48, 13);
            this.labelControlHocKy.TabIndex = 1;
            this.labelControlHocKy.Text = "________";
            // 
            // labelControlHocKyTT
            // 
            this.labelControlHocKyTT.Location = new System.Drawing.Point(180, 50);
            this.labelControlHocKyTT.Name = "labelControlHocKyTT";
            this.labelControlHocKyTT.Size = new System.Drawing.Size(36, 13);
            this.labelControlHocKyTT.TabIndex = 1;
            this.labelControlHocKyTT.Text = "Học kỳ:";
            // 
            // labelControlKhoiLop
            // 
            this.labelControlKhoiLop.Location = new System.Drawing.Point(46, 82);
            this.labelControlKhoiLop.Name = "labelControlKhoiLop";
            this.labelControlKhoiLop.Size = new System.Drawing.Size(48, 13);
            this.labelControlKhoiLop.TabIndex = 1;
            this.labelControlKhoiLop.Text = "________";
            // 
            // labelControlNamHoc
            // 
            this.labelControlNamHoc.Location = new System.Drawing.Point(68, 51);
            this.labelControlNamHoc.Name = "labelControlNamHoc";
            this.labelControlNamHoc.Size = new System.Drawing.Size(48, 13);
            this.labelControlNamHoc.TabIndex = 1;
            this.labelControlNamHoc.Text = "________";
            // 
            // labelControlKhoiLopTT
            // 
            this.labelControlKhoiLopTT.Location = new System.Drawing.Point(13, 82);
            this.labelControlKhoiLopTT.Name = "labelControlKhoiLopTT";
            this.labelControlKhoiLopTT.Size = new System.Drawing.Size(24, 13);
            this.labelControlKhoiLopTT.TabIndex = 1;
            this.labelControlKhoiLopTT.Text = "Khối:";
            // 
            // labelControlNamHocTT
            // 
            this.labelControlNamHocTT.Location = new System.Drawing.Point(13, 51);
            this.labelControlNamHocTT.Name = "labelControlNamHocTT";
            this.labelControlNamHocTT.Size = new System.Drawing.Size(45, 13);
            this.labelControlNamHocTT.TabIndex = 1;
            this.labelControlNamHocTT.Text = "Năm học:";
            // 
            // labelControlMonHocTT
            // 
            this.labelControlMonHocTT.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlMonHocTT.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControlMonHocTT.Location = new System.Drawing.Point(227, 9);
            this.labelControlMonHocTT.Name = "labelControlMonHocTT";
            this.labelControlMonHocTT.Size = new System.Drawing.Size(80, 19);
            this.labelControlMonHocTT.TabIndex = 0;
            this.labelControlMonHocTT.Text = "________";
            // 
            // labelControlTitle
            // 
            this.labelControlTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTitle.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControlTitle.Location = new System.Drawing.Point(13, 9);
            this.labelControlTitle.Name = "labelControlTitle";
            this.labelControlTitle.Size = new System.Drawing.Size(207, 19);
            this.labelControlTitle.TabIndex = 0;
            this.labelControlTitle.Text = "BÁO CÁO TỔNG KẾT MÔN";
            // 
            // comboBoxEditNamHoc
            // 
            this.comboBoxEditNamHoc.Location = new System.Drawing.Point(25, 24);
            this.comboBoxEditNamHoc.Name = "comboBoxEditNamHoc";
            this.comboBoxEditNamHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNamHoc.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditNamHoc.TabIndex = 1;
            this.comboBoxEditNamHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditNamHoc_SelectedIndexChanged);
            // 
            // treeMonHoc
            // 
            this.treeMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMonHoc.Location = new System.Drawing.Point(2, 151);
            this.treeMonHoc.Name = "treeMonHoc";
            this.treeMonHoc.OptionsBehavior.Editable = false;
            this.treeMonHoc.OptionsView.EnableAppearanceEvenRow = true;
            this.treeMonHoc.OptionsView.EnableAppearanceOddRow = true;
            this.treeMonHoc.OptionsView.ShowColumns = false;
            this.treeMonHoc.OptionsView.ShowRoot = false;
            this.treeMonHoc.Size = new System.Drawing.Size(178, 239);
            this.treeMonHoc.TabIndex = 1;
            this.treeMonHoc.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeMonHoc_FocusedNodeChanged);
            // 
            // labelControlChonNamHoc
            // 
            this.labelControlChonNamHoc.Location = new System.Drawing.Point(25, 6);
            this.labelControlChonNamHoc.Name = "labelControlChonNamHoc";
            this.labelControlChonNamHoc.Size = new System.Drawing.Size(72, 13);
            this.labelControlChonNamHoc.TabIndex = 0;
            this.labelControlChonNamHoc.Text = "Chọn năm học:";
            // 
            // panelControlChooseYear
            // 
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditKhoiLop);
            this.panelControlChooseYear.Controls.Add(this.labelControlChonKhoi);
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditHocKy);
            this.panelControlChooseYear.Controls.Add(this.labelControlChonHocKy);
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditNamHoc);
            this.panelControlChooseYear.Controls.Add(this.labelControlChonNamHoc);
            this.panelControlChooseYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlChooseYear.Location = new System.Drawing.Point(2, 2);
            this.panelControlChooseYear.Name = "panelControlChooseYear";
            this.panelControlChooseYear.Size = new System.Drawing.Size(178, 149);
            this.panelControlChooseYear.TabIndex = 0;
            // 
            // comboBoxEditKhoiLop
            // 
            this.comboBoxEditKhoiLop.Location = new System.Drawing.Point(25, 121);
            this.comboBoxEditKhoiLop.Name = "comboBoxEditKhoiLop";
            this.comboBoxEditKhoiLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditKhoiLop.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditKhoiLop.TabIndex = 3;
            this.comboBoxEditKhoiLop.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditKhoiLop_SelectedIndexChanged);
            // 
            // labelControlChonKhoi
            // 
            this.labelControlChonKhoi.Location = new System.Drawing.Point(25, 102);
            this.labelControlChonKhoi.Name = "labelControlChonKhoi";
            this.labelControlChonKhoi.Size = new System.Drawing.Size(51, 13);
            this.labelControlChonKhoi.TabIndex = 2;
            this.labelControlChonKhoi.Text = "Chọn khối:";
            // 
            // comboBoxEditHocKy
            // 
            this.comboBoxEditHocKy.Location = new System.Drawing.Point(25, 73);
            this.comboBoxEditHocKy.Name = "comboBoxEditHocKy";
            this.comboBoxEditHocKy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditHocKy.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditHocKy.TabIndex = 1;
            this.comboBoxEditHocKy.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditHocKy_SelectedIndexChanged);
            // 
            // labelControlChonHocKy
            // 
            this.labelControlChonHocKy.Location = new System.Drawing.Point(25, 54);
            this.labelControlChonHocKy.Name = "labelControlChonHocKy";
            this.labelControlChonHocKy.Size = new System.Drawing.Size(63, 13);
            this.labelControlChonHocKy.TabIndex = 0;
            this.labelControlChonHocKy.Text = "Chọn học kỳ:";
            // 
            // panelControlRight
            // 
            this.panelControlRight.Controls.Add(this.gridControlTongKetMonHoc);
            this.panelControlRight.Controls.Add(this.panelControlTopRight);
            this.panelControlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlRight.Location = new System.Drawing.Point(182, 0);
            this.panelControlRight.Name = "panelControlRight";
            this.panelControlRight.Size = new System.Drawing.Size(813, 392);
            this.panelControlRight.TabIndex = 3;
            // 
            // panelControlLeft
            // 
            this.panelControlLeft.Controls.Add(this.treeMonHoc);
            this.panelControlLeft.Controls.Add(this.panelControlChooseYear);
            this.panelControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlLeft.Location = new System.Drawing.Point(0, 0);
            this.panelControlLeft.Name = "panelControlLeft";
            this.panelControlLeft.Size = new System.Drawing.Size(182, 392);
            this.panelControlLeft.TabIndex = 2;
            // 
            // frmBC_TongKetMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 392);
            this.Controls.Add(this.panelControlRight);
            this.Controls.Add(this.panelControlLeft);
            this.Name = "frmBC_TongKetMon";
            this.Text = "Bảng điểm học sinh";
            this.Load += new System.EventHandler(this.frmBC_TongKetMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTongKetMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTopRight)).EndInit();
            this.panelControlTopRight.ResumeLayout(false);
            this.panelControlTopRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNamHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlChooseYear)).EndInit();
            this.panelControlChooseYear.ResumeLayout(false);
            this.panelControlChooseYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditKhoiLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHocKy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRight)).EndInit();
            this.panelControlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).EndInit();
            this.panelControlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTongKetMonHoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSTT;
        private DevExpress.XtraEditors.PanelControl panelControlTopRight;
        private DevExpress.XtraEditors.LabelControl labelControlHocKyTT;
        private DevExpress.XtraEditors.LabelControl labelControlNamHocTT;
        private DevExpress.XtraEditors.LabelControl labelControlTitle;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNamHoc;
        private DevExpress.XtraTreeList.TreeList treeMonHoc;
        private DevExpress.XtraEditors.LabelControl labelControlChonNamHoc;
        private DevExpress.XtraEditors.PanelControl panelControlChooseYear;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlChonHocKy;
        private DevExpress.XtraEditors.PanelControl panelControlRight;
        private DevExpress.XtraEditors.PanelControl panelControlLeft;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXuatBD;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditKhoiLop;
        private DevExpress.XtraEditors.LabelControl labelControlChonKhoi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTenLop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGiaoVienCN;
        private DevExpress.XtraEditors.LabelControl labelControlHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlNamHoc;
        private DevExpress.XtraEditors.LabelControl labelControlMonHocTT;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDong;
        private DevExpress.XtraEditors.LabelControl labelControlKhoiLop;
        private DevExpress.XtraEditors.LabelControl labelControlKhoiLopTT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSiSo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSoLuongDat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTyLe;

    }
}