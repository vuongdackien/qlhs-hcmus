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
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridViewQuyDinh.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewQuyDinh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewQuyDinh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewQuyDinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Khoa,
            this.GiaTri});
            this.gridViewQuyDinh.GridControl = this.gridControlQuyDinh;
            this.gridViewQuyDinh.Name = "gridViewQuyDinh";
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