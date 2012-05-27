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
            this.label2.Location = new System.Drawing.Point(112, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(553, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "_________________________________________________________________________________" +
                "__________";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Location = new System.Drawing.Point(277, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(238, 26);
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
            this.gridViewMonHoc.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewMonHoc.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewMonHoc.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(173)))));
            this.gridViewMonHoc.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(173)))));
            this.gridViewMonHoc.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(159)))), ((int)(((byte)(69)))));
            this.gridViewMonHoc.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(152)))), ((int)(((byte)(49)))));
            this.gridViewMonHoc.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(167)))), ((int)(((byte)(62)))));
            this.gridViewMonHoc.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(115)))));
            this.gridViewMonHoc.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(115)))));
            this.gridViewMonHoc.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(176)))), ((int)(((byte)(84)))));
            this.gridViewMonHoc.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewMonHoc.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewMonHoc.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.gridViewMonHoc.Appearance.Preview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.gridViewMonHoc.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridViewMonHoc.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(177)))), ((int)(((byte)(90)))));
            this.gridViewMonHoc.Appearance.Preview.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.Preview.Options.UseBorderColor = true;
            this.gridViewMonHoc.Appearance.Preview.Options.UseFont = true;
            this.gridViewMonHoc.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(173)))));
            this.gridViewMonHoc.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridViewMonHoc.Appearance.Row.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.Row.Options.UseForeColor = true;
            this.gridViewMonHoc.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewMonHoc.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(167)))), ((int)(((byte)(62)))));
            this.gridViewMonHoc.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridViewMonHoc.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewMonHoc.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewMonHoc.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaMonHoc,
            this.TenMonHoc,
            this.SoTiet,
            this.HeSo,
            this.TrangThai});
            this.gridViewMonHoc.GridControl = this.gridControlMonHoc;
            this.gridViewMonHoc.Name = "gridViewMonHoc";
            this.gridViewMonHoc.OptionsDetail.EnableDetailToolTip = true;
            this.gridViewMonHoc.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMonHoc.OptionsView.EnableAppearanceOddRow = true;
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
            this.TenMonHoc.Visible = true;
            this.TenMonHoc.VisibleIndex = 1;
            // 
            // SoTiet
            // 
            this.SoTiet.Caption = "Số tiết";
            this.SoTiet.ColumnEdit = this.repositoryItemTextEdit4;
            this.SoTiet.FieldName = "SoTiet";
            this.SoTiet.Name = "SoTiet";
            this.SoTiet.ToolTip = "Thay đổi số tiết học của môn học. Bạn chỉ có thể nhập số, không được nhập kí tự k" +
                "hác.";
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
            this.HeSo.ToolTip = "Thay đổi hệ số của môn học  Bạn chỉ có thể nhập số, không được nhập kí tự khác.";
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
            this.TrangThai.MaxWidth = 15;
            this.TrangThai.MinWidth = 10;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.OptionsColumn.AllowShowHide = false;
            this.TrangThai.OptionsColumn.AllowSize = false;
            this.TrangThai.ToolTip = "Thay đổi trạng thái của môn học: 1: có, 0: không.  Bạn chỉ có thể nhập số, không " +
                "được nhập kí tự khác.";
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 4;
            this.TrangThai.Width = 15;
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