namespace QLHS_THPT
{
    partial class frmHocSinh
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEditNamHoc = new DevExpress.XtraEditors.LookUpEdit();
            this.comboBoxEditLop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditKhoi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.listBoxControlHocSinh = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditNamHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditKhoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlHocSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.listBoxControlHocSinh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 445);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lookUpEditNamHoc);
            this.panelControl2.Controls.Add(this.comboBoxEditLop);
            this.panelControl2.Controls.Add(this.comboBoxEditKhoi);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(3, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(194, 144);
            this.panelControl2.TabIndex = 3;
            // 
            // lookUpEditNamHoc
            // 
            this.lookUpEditNamHoc.Location = new System.Drawing.Point(19, 22);
            this.lookUpEditNamHoc.Name = "lookUpEditNamHoc";
            this.lookUpEditNamHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditNamHoc.Size = new System.Drawing.Size(150, 20);
            this.lookUpEditNamHoc.TabIndex = 7;
            // 
            // comboBoxEditLop
            // 
            this.comboBoxEditLop.Location = new System.Drawing.Point(19, 111);
            this.comboBoxEditLop.Name = "comboBoxEditLop";
            this.comboBoxEditLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLop.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditLop.TabIndex = 6;
            // 
            // comboBoxEditKhoi
            // 
            this.comboBoxEditKhoi.Location = new System.Drawing.Point(19, 66);
            this.comboBoxEditKhoi.Name = "comboBoxEditKhoi";
            this.comboBoxEditKhoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditKhoi.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditKhoi.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Chọn lớp:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Chọn năm học:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Chọn khối:";
            // 
            // listBoxControlHocSinh
            // 
            this.listBoxControlHocSinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlHocSinh.Location = new System.Drawing.Point(3, 3);
            this.listBoxControlHocSinh.Name = "listBoxControlHocSinh";
            this.listBoxControlHocSinh.Size = new System.Drawing.Size(194, 439);
            this.listBoxControlHocSinh.TabIndex = 0;
            // 
            // frmHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 445);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "frmHocSinh";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Tiếp nhận học sinh";
            this.Load += new System.EventHandler(this.frmHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditNamHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditKhoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlHocSinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlHocSinh;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLop;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditKhoi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditNamHoc;

    }
}