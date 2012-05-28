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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaoVien));
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.GridcontrolGiaoVien = new DevExpress.XtraGrid.GridControl();
            this.gridViewGiaoVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaGiaoVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TenGiaoVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.simpleButtonhuy = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTenGiaoVien = new DevExpress.XtraEditors.TextEdit();
            this.textEditMaGiaoVien = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonXoaGiaovien = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButonSuagiaovien = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonThemGiaoVien = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLuuGiaoVien = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonLoadlaidulieu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridcontrolGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenGiaoVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaGiaoVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.GridcontrolGiaoVien);
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(368, 508);
            this.panelControl3.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl4.Location = new System.Drawing.Point(43, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(258, 26);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Bảng danh sách giáo viên";
            // 
            // GridcontrolGiaoVien
            // 
            this.GridcontrolGiaoVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GridcontrolGiaoVien.Location = new System.Drawing.Point(0, 113);
            this.GridcontrolGiaoVien.MainView = this.gridViewGiaoVien;
            this.GridcontrolGiaoVien.Name = "GridcontrolGiaoVien";
            this.GridcontrolGiaoVien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1});
            this.GridcontrolGiaoVien.Size = new System.Drawing.Size(363, 390);
            this.GridcontrolGiaoVien.TabIndex = 8;
            this.GridcontrolGiaoVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGiaoVien});
            // 
            // gridViewGiaoVien
            // 
            this.gridViewGiaoVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaGiaoVien,
            this.TenGiaoVien});
            this.gridViewGiaoVien.GridControl = this.GridcontrolGiaoVien;
            this.gridViewGiaoVien.Name = "gridViewGiaoVien";
            this.gridViewGiaoVien.OptionsView.ShowGroupPanel = false;
            this.gridViewGiaoVien.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewGiaoVien_FocusedRowChanged);
            // 
            // MaGiaoVien
            // 
            this.MaGiaoVien.Caption = "Mã Giáo Viên";
            this.MaGiaoVien.ColumnEdit = this.repositoryItemTextEdit1;
            this.MaGiaoVien.FieldName = "MaGiaoVien";
            this.MaGiaoVien.MinWidth = 10;
            this.MaGiaoVien.Name = "MaGiaoVien";
            this.MaGiaoVien.OptionsColumn.ReadOnly = true;
            this.MaGiaoVien.Visible = true;
            this.MaGiaoVien.VisibleIndex = 0;
            this.MaGiaoVien.Width = 116;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // TenGiaoVien
            // 
            this.TenGiaoVien.Caption = "Tên Giáo Viên";
            this.TenGiaoVien.ColumnEdit = this.repositoryItemTextEdit1;
            this.TenGiaoVien.FieldName = "TenGiaoVien";
            this.TenGiaoVien.MinWidth = 25;
            this.TenGiaoVien.Name = "TenGiaoVien";
            this.TenGiaoVien.OptionsColumn.ReadOnly = true;
            this.TenGiaoVien.Visible = true;
            this.TenGiaoVien.VisibleIndex = 1;
            this.TenGiaoVien.Width = 348;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // simpleButtonhuy
            // 
            this.simpleButtonhuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonhuy.Image = global::QLHS.Properties.Resources.huy;
            this.simpleButtonhuy.Location = new System.Drawing.Point(344, 28);
            this.simpleButtonhuy.Name = "simpleButtonhuy";
            this.simpleButtonhuy.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonhuy.TabIndex = 5;
            this.simpleButtonhuy.Text = "Hủy thao tác";
            this.simpleButtonhuy.Click += new System.EventHandler(this.simpleButtonhuy_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(46, 154);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Tên giáo viên:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(46, 110);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Mã giáo viên:";
            // 
            // textEditTenGiaoVien
            // 
            this.textEditTenGiaoVien.Location = new System.Drawing.Point(135, 147);
            this.textEditTenGiaoVien.Name = "textEditTenGiaoVien";
            this.textEditTenGiaoVien.Size = new System.Drawing.Size(147, 20);
            this.textEditTenGiaoVien.TabIndex = 11;
            // 
            // textEditMaGiaoVien
            // 
            this.textEditMaGiaoVien.Location = new System.Drawing.Point(135, 103);
            this.textEditMaGiaoVien.Name = "textEditMaGiaoVien";
            this.textEditMaGiaoVien.Size = new System.Drawing.Size(147, 20);
            this.textEditMaGiaoVien.TabIndex = 10;
            // 
            // simpleButtonXoaGiaovien
            // 
            this.simpleButtonXoaGiaovien.Image = global::QLHS.Properties.Resources.xoa_small;
            this.simpleButtonXoaGiaovien.Location = new System.Drawing.Point(238, 209);
            this.simpleButtonXoaGiaovien.Name = "simpleButtonXoaGiaovien";
            this.simpleButtonXoaGiaovien.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonXoaGiaovien.TabIndex = 2;
            this.simpleButtonXoaGiaovien.Text = "Xóa giáo viên";
            this.simpleButtonXoaGiaovien.Click += new System.EventHandler(this.simpleButtonXoaGiaovien_Click);
            // 
            // simpleButonSuagiaovien
            // 
            this.simpleButonSuagiaovien.Image = ((System.Drawing.Image)(resources.GetObject("simpleButonSuagiaovien.Image")));
            this.simpleButonSuagiaovien.Location = new System.Drawing.Point(238, 278);
            this.simpleButonSuagiaovien.Name = "simpleButonSuagiaovien";
            this.simpleButonSuagiaovien.Size = new System.Drawing.Size(104, 35);
            this.simpleButonSuagiaovien.TabIndex = 3;
            this.simpleButonSuagiaovien.Text = "Sửa giáo viên";
            this.simpleButonSuagiaovien.Click += new System.EventHandler(this.simpleButonSuagiaovien_Click);
            // 
            // simpleButtonThemGiaoVien
            // 
            this.simpleButtonThemGiaoVien.Image = global::QLHS.Properties.Resources.them;
            this.simpleButtonThemGiaoVien.Location = new System.Drawing.Point(46, 209);
            this.simpleButtonThemGiaoVien.Name = "simpleButtonThemGiaoVien";
            this.simpleButtonThemGiaoVien.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonThemGiaoVien.TabIndex = 1;
            this.simpleButtonThemGiaoVien.Text = "Thêm giáo viên";
            this.simpleButtonThemGiaoVien.Click += new System.EventHandler(this.simpleButtonThemGiaoVien_Click);
            // 
            // simpleButtonLuuGiaoVien
            // 
            this.simpleButtonLuuGiaoVien.Image = global::QLHS.Properties.Resources.them_small;
            this.simpleButtonLuuGiaoVien.Location = new System.Drawing.Point(46, 278);
            this.simpleButtonLuuGiaoVien.Name = "simpleButtonLuuGiaoVien";
            this.simpleButtonLuuGiaoVien.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonLuuGiaoVien.TabIndex = 4;
            this.simpleButtonLuuGiaoVien.Text = "Lưu";
            this.simpleButtonLuuGiaoVien.ToolTip = "Lưu kết quả của các hành động thêm, sửa giáo viên";
            this.simpleButtonLuuGiaoVien.Click += new System.EventHandler(this.simpleButtonLuuGiaoVien_Click);
            // 
            // panelControl5
            // 
            this.panelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl5.Controls.Add(this.simpleButtonLuuGiaoVien);
            this.panelControl5.Controls.Add(this.simpleButonSuagiaovien);
            this.panelControl5.Controls.Add(this.labelControl3);
            this.panelControl5.Controls.Add(this.simpleButtonXoaGiaovien);
            this.panelControl5.Controls.Add(this.simpleButtonThemGiaoVien);
            this.panelControl5.Controls.Add(this.textEditMaGiaoVien);
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.textEditTenGiaoVien);
            this.panelControl5.Location = new System.Drawing.Point(369, 113);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(415, 395);
            this.panelControl5.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(784, 115);
            this.panelControl1.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Location = new System.Drawing.Point(475, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(193, 25);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Các thao tác chính";
            // 
            // simpleButtonLoadlaidulieu
            // 
            this.simpleButtonLoadlaidulieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonLoadlaidulieu.Image = global::QLHS.Properties.Resources.capnhat;
            this.simpleButtonLoadlaidulieu.Location = new System.Drawing.Point(491, 28);
            this.simpleButtonLoadlaidulieu.Name = "simpleButtonLoadlaidulieu";
            this.simpleButtonLoadlaidulieu.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonLoadlaidulieu.TabIndex = 6;
            this.simpleButtonLoadlaidulieu.Text = "Tải lại dữ liệu";
            this.simpleButtonLoadlaidulieu.ToolTip = "Load lại dữ liệu từ cơ sở dữ liệu";
            this.simpleButtonLoadlaidulieu.Click += new System.EventHandler(this.simpleButtonLoadlaidulieu_Click);
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = global::QLHS.Properties.Resources.thoat_small;
            this.simpleButtonThoat.Location = new System.Drawing.Point(645, 28);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonThoat.TabIndex = 7;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButtonThoat_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButtonThoat);
            this.panelControl2.Controls.Add(this.simpleButtonLoadlaidulieu);
            this.panelControl2.Controls.Add(this.simpleButtonhuy);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 506);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(784, 83);
            this.panelControl2.TabIndex = 10;
            // 
            // frmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 589);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl5);
            this.MaximizeBox = false;
            this.Name = "frmGiaoVien";
            this.Text = "Quản lý giáo viên";
            this.Load += new System.EventHandler(this.frmGiaoVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridcontrolGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenGiaoVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaGiaoVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.SimpleButton simpleButonSuagiaovien;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThemGiaoVien;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXoaGiaovien;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLuuGiaoVien;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditTenGiaoVien;
        private DevExpress.XtraEditors.TextEdit textEditMaGiaoVien;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLoadlaidulieu;
        private DevExpress.XtraEditors.SimpleButton simpleButtonhuy;
        private DevExpress.XtraGrid.GridControl GridcontrolGiaoVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGiaoVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaGiaoVien;
        private DevExpress.XtraGrid.Columns.GridColumn TenGiaoVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}