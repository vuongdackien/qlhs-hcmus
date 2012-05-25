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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuyDinh));
            this.gridControlQuyDinh = new DevExpress.XtraGrid.GridControl();
            this.gridViewQuyDinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Khoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.GiaTri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController2 = new DevExpress.Utils.ToolTipController(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonLoaddulieu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSuaQuyDinh = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlQuyDinh
            // 
            this.gridControlQuyDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQuyDinh.Location = new System.Drawing.Point(0, 100);
            this.gridControlQuyDinh.MainView = this.gridViewQuyDinh;
            this.gridControlQuyDinh.Name = "gridControlQuyDinh";
            this.gridControlQuyDinh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridControlQuyDinh.Size = new System.Drawing.Size(647, 300);
            this.gridControlQuyDinh.TabIndex = 0;
            this.gridControlQuyDinh.ToolTipController = this.toolTipController2;
            this.gridControlQuyDinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQuyDinh});
            // 
            // gridViewQuyDinh
            // 
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewQuyDinh.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewQuyDinh.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(173)))));
            this.gridViewQuyDinh.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(173)))));
            this.gridViewQuyDinh.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(159)))), ((int)(((byte)(69)))));
            this.gridViewQuyDinh.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(152)))), ((int)(((byte)(49)))));
            this.gridViewQuyDinh.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(167)))), ((int)(((byte)(62)))));
            this.gridViewQuyDinh.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.GroupPanel.Image = ((System.Drawing.Image)(resources.GetObject("gridViewQuyDinh.Appearance.GroupPanel.Image")));
            this.gridViewQuyDinh.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.GroupPanel.Options.UseImage = true;
            this.gridViewQuyDinh.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(115)))));
            this.gridViewQuyDinh.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(115)))));
            this.gridViewQuyDinh.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(176)))), ((int)(((byte)(84)))));
            this.gridViewQuyDinh.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewQuyDinh.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(163)))));
            this.gridViewQuyDinh.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.gridViewQuyDinh.Appearance.Preview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.gridViewQuyDinh.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridViewQuyDinh.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(177)))), ((int)(((byte)(90)))));
            this.gridViewQuyDinh.Appearance.Preview.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.Preview.Options.UseBorderColor = true;
            this.gridViewQuyDinh.Appearance.Preview.Options.UseFont = true;
            this.gridViewQuyDinh.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(173)))));
            this.gridViewQuyDinh.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridViewQuyDinh.Appearance.Row.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.Row.Options.UseForeColor = true;
            this.gridViewQuyDinh.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(229)))), ((int)(((byte)(128)))));
            this.gridViewQuyDinh.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(167)))), ((int)(((byte)(62)))));
            this.gridViewQuyDinh.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridViewQuyDinh.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(194)))), ((int)(((byte)(102)))));
            this.gridViewQuyDinh.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewQuyDinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Khoa,
            this.GiaTri});
            this.gridViewQuyDinh.GridControl = this.gridControlQuyDinh;
            this.gridViewQuyDinh.Name = "gridViewQuyDinh";
            this.gridViewQuyDinh.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewQuyDinh.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewQuyDinh.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewQuyDinh_CellValueChanged);
            // 
            // Khoa
            // 
            this.Khoa.Caption = "Quy định";
            this.Khoa.ColumnEdit = this.repositoryItemTextEdit2;
            this.Khoa.FieldName = "Khoa";
            this.Khoa.Name = "Khoa";
            this.Khoa.OptionsColumn.ReadOnly = true;
            this.Khoa.ToolTip = "Các quy định";
            this.Khoa.Visible = true;
            this.Khoa.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // GiaTri
            // 
            this.GiaTri.Caption = "Giá trị";
            this.GiaTri.ColumnEdit = this.repositoryItemTextEdit1;
            this.GiaTri.FieldName = "GiaTri";
            this.GiaTri.Name = "GiaTri";
            this.GiaTri.Visible = true;
            this.GiaTri.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // toolTipController2
            // 
            this.toolTipController2.ShowBeak = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(647, 100);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(125, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(336, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "________________________________________________";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Location = new System.Drawing.Point(194, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(170, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Bảng quy định";
            // 
            // panelControl2
            // 
            this.panelControl2.AutoSize = true;
            this.panelControl2.Controls.Add(this.simpleButtonLoaddulieu);
            this.panelControl2.Controls.Add(this.simpleButtonThoat);
            this.panelControl2.Controls.Add(this.simpleButtonSuaQuyDinh);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 400);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(647, 72);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButtonLoaddulieu
            // 
            this.simpleButtonLoaddulieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonLoaddulieu.Image = global::QLHS.Properties.Resources.capnhat;
            this.simpleButtonLoaddulieu.Location = new System.Drawing.Point(345, 26);
            this.simpleButtonLoaddulieu.Name = "simpleButtonLoaddulieu";
            this.simpleButtonLoaddulieu.Size = new System.Drawing.Size(116, 39);
            this.simpleButtonLoaddulieu.TabIndex = 0;
            this.simpleButtonLoaddulieu.Text = "Tải dữ liệu mới";
            this.simpleButtonLoaddulieu.ToolTip = "Tải dữ liệu mới từ cơ sở dữ liệu";
            this.simpleButtonLoaddulieu.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.simpleButtonLoaddulieu.ToolTipTitle = "Tải dữ liệu mới";
            this.simpleButtonLoaddulieu.Click += new System.EventHandler(this.simpleButtonLoaddulieu_Click);
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = global::QLHS.Properties.Resources.thoat;
            this.simpleButtonThoat.Location = new System.Drawing.Point(507, 26);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(116, 39);
            this.simpleButtonThoat.TabIndex = 0;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButtonThoat_Click);
            // 
            // simpleButtonSuaQuyDinh
            // 
            this.simpleButtonSuaQuyDinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSuaQuyDinh.Image = global::QLHS.Properties.Resources.monhoc;
            this.simpleButtonSuaQuyDinh.Location = new System.Drawing.Point(170, 26);
            this.simpleButtonSuaQuyDinh.Name = "simpleButtonSuaQuyDinh";
            this.simpleButtonSuaQuyDinh.Size = new System.Drawing.Size(116, 39);
            this.simpleButtonSuaQuyDinh.TabIndex = 0;
            this.simpleButtonSuaQuyDinh.Text = "Sửa quy định";
            this.simpleButtonSuaQuyDinh.ToolTip = "Sửa các quy định hiện hành";
            this.simpleButtonSuaQuyDinh.ToolTipController = this.toolTipController1;
            this.simpleButtonSuaQuyDinh.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.simpleButtonSuaQuyDinh.ToolTipTitle = "Sửa quy định";
            this.simpleButtonSuaQuyDinh.Click += new System.EventHandler(this.simpleButtonSuaQuyDinh_Click);
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(647, 472);
            this.Controls.Add(this.gridControlQuyDinh);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.MaximizeBox = false;
            this.Name = "frmQuyDinh";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quy định";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Load += new System.EventHandler(this.frmQuyDinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlQuyDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQuyDinh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLoaddulieu;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSuaQuyDinh;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn Khoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn GiaTri;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.Utils.ToolTipController toolTipController2;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}