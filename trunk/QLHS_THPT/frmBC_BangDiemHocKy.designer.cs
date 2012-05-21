namespace QLHS
{
    partial class frmBC_BangDiemHocKy
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
            this.panelControlLeft = new DevExpress.XtraEditors.PanelControl();
            this.treeListLopHoc = new DevExpress.XtraTreeList.TreeList();
            this.panelControlChooseYear = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditNamHoc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditHocKy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControlRight = new DevExpress.XtraEditors.PanelControl();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelControlTopRight = new DevExpress.XtraEditors.PanelControl();
            this.labelControlGVCN = new DevExpress.XtraEditors.LabelControl();
            this.labelControlLop = new DevExpress.XtraEditors.LabelControl();
            this.labelControlHocKy = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNamHoc = new DevExpress.XtraEditors.LabelControl();
            this.labelControlGVCNTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlHocKyTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlLopTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNamHocTT = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTitle = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).BeginInit();
            this.panelControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLopHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlChooseYear)).BeginInit();
            this.panelControlChooseYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNamHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHocKy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRight)).BeginInit();
            this.panelControlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTopRight)).BeginInit();
            this.panelControlTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControlLeft
            // 
            this.panelControlLeft.Controls.Add(this.treeListLopHoc);
            this.panelControlLeft.Controls.Add(this.panelControlChooseYear);
            this.panelControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlLeft.Location = new System.Drawing.Point(0, 0);
            this.panelControlLeft.Name = "panelControlLeft";
            this.panelControlLeft.Size = new System.Drawing.Size(182, 402);
            this.panelControlLeft.TabIndex = 0;
            // 
            // treeListLopHoc
            // 
            this.treeListLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLopHoc.Location = new System.Drawing.Point(3, 109);
            this.treeListLopHoc.Name = "treeListLopHoc";
            this.treeListLopHoc.OptionsBehavior.Editable = false;
            this.treeListLopHoc.OptionsView.ShowColumns = false;
            this.treeListLopHoc.OptionsView.ShowIndicator = false;
            this.treeListLopHoc.Size = new System.Drawing.Size(176, 290);
            this.treeListLopHoc.TabIndex = 1;
            this.treeListLopHoc.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListLopHoc_FocusedNodeChanged);
            // 
            // panelControlChooseYear
            // 
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditNamHoc);
            this.panelControlChooseYear.Controls.Add(this.comboBoxEditHocKy);
            this.panelControlChooseYear.Controls.Add(this.labelControl3);
            this.panelControlChooseYear.Controls.Add(this.labelControl1);
            this.panelControlChooseYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlChooseYear.Location = new System.Drawing.Point(3, 3);
            this.panelControlChooseYear.Name = "panelControlChooseYear";
            this.panelControlChooseYear.Size = new System.Drawing.Size(176, 106);
            this.panelControlChooseYear.TabIndex = 0;
            // 
            // comboBoxEditNamHoc
            // 
            this.comboBoxEditNamHoc.Location = new System.Drawing.Point(10, 28);
            this.comboBoxEditNamHoc.Name = "comboBoxEditNamHoc";
            this.comboBoxEditNamHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNamHoc.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditNamHoc.TabIndex = 4;
            this.comboBoxEditNamHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditNamHoc_SelectedIndexChanged);
            // 
            // comboBoxEditHocKy
            // 
            this.comboBoxEditHocKy.Location = new System.Drawing.Point(10, 71);
            this.comboBoxEditHocKy.Name = "comboBoxEditHocKy";
            this.comboBoxEditHocKy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditHocKy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditHocKy.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditHocKy.TabIndex = 5;
            this.comboBoxEditHocKy.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditHocKy_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Chọn năm học:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Chọn học kỳ";
            // 
            // panelControlRight
            // 
            this.panelControlRight.Controls.Add(this.crystalReportViewer1);
            this.panelControlRight.Controls.Add(this.panelControlTopRight);
            this.panelControlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlRight.Location = new System.Drawing.Point(182, 0);
            this.panelControlRight.Name = "panelControlRight";
            this.panelControlRight.Size = new System.Drawing.Size(995, 402);
            this.panelControlRight.TabIndex = 1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 83);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(989, 316);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // panelControlTopRight
            // 
            this.panelControlTopRight.Controls.Add(this.simpleButton1);
            this.panelControlTopRight.Controls.Add(this.labelControlGVCN);
            this.panelControlTopRight.Controls.Add(this.labelControlLop);
            this.panelControlTopRight.Controls.Add(this.labelControlHocKy);
            this.panelControlTopRight.Controls.Add(this.labelControlNamHoc);
            this.panelControlTopRight.Controls.Add(this.labelControlGVCNTT);
            this.panelControlTopRight.Controls.Add(this.labelControlHocKyTT);
            this.panelControlTopRight.Controls.Add(this.labelControlLopTT);
            this.panelControlTopRight.Controls.Add(this.labelControlNamHocTT);
            this.panelControlTopRight.Controls.Add(this.labelControlTitle);
            this.panelControlTopRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlTopRight.Location = new System.Drawing.Point(3, 3);
            this.panelControlTopRight.Name = "panelControlTopRight";
            this.panelControlTopRight.Size = new System.Drawing.Size(989, 80);
            this.panelControlTopRight.TabIndex = 0;
            // 
            // labelControlGVCN
            // 
            this.labelControlGVCN.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelControlGVCN.Location = new System.Drawing.Point(50, 59);
            this.labelControlGVCN.Name = "labelControlGVCN";
            this.labelControlGVCN.Size = new System.Drawing.Size(49, 13);
            this.labelControlGVCN.TabIndex = 23;
            this.labelControlGVCN.Text = "_______";
            // 
            // labelControlLop
            // 
            this.labelControlLop.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelControlLop.Location = new System.Drawing.Point(193, 35);
            this.labelControlLop.Name = "labelControlLop";
            this.labelControlLop.Size = new System.Drawing.Size(49, 13);
            this.labelControlLop.TabIndex = 22;
            this.labelControlLop.Text = "_______";
            // 
            // labelControlHocKy
            // 
            this.labelControlHocKy.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelControlHocKy.Location = new System.Drawing.Point(343, 35);
            this.labelControlHocKy.Name = "labelControlHocKy";
            this.labelControlHocKy.Size = new System.Drawing.Size(49, 13);
            this.labelControlHocKy.TabIndex = 22;
            this.labelControlHocKy.Text = "_______";
            // 
            // labelControlNamHoc
            // 
            this.labelControlNamHoc.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelControlNamHoc.Location = new System.Drawing.Point(65, 35);
            this.labelControlNamHoc.Name = "labelControlNamHoc";
            this.labelControlNamHoc.Size = new System.Drawing.Size(49, 13);
            this.labelControlNamHoc.TabIndex = 21;
            this.labelControlNamHoc.Text = "_______";
            // 
            // labelControlGVCNTT
            // 
            this.labelControlGVCNTT.Location = new System.Drawing.Point(13, 61);
            this.labelControlGVCNTT.Name = "labelControlGVCNTT";
            this.labelControlGVCNTT.Size = new System.Drawing.Size(31, 13);
            this.labelControlGVCNTT.TabIndex = 1;
            this.labelControlGVCNTT.Text = "GVCN:";
            // 
            // labelControlHocKyTT
            // 
            this.labelControlHocKyTT.Location = new System.Drawing.Point(300, 35);
            this.labelControlHocKyTT.Name = "labelControlHocKyTT";
            this.labelControlHocKyTT.Size = new System.Drawing.Size(36, 13);
            this.labelControlHocKyTT.TabIndex = 1;
            this.labelControlHocKyTT.Text = "Học kỳ:";
            // 
            // labelControlLopTT
            // 
            this.labelControlLopTT.Location = new System.Drawing.Point(166, 35);
            this.labelControlLopTT.Name = "labelControlLopTT";
            this.labelControlLopTT.Size = new System.Drawing.Size(21, 13);
            this.labelControlLopTT.TabIndex = 1;
            this.labelControlLopTT.Text = "Lớp:";
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
            this.labelControlTitle.Size = new System.Drawing.Size(162, 19);
            this.labelControlTitle.TabIndex = 0;
            this.labelControlTitle.Text = "BẢNG ĐIỂM HỌC KỲ";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(512, 31);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 24;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmBC_BangDiemHocKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 402);
            this.Controls.Add(this.panelControlRight);
            this.Controls.Add(this.panelControlLeft);
            this.Name = "frmBC_BangDiemHocKy";
            this.ShowIcon = false;
            this.Text = "Bảng điểm môn học";
            this.Load += new System.EventHandler(this.frmBangDiemMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).EndInit();
            this.panelControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLopHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlChooseYear)).EndInit();
            this.panelControlChooseYear.ResumeLayout(false);
            this.panelControlChooseYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNamHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHocKy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRight)).EndInit();
            this.panelControlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTopRight)).EndInit();
            this.panelControlTopRight.ResumeLayout(false);
            this.panelControlTopRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlLeft;
        private DevExpress.XtraEditors.PanelControl panelControlChooseYear;
        private DevExpress.XtraEditors.PanelControl panelControlRight;
        private DevExpress.XtraEditors.PanelControl panelControlTopRight;
        private DevExpress.XtraEditors.LabelControl labelControlGVCNTT;
        private DevExpress.XtraEditors.LabelControl labelControlHocKyTT;
        private DevExpress.XtraEditors.LabelControl labelControlLopTT;
        private DevExpress.XtraEditors.LabelControl labelControlNamHocTT;
        private DevExpress.XtraEditors.LabelControl labelControlTitle;
        private DevExpress.XtraTreeList.TreeList treeListLopHoc;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNamHoc;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditHocKy;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControlGVCN;
        private DevExpress.XtraEditors.LabelControl labelControlLop;
        private DevExpress.XtraEditors.LabelControl labelControlHocKy;
        private DevExpress.XtraEditors.LabelControl labelControlNamHoc;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}