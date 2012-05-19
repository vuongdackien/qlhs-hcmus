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
            this.gridControlTongKetNamHoc = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumntenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSiSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSoLuongDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTiLe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGiaoVienCN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControlGVCNTT = new DevExpress.XtraEditors.LabelControl();
            this.panelControlTopRight = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonXuatBD = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlHocKyTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNamHocTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTitle = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditNamHoc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.treeMonHoc = new DevExpress.XtraTreeList.TreeList();
            this.labelControlNamHoc = new DevExpress.XtraEditors.LabelControl();
            this.panelControlChooseYear = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditKhoiLop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditHocKy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControlHocKy = new DevExpress.XtraEditors.LabelControl();
            this.panelControlRight = new DevExpress.XtraEditors.PanelControl();
            this.panelControlLeft = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTongKetNamHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            // gridControlTongKetNamHoc
            // 
            this.gridControlTongKetNamHoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlTongKetNamHoc.Location = new System.Drawing.Point(2, 82);
            this.gridControlTongKetNamHoc.MainView = this.gridView1;
            this.gridControlTongKetNamHoc.Name = "gridControlTongKetNamHoc";
            this.gridControlTongKetNamHoc.Size = new System.Drawing.Size(616, 308);
            this.gridControlTongKetNamHoc.TabIndex = 1;
            this.gridControlTongKetNamHoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSTT,
            this.gridColumntenLop,
            this.gridColumnSiSo,
            this.gridColumnSoLuongDat,
            this.gridColumnTiLe,
            this.gridColumnGiaoVienCN});
            this.gridView1.GridControl = this.gridControlTongKetNamHoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // gridColumntenLop
            // 
            this.gridColumntenLop.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumntenLop.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumntenLop.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumntenLop.Caption = "Tên lớp";
            this.gridColumntenLop.FieldName = "TenLop";
            this.gridColumntenLop.Name = "gridColumntenLop";
            this.gridColumntenLop.Visible = true;
            this.gridColumntenLop.VisibleIndex = 1;
            this.gridColumntenLop.Width = 141;
            // 
            // gridColumnSiSo
            // 
            this.gridColumnSiSo.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumnSiSo.AppearanceCell.Options.UseFont = true;
            this.gridColumnSiSo.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnSiSo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSiSo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnSiSo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSiSo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSiSo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnSiSo.Caption = "Sỉ số";
            this.gridColumnSiSo.FieldName = "SiSo";
            this.gridColumnSiSo.Name = "gridColumnSiSo";
            this.gridColumnSiSo.Visible = true;
            this.gridColumnSiSo.VisibleIndex = 3;
            this.gridColumnSiSo.Width = 95;
            // 
            // gridColumnSoLuongDat
            // 
            this.gridColumnSoLuongDat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumnSoLuongDat.AppearanceCell.Options.UseFont = true;
            this.gridColumnSoLuongDat.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnSoLuongDat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSoLuongDat.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnSoLuongDat.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSoLuongDat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSoLuongDat.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnSoLuongDat.Caption = "Số lượng đạt";
            this.gridColumnSoLuongDat.FieldName = "SoLuongDat";
            this.gridColumnSoLuongDat.Name = "gridColumnSoLuongDat";
            this.gridColumnSoLuongDat.Visible = true;
            this.gridColumnSoLuongDat.VisibleIndex = 4;
            this.gridColumnSoLuongDat.Width = 83;
            // 
            // gridColumnTiLe
            // 
            this.gridColumnTiLe.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumnTiLe.AppearanceCell.Options.UseFont = true;
            this.gridColumnTiLe.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnTiLe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnTiLe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnTiLe.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnTiLe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnTiLe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumnTiLe.Caption = "Tỉ lệ";
            this.gridColumnTiLe.FieldName = "TiLe";
            this.gridColumnTiLe.Name = "gridColumnTiLe";
            this.gridColumnTiLe.Visible = true;
            this.gridColumnTiLe.VisibleIndex = 5;
            this.gridColumnTiLe.Width = 92;
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
            // labelControlGVCNTT
            // 
            this.labelControlGVCNTT.Location = new System.Drawing.Point(13, 61);
            this.labelControlGVCNTT.Name = "labelControlGVCNTT";
            this.labelControlGVCNTT.Size = new System.Drawing.Size(44, 13);
            this.labelControlGVCNTT.TabIndex = 1;
            this.labelControlGVCNTT.Text = "Môn học:";
            // 
            // panelControlTopRight
            // 
            this.panelControlTopRight.Controls.Add(this.simpleButtonXuatBD);
            this.panelControlTopRight.Controls.Add(this.labelControlGVCNTT);
            this.panelControlTopRight.Controls.Add(this.labelControlHocKyTT);
            this.panelControlTopRight.Controls.Add(this.labelControlNamHocTT);
            this.panelControlTopRight.Controls.Add(this.labelControlTitle);
            this.panelControlTopRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlTopRight.Location = new System.Drawing.Point(2, 2);
            this.panelControlTopRight.Name = "panelControlTopRight";
            this.panelControlTopRight.Size = new System.Drawing.Size(809, 80);
            this.panelControlTopRight.TabIndex = 0;
            // 
            // simpleButtonXuatBD
            // 
            this.simpleButtonXuatBD.Image = global::QLHS.Properties.Resources.chuyenlop_small;
            this.simpleButtonXuatBD.Location = new System.Drawing.Point(488, 21);
            this.simpleButtonXuatBD.Name = "simpleButtonXuatBD";
            this.simpleButtonXuatBD.Size = new System.Drawing.Size(128, 35);
            this.simpleButtonXuatBD.TabIndex = 18;
            this.simpleButtonXuatBD.Text = "Lập báo cáo";
            // 
            // labelControlHocKyTT
            // 
            this.labelControlHocKyTT.Location = new System.Drawing.Point(126, 34);
            this.labelControlHocKyTT.Name = "labelControlHocKyTT";
            this.labelControlHocKyTT.Size = new System.Drawing.Size(36, 13);
            this.labelControlHocKyTT.TabIndex = 1;
            this.labelControlHocKyTT.Text = "Học kỳ:";
            // 
            // labelControlNamHocTT
            // 
            this.labelControlNamHocTT.Location = new System.Drawing.Point(13, 35);
            this.labelControlNamHocTT.Name = "labelControlNamHocTT";
            this.labelControlNamHocTT.Size = new System.Drawing.Size(45, 13);
            this.labelControlNamHocTT.TabIndex = 1;
            this.labelControlNamHocTT.Text = "Năm học:";
            // 
            // labelControlTitle
            // 
            this.labelControlTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTitle.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControlTitle.Location = new System.Drawing.Point(6, 6);
            this.labelControlTitle.Name = "labelControlTitle";
            this.labelControlTitle.Size = new System.Drawing.Size(207, 19);
            this.labelControlTitle.TabIndex = 0;
            this.labelControlTitle.Text = "BÁO CÁO TỔNG KẾT MÔN";
            // 
            // comboBoxEditNamHoc
            // 
            this.comboBoxEditNamHoc.Location = new System.Drawing.Point(25, 27);
            this.comboBoxEditNamHoc.Name = "comboBoxEditNamHoc";
            this.comboBoxEditNamHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNamHoc.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditNamHoc.TabIndex = 1;
            // 
            // treeMonHoc
            // 
            this.treeMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMonHoc.Location = new System.Drawing.Point(2, 140);
            this.treeMonHoc.Name = "treeMonHoc";
            this.treeMonHoc.OptionsBehavior.Editable = false;
            this.treeMonHoc.OptionsView.EnableAppearanceEvenRow = true;
            this.treeMonHoc.OptionsView.EnableAppearanceOddRow = true;
            this.treeMonHoc.OptionsView.ShowColumns = false;
            this.treeMonHoc.OptionsView.ShowRoot = false;
            this.treeMonHoc.Size = new System.Drawing.Size(178, 250);
            this.treeMonHoc.TabIndex = 1;
            // 
            // labelControlNamHoc
            // 
            this.labelControlNamHoc.Location = new System.Drawing.Point(25, 8);
            this.labelControlNamHoc.Name = "labelControlNamHoc";
            this.labelControlNamHoc.Size = new System.Drawing.Size(72, 13);
            this.labelControlNamHoc.TabIndex = 0;
            this.labelControlNamHoc.Text = "Chọn năm học:";
            // 
            // panelControlChooseYear
            // 
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditKhoiLop);
            this.panelControlChooseYear.Controls.Add(this.labelControl1);
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditHocKy);
            this.panelControlChooseYear.Controls.Add(this.labelControlHocKy);
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditNamHoc);
            this.panelControlChooseYear.Controls.Add(this.labelControlNamHoc);
            this.panelControlChooseYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlChooseYear.Location = new System.Drawing.Point(2, 2);
            this.panelControlChooseYear.Name = "panelControlChooseYear";
            this.panelControlChooseYear.Size = new System.Drawing.Size(178, 138);
            this.panelControlChooseYear.TabIndex = 0;
            // 
            // comboBoxEditKhoiLop
            // 
            this.comboBoxEditKhoiLop.Location = new System.Drawing.Point(25, 112);
            this.comboBoxEditKhoiLop.Name = "comboBoxEditKhoiLop";
            this.comboBoxEditKhoiLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditKhoiLop.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditKhoiLop.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Chọn khối:";
            // 
            // comboBoxEditHocKy
            // 
            this.comboBoxEditHocKy.Location = new System.Drawing.Point(25, 70);
            this.comboBoxEditHocKy.Name = "comboBoxEditHocKy";
            this.comboBoxEditHocKy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditHocKy.Size = new System.Drawing.Size(130, 20);
            this.comboBoxEditHocKy.TabIndex = 1;
            // 
            // labelControlHocKy
            // 
            this.labelControlHocKy.Location = new System.Drawing.Point(25, 51);
            this.labelControlHocKy.Name = "labelControlHocKy";
            this.labelControlHocKy.Size = new System.Drawing.Size(63, 13);
            this.labelControlHocKy.TabIndex = 0;
            this.labelControlHocKy.Text = "Chọn học kỳ:";
            // 
            // panelControlRight
            // 
            this.panelControlRight.Controls.Add(this.gridControlTongKetNamHoc);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTongKetNamHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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

        private DevExpress.XtraGrid.GridControl gridControlTongKetNamHoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSTT;
        private DevExpress.XtraEditors.LabelControl labelControlGVCNTT;
        private DevExpress.XtraEditors.PanelControl panelControlTopRight;
        private DevExpress.XtraEditors.LabelControl labelControlHocKyTT;
        private DevExpress.XtraEditors.LabelControl labelControlNamHocTT;
        private DevExpress.XtraEditors.LabelControl labelControlTitle;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNamHoc;
        private DevExpress.XtraTreeList.TreeList treeMonHoc;
        private DevExpress.XtraEditors.LabelControl labelControlNamHoc;
        private DevExpress.XtraEditors.PanelControl panelControlChooseYear;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlHocKy;
        private DevExpress.XtraEditors.PanelControl panelControlRight;
        private DevExpress.XtraEditors.PanelControl panelControlLeft;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXuatBD;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditKhoiLop;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumntenLop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSiSo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSoLuongDat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTiLe;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGiaoVienCN;

    }
}