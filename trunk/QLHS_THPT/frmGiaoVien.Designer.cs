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
            this.GridcontrolGiaoVien = new DevExpress.XtraGrid.GridControl();
            this.gridViewGiaoVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaGiaoVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TenGiaoVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonLoadlaidulieu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenGiaoVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaGiaoVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridcontrolGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(91, 589);
            this.panelControl3.TabIndex = 1;
            // 
            // simpleButtonhuy
            // 
            this.simpleButtonhuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonhuy.Image = global::QLHS.Properties.Resources.huy;
            this.simpleButtonhuy.Location = new System.Drawing.Point(38, 25);
            this.simpleButtonhuy.Name = "simpleButtonhuy";
            this.simpleButtonhuy.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonhuy.TabIndex = 17;
            this.simpleButtonhuy.Text = "Hủy thao tác";
            this.simpleButtonhuy.Click += new System.EventHandler(this.simpleButtonhuy_Click_1);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(103, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Tên giáo viên:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(416, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Mã giáo viên:";
            // 
            // textEditTenGiaoVien
            // 
            this.textEditTenGiaoVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditTenGiaoVien.Location = new System.Drawing.Point(213, 71);
            this.textEditTenGiaoVien.Name = "textEditTenGiaoVien";
            this.textEditTenGiaoVien.Size = new System.Drawing.Size(154, 20);
            this.textEditTenGiaoVien.TabIndex = 11;
            // 
            // textEditMaGiaoVien
            // 
            this.textEditMaGiaoVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditMaGiaoVien.Location = new System.Drawing.Point(505, 67);
            this.textEditMaGiaoVien.Name = "textEditMaGiaoVien";
            this.textEditMaGiaoVien.Size = new System.Drawing.Size(154, 20);
            this.textEditMaGiaoVien.TabIndex = 10;
            // 
            // simpleButtonXoaGiaovien
            // 
            this.simpleButtonXoaGiaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonXoaGiaovien.Image = global::QLHS.Properties.Resources.xoa_small;
            this.simpleButtonXoaGiaovien.Location = new System.Drawing.Point(174, 25);
            this.simpleButtonXoaGiaovien.Name = "simpleButtonXoaGiaovien";
            this.simpleButtonXoaGiaovien.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonXoaGiaovien.TabIndex = 2;
            this.simpleButtonXoaGiaovien.Text = "Xóa giáo viên";
            this.simpleButtonXoaGiaovien.Click += new System.EventHandler(this.simpleButtonXoaGiaovien_Click);
            // 
            // simpleButonSuagiaovien
            // 
            this.simpleButonSuagiaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButonSuagiaovien.Image = ((System.Drawing.Image)(resources.GetObject("simpleButonSuagiaovien.Image")));
            this.simpleButonSuagiaovien.Location = new System.Drawing.Point(19, 75);
            this.simpleButonSuagiaovien.Name = "simpleButonSuagiaovien";
            this.simpleButonSuagiaovien.Size = new System.Drawing.Size(104, 35);
            this.simpleButonSuagiaovien.TabIndex = 1;
            this.simpleButonSuagiaovien.Text = "Sửa giáo viên";
            this.simpleButonSuagiaovien.Click += new System.EventHandler(this.simpleButonSuagiaovien_Click);
            // 
            // simpleButtonThemGiaoVien
            // 
            this.simpleButtonThemGiaoVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThemGiaoVien.Image = global::QLHS.Properties.Resources.them;
            this.simpleButtonThemGiaoVien.Location = new System.Drawing.Point(19, 25);
            this.simpleButtonThemGiaoVien.Name = "simpleButtonThemGiaoVien";
            this.simpleButtonThemGiaoVien.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonThemGiaoVien.TabIndex = 0;
            this.simpleButtonThemGiaoVien.Text = "Thêm giáo viên";
            this.simpleButtonThemGiaoVien.Click += new System.EventHandler(this.simpleButtonThemGiaoVien_Click);
            // 
            // simpleButtonLuuGiaoVien
            // 
            this.simpleButtonLuuGiaoVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonLuuGiaoVien.Image = global::QLHS.Properties.Resources.them_small;
            this.simpleButtonLuuGiaoVien.Location = new System.Drawing.Point(174, 75);
            this.simpleButtonLuuGiaoVien.Name = "simpleButtonLuuGiaoVien";
            this.simpleButtonLuuGiaoVien.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonLuuGiaoVien.TabIndex = 9;
            this.simpleButtonLuuGiaoVien.Text = "Lưu";
            this.simpleButtonLuuGiaoVien.ToolTip = "Lưu kết quả của các hành động thêm, sửa giáo viên";
            this.simpleButtonLuuGiaoVien.Click += new System.EventHandler(this.simpleButtonLuuGiaoVien_Click);
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.GridcontrolGiaoVien);
            this.panelControl5.Controls.Add(this.panelControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(91, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(693, 589);
            this.panelControl5.TabIndex = 3;
            // 
            // GridcontrolGiaoVien
            // 
            this.GridcontrolGiaoVien.Location = new System.Drawing.Point(5, 314);
            this.GridcontrolGiaoVien.MainView = this.gridViewGiaoVien;
            this.GridcontrolGiaoVien.Name = "GridcontrolGiaoVien";
            this.GridcontrolGiaoVien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1});
            this.GridcontrolGiaoVien.Size = new System.Drawing.Size(688, 357);
            this.GridcontrolGiaoVien.TabIndex = 11;
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
            this.MaGiaoVien.Name = "MaGiaoVien";
            this.MaGiaoVien.OptionsColumn.ReadOnly = true;
            this.MaGiaoVien.Visible = true;
            this.MaGiaoVien.VisibleIndex = 0;
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
            this.TenGiaoVien.Name = "TenGiaoVien";
            this.TenGiaoVien.OptionsColumn.ReadOnly = true;
            this.TenGiaoVien.Visible = true;
            this.TenGiaoVien.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.textEditTenGiaoVien);
            this.panelControl1.Controls.Add(this.textEditMaGiaoVien);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(689, 270);
            this.panelControl1.TabIndex = 9;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonThemGiaoVien);
            this.groupControl1.Controls.Add(this.simpleButonSuagiaovien);
            this.groupControl1.Controls.Add(this.simpleButtonXoaGiaovien);
            this.groupControl1.Controls.Add(this.simpleButtonLuuGiaoVien);
            this.groupControl1.Location = new System.Drawing.Point(16, 122);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(318, 116);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "groupControl1";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // simpleButtonLoadlaidulieu
            // 
            this.simpleButtonLoadlaidulieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonLoadlaidulieu.Image = global::QLHS.Properties.Resources.capnhat;
            this.simpleButtonLoadlaidulieu.Location = new System.Drawing.Point(38, 81);
            this.simpleButtonLoadlaidulieu.Name = "simpleButtonLoadlaidulieu";
            this.simpleButtonLoadlaidulieu.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonLoadlaidulieu.TabIndex = 9;
            this.simpleButtonLoadlaidulieu.Text = "Tải lại dữ liệu";
            this.simpleButtonLoadlaidulieu.ToolTip = "Load lại dữ liệu từ cơ sở dữ liệu";
            this.simpleButtonLoadlaidulieu.Click += new System.EventHandler(this.simpleButtonLoadlaidulieu_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(224, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(245, 27);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Bảng danh sách giáo viên";
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = global::QLHS.Properties.Resources.thoat_small;
            this.simpleButtonThoat.Location = new System.Drawing.Point(154, 81);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(104, 35);
            this.simpleButtonThoat.TabIndex = 8;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButtonThoat_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButtonLoadlaidulieu);
            this.groupControl2.Controls.Add(this.simpleButtonThoat);
            this.groupControl2.Controls.Add(this.simpleButtonhuy);
            this.groupControl2.Location = new System.Drawing.Point(378, 122);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(281, 116);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "groupControl2";
            this.groupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl2_Paint);
            // 
            // frmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 589);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl3);
            this.MaximizeBox = false;
            this.Name = "frmGiaoVien";
            this.Text = "Quản lý giáo viên";
            this.Load += new System.EventHandler(this.frmGiaoVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenGiaoVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaGiaoVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridcontrolGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}