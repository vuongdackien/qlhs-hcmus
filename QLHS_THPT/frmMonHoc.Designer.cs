namespace QLHS
{
    partial class frmMonHoc
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonloaddulieu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSuaMonHoc = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlMonHoc = new DevExpress.XtraGrid.GridControl();
            this.gridViewMonHoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaMonHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TenMonHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTiet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.HeSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonThoat);
            this.panelControl1.Controls.Add(this.simpleButtonloaddulieu);
            this.panelControl1.Controls.Add(this.simpleButtonSuaMonHoc);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 590);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(780, 118);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Image = global::QLHS.Properties.Resources.thoat_small;
            this.simpleButtonThoat.Location = new System.Drawing.Point(618, 24);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(120, 35);
            this.simpleButtonThoat.TabIndex = 0;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButtonThoat_Click);
            // 
            // simpleButtonloaddulieu
            // 
            this.simpleButtonloaddulieu.Image = global::QLHS.Properties.Resources.capnhat;
            this.simpleButtonloaddulieu.Location = new System.Drawing.Point(474, 24);
            this.simpleButtonloaddulieu.Name = "simpleButtonloaddulieu";
            this.simpleButtonloaddulieu.Size = new System.Drawing.Size(120, 35);
            this.simpleButtonloaddulieu.TabIndex = 1;
            this.simpleButtonloaddulieu.Text = "Tải lại dữ liệu";
            this.simpleButtonloaddulieu.Click += new System.EventHandler(this.simpleButtonloaddulieu_Click);
            // 
            // simpleButtonSuaMonHoc
            // 
            this.simpleButtonSuaMonHoc.Image = global::QLHS.Properties.Resources.capnhat;
            this.simpleButtonSuaMonHoc.Location = new System.Drawing.Point(330, 24);
            this.simpleButtonSuaMonHoc.Name = "simpleButtonSuaMonHoc";
            this.simpleButtonSuaMonHoc.Size = new System.Drawing.Size(120, 35);
            this.simpleButtonSuaMonHoc.TabIndex = 2;
            this.simpleButtonSuaMonHoc.Text = "Cập nhật môn học";
            this.simpleButtonSuaMonHoc.Click += new System.EventHandler(this.simpleButtonSuaMonHoc_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(780, 89);
            this.panelControl2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(625, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "_________________________________________________________________________________" +
                "______________________";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.labelControl1.Location = new System.Drawing.Point(149, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(229, 27);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Danh sách các môn học";
            // 
            // gridControlMonHoc
            // 
            this.gridControlMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMonHoc.Location = new System.Drawing.Point(0, 89);
            this.gridControlMonHoc.MainView = this.gridViewMonHoc;
            this.gridControlMonHoc.Name = "gridControlMonHoc";
            this.gridControlMonHoc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemComboBox1});
            this.gridControlMonHoc.Size = new System.Drawing.Size(780, 501);
            this.gridControlMonHoc.TabIndex = 2;
            this.gridControlMonHoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMonHoc});
            // 
            // gridViewMonHoc
            // 
            this.gridViewMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaMonHoc,
            this.TenMonHoc,
            this.SoTiet,
            this.HeSo,
            this.TrangThai});
            this.gridViewMonHoc.GridControl = this.gridControlMonHoc;
            this.gridViewMonHoc.Name = "gridViewMonHoc";
            this.gridViewMonHoc.OptionsView.ShowGroupPanel = false;
            this.gridViewMonHoc.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewMonHoc_CellValueChanged_1);
            // 
            // MaMonHoc
            // 
            this.MaMonHoc.Caption = "Mã môn học";
            this.MaMonHoc.ColumnEdit = this.repositoryItemTextEdit1;
            this.MaMonHoc.FieldName = "MaMonHoc";
            this.MaMonHoc.Name = "MaMonHoc";
            this.MaMonHoc.OptionsColumn.ReadOnly = true;
            this.MaMonHoc.Visible = true;
            this.MaMonHoc.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.Caption = "Tên môn học";
            this.TenMonHoc.ColumnEdit = this.repositoryItemTextEdit1;
            this.TenMonHoc.FieldName = "TenMonHoc";
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.OptionsColumn.ReadOnly = true;
            this.TenMonHoc.Visible = true;
            this.TenMonHoc.VisibleIndex = 1;
            // 
            // SoTiet
            // 
            this.SoTiet.Caption = "Số tiết";
            this.SoTiet.ColumnEdit = this.repositoryItemTextEdit4;
            this.SoTiet.FieldName = "SoTiet";
            this.SoTiet.Name = "SoTiet";
            this.SoTiet.Visible = true;
            this.SoTiet.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // HeSo
            // 
            this.HeSo.Caption = "Hệ số";
            this.HeSo.ColumnEdit = this.repositoryItemTextEdit2;
            this.HeSo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.HeSo.FieldName = "HeSo";
            this.HeSo.Name = "HeSo";
            this.HeSo.Visible = true;
            this.HeSo.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // TrangThai
            // 
            this.TrangThai.Caption = "Trạng thái";
            this.TrangThai.ColumnEdit = this.repositoryItemComboBox1;
            this.TrangThai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.OptionsColumn.AllowSize = false;
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 4;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.DropDownItemHeight = 20;
            this.repositoryItemComboBox1.DropDownRows = 10;
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // frmMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 708);
            this.Controls.Add(this.gridControlMonHoc);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "frmMonHoc";
            this.Text = "Quản lý môn học";
            this.Load += new System.EventHandler(this.frmMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSuaMonHoc;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlMonHoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn MaMonHoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn TenMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn SoTiet;
        private DevExpress.XtraGrid.Columns.GridColumn HeSo;
        private DevExpress.XtraEditors.SimpleButton simpleButtonloaddulieu;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}