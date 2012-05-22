namespace QLHS
{
    partial class frmDoiMatKhau
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
            this.simpleButtonDoiMatKau = new DevExpress.XtraEditors.SimpleButton();
            this.textEditMatKhauCu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEditReMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMatKhauCu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonDoiMatKau
            // 
            this.simpleButtonDoiMatKau.Location = new System.Drawing.Point(39, 196);
            this.simpleButtonDoiMatKau.Name = "simpleButtonDoiMatKau";
            this.simpleButtonDoiMatKau.Size = new System.Drawing.Size(108, 37);
            this.simpleButtonDoiMatKau.TabIndex = 7;
            this.simpleButtonDoiMatKau.Text = "Đổi mật khẩu";
            // 
            // textEditMatKhauCu
            // 
            this.textEditMatKhauCu.Location = new System.Drawing.Point(39, 50);
            this.textEditMatKhauCu.Name = "textEditMatKhauCu";
            this.textEditMatKhauCu.Size = new System.Drawing.Size(161, 20);
            this.textEditMatKhauCu.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mật khẩu cũ:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu mới:";
            // 
            // textEditMatKhauMoi
            // 
            this.textEditMatKhauMoi.Location = new System.Drawing.Point(39, 92);
            this.textEditMatKhauMoi.Name = "textEditMatKhauMoi";
            this.textEditMatKhauMoi.Size = new System.Drawing.Size(161, 20);
            this.textEditMatKhauMoi.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(39, 118);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Nhập lại mật khẩu mới:";
            // 
            // textEditReMatKhauMoi
            // 
            this.textEditReMatKhauMoi.Location = new System.Drawing.Point(39, 137);
            this.textEditReMatKhauMoi.Name = "textEditReMatKhauMoi";
            this.textEditReMatKhauMoi.Size = new System.Drawing.Size(161, 20);
            this.textEditReMatKhauMoi.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLHS.Properties.Resources.login2;
            this.pictureBox1.Location = new System.Drawing.Point(211, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 134);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Location = new System.Drawing.Point(177, 196);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(108, 37);
            this.simpleButtonThoat.TabIndex = 8;
            this.simpleButtonThoat.Text = "Thoát";
            // 
            // frmDoiMatKhau
            // 
            this.AcceptButton = this.simpleButtonDoiMatKau;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 265);
            this.Controls.Add(this.simpleButtonThoat);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEditReMatKhauMoi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEditMatKhauMoi);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEditMatKhauCu);
            this.Controls.Add(this.simpleButtonDoiMatKau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.textEditMatKhauCu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraEditors.SimpleButton simpleButtonDoiMatKau;
        public DevExpress.XtraEditors.TextEdit textEditMatKhauCu;
        public DevExpress.XtraEditors.TextEdit textEditMatKhauMoi;
        public DevExpress.XtraEditors.TextEdit textEditReMatKhauMoi;
        public DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
    }
}