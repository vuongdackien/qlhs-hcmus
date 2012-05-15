namespace QLHS
{
    partial class frmGiaoVien
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
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateEditNgaySinh = new DevExpress.XtraEditors.DateEdit();
            this.textEditDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.textEditNoiSinh = new DevExpress.XtraEditors.TextEdit();
            this.panelControlChiTietHoSo = new DevExpress.XtraEditors.PanelControl();
            this.textEditEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupGioiTinh = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditSTTSoDiem = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTenHocSinh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textEditmaHocSinh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumnMaGiaoVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumntenGiaoVien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgaySinh.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgaySinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNoiSinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlChiTietHoSo)).BeginInit();
            this.panelControlChiTietHoSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupGioiTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditSTTSoDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenHocSinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmaHocSinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panelControlChiTietHoSo);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(773, 144);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.gridControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 144);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(773, 266);
            this.panelControl5.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(767, 260);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnMaGiaoVien,
            this.gridColumntenGiaoVien});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // dateEditNgaySinh
            // 
            this.dateEditNgaySinh.EditValue = null;
            this.dateEditNgaySinh.Location = new System.Drawing.Point(83, 140);
            this.dateEditNgaySinh.Name = "dateEditNgaySinh";
            this.dateEditNgaySinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditNgaySinh.Properties.MinValue = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dateEditNgaySinh.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditNgaySinh.Size = new System.Drawing.Size(136, 20);
            this.dateEditNgaySinh.TabIndex = 9;
            // 
            // textEditDiaChi
            // 
            this.textEditDiaChi.EditValue = "";
            this.textEditDiaChi.Location = new System.Drawing.Point(82, 229);
            this.textEditDiaChi.Name = "textEditDiaChi";
            this.textEditDiaChi.Properties.NullText = "Địa chỉ có thể bỏ trống";
            this.textEditDiaChi.Size = new System.Drawing.Size(206, 20);
            this.textEditDiaChi.TabIndex = 12;
            // 
            // textEditNoiSinh
            // 
            this.textEditNoiSinh.EditValue = "";
            this.textEditNoiSinh.Location = new System.Drawing.Point(82, 197);
            this.textEditNoiSinh.Name = "textEditNoiSinh";
            this.textEditNoiSinh.Properties.NullText = "Nơi sinh có thể bỏ trống";
            this.textEditNoiSinh.Size = new System.Drawing.Size(206, 20);
            this.textEditNoiSinh.TabIndex = 11;
            // 
            // panelControlChiTietHoSo
            // 
            this.panelControlChiTietHoSo.Controls.Add(this.dateEditNgaySinh);
            this.panelControlChiTietHoSo.Controls.Add(this.textEditDiaChi);
            this.panelControlChiTietHoSo.Controls.Add(this.textEditNoiSinh);
            this.panelControlChiTietHoSo.Controls.Add(this.textEditEmail);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl12);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl11);
            this.panelControlChiTietHoSo.Controls.Add(this.radioGroupGioiTinh);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl10);
            this.panelControlChiTietHoSo.Controls.Add(this.spinEditSTTSoDiem);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl9);
            this.panelControlChiTietHoSo.Controls.Add(this.textEditTenHocSinh);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl8);
            this.panelControlChiTietHoSo.Controls.Add(this.textEditmaHocSinh);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl7);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl6);
            this.panelControlChiTietHoSo.Controls.Add(this.labelControl5);
            this.panelControlChiTietHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlChiTietHoSo.Location = new System.Drawing.Point(3, 3);
            this.panelControlChiTietHoSo.Name = "panelControlChiTietHoSo";
            this.panelControlChiTietHoSo.Size = new System.Drawing.Size(767, 138);
            this.panelControlChiTietHoSo.TabIndex = 4;
            // 
            // textEditEmail
            // 
            this.textEditEmail.EditValue = "";
            this.textEditEmail.Location = new System.Drawing.Point(82, 167);
            this.textEditEmail.Name = "textEditEmail";
            this.textEditEmail.Properties.Mask.EditMask = "[a-z0-9._%-]+@[a-z0-9.-]+\\.[a-z]{2,4}";
            this.textEditEmail.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditEmail.Properties.NullText = "Email có thể bỏ trống";
            this.textEditEmail.Size = new System.Drawing.Size(206, 20);
            this.textEditEmail.TabIndex = 10;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(25, 232);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(36, 13);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Địa chỉ:";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(25, 200);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(41, 13);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Nơi sinh:";
            // 
            // radioGroupGioiTinh
            // 
            this.radioGroupGioiTinh.EditValue = ((byte)(0));
            this.radioGroupGioiTinh.Location = new System.Drawing.Point(348, 25);
            this.radioGroupGioiTinh.Name = "radioGroupGioiTinh";
            this.radioGroupGioiTinh.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(0)), "Nam"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "Nữ")});
            this.radioGroupGioiTinh.Size = new System.Drawing.Size(137, 22);
            this.radioGroupGioiTinh.TabIndex = 8;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(25, 170);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(28, 13);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Email:";
            // 
            // spinEditSTTSoDiem
            // 
            this.spinEditSTTSoDiem.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditSTTSoDiem.Location = new System.Drawing.Point(210, 27);
            this.spinEditSTTSoDiem.Name = "spinEditSTTSoDiem";
            this.spinEditSTTSoDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditSTTSoDiem.Properties.EditValueChangedDelay = 1;
            this.spinEditSTTSoDiem.Properties.IsFloatValue = false;
            this.spinEditSTTSoDiem.Properties.Mask.BeepOnError = true;
            this.spinEditSTTSoDiem.Properties.Mask.EditMask = "\\d{1,2}";
            this.spinEditSTTSoDiem.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEditSTTSoDiem.Properties.MaxLength = 2;
            this.spinEditSTTSoDiem.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.spinEditSTTSoDiem.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditSTTSoDiem.Size = new System.Drawing.Size(78, 20);
            this.spinEditSTTSoDiem.TabIndex = 6;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(25, 143);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(51, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Ngày sinh:";
            // 
            // textEditTenHocSinh
            // 
            this.textEditTenHocSinh.Location = new System.Drawing.Point(27, 84);
            this.textEditTenHocSinh.Name = "textEditTenHocSinh";
            this.textEditTenHocSinh.Size = new System.Drawing.Size(263, 20);
            this.textEditTenHocSinh.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(25, 110);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(42, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Giới tính:";
            // 
            // textEditmaHocSinh
            // 
            this.textEditmaHocSinh.Enabled = false;
            this.textEditmaHocSinh.Location = new System.Drawing.Point(25, 27);
            this.textEditmaHocSinh.Name = "textEditmaHocSinh";
            this.textEditmaHocSinh.Size = new System.Drawing.Size(141, 20);
            this.textEditmaHocSinh.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(27, 58);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(64, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Tên học sinh:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(210, 8);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "STT Sổ điểm:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Mã học sinh:";
            // 
            // gridColumnMaGiaoVien
            // 
            this.gridColumnMaGiaoVien.Caption = "Mã giáo viên";
            this.gridColumnMaGiaoVien.FieldName = "MaGiaoVien";
            this.gridColumnMaGiaoVien.Name = "gridColumnMaGiaoVien";
            this.gridColumnMaGiaoVien.Visible = true;
            this.gridColumnMaGiaoVien.VisibleIndex = 0;
            this.gridColumnMaGiaoVien.Width = 90;
            // 
            // gridColumntenGiaoVien
            // 
            this.gridColumntenGiaoVien.Caption = "Tên giáo viên";
            this.gridColumntenGiaoVien.FieldName = "TenGiaoVien";
            this.gridColumntenGiaoVien.Name = "gridColumntenGiaoVien";
            this.gridColumntenGiaoVien.Visible = true;
            this.gridColumntenGiaoVien.VisibleIndex = 1;
            this.gridColumntenGiaoVien.Width = 656;
            // 
            // frmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 410);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl3);
            this.Name = "frmGiaoVien";
            this.Text = "Quản lý giáo viên";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgaySinh.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgaySinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNoiSinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlChiTietHoSo)).EndInit();
            this.panelControlChiTietHoSo.ResumeLayout(false);
            this.panelControlChiTietHoSo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupGioiTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditSTTSoDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenHocSinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmaHocSinh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControlChiTietHoSo;
        private DevExpress.XtraEditors.DateEdit dateEditNgaySinh;
        private DevExpress.XtraEditors.TextEdit textEditDiaChi;
        private DevExpress.XtraEditors.TextEdit textEditNoiSinh;
        private DevExpress.XtraEditors.TextEdit textEditEmail;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.RadioGroup radioGroupGioiTinh;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SpinEdit spinEditSTTSoDiem;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit textEditTenHocSinh;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit textEditmaHocSinh;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMaGiaoVien;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumntenGiaoVien;
    }
}