using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLHS.BUS;
using QLHS.DTO;
using Utilities;
using DevExpress.XtraEditors;

namespace QLHS
{
    public partial class frmGiaoVien : DevExpress.XtraEditors.XtraForm
    {
        GiaoVienBUS GVBUS=new GiaoVienBUS();
        GiaoVienDTO GVDTO;
        DataTable dt;
        public frmGiaoVien()
        {
            InitializeComponent();
            KhoiTaoTrangthai();
        }
        private int flag = 0;
       
        public static bool KiemtraNull(string Chuoi)
        {
            if (Chuoi=="")
            {
                return false;
            }
            return true;
        }
        public void KhoiTaoTrangthai()
        {
            
            simpleButonSuagiaovien.Enabled = true;
            simpleButtonLuuGiaoVien.Enabled = false;
            simpleButtonThemGiaoVien.Enabled = true;
            simpleButtonXoaGiaovien.Enabled = true;
            textEditMaGiaoVien.Enabled = false;
            textEditTenGiaoVien.Enabled = false;
            simpleButtonhuy.Enabled = false;
        }
       
        private void simpleButtonThemGiaoVien_Click(object sender, EventArgs e)
        {
            GVDTO = new GiaoVienDTO();
            textEditMaGiaoVien.Text = ""; ;
            textEditTenGiaoVien.Text = "";
            textEditMaGiaoVien.Enabled = true;
            textEditTenGiaoVien.Enabled = true;
            simpleButtonLuuGiaoVien.Enabled = true;
            simpleButonSuagiaovien.Enabled = false;
           // simpleButtonXoaGiaovien.Enabled = false;
            simpleButtonhuy.Enabled=true;
            this.simpleButtonThemGiaoVien.Enabled = false;
            flag = 1;
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = GVBUS.TableGiaoVien();
        
            GridcontrolGiaoVien.DataSource = dt;
        }
        void load_dulieu(DataTable dt)
        {
            GridcontrolGiaoVien.DataSource = dt;
        }

      
        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonXoaGiaovien_Click(object sender, EventArgs e)
        {
           
            if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có chắc chắn muốn xóa giáo viên này\"" + textEditTenGiaoVien.Text + "\" hay không?") == System.Windows.Forms.DialogResult.Yes)
            {
                string MaGV = textEditMaGiaoVien.Text.Trim();
                MaGV = GVBUS.Doichuoi(MaGV, "'", "''", true);
                GVBUS.XoaGiaoVien(MaGV);
                flag = 0;
            }
            simpleButtonLoadlaidulieu_Click( sender, e);
           // simpleButtonLuuGiaoVien.Enabled = true;
            flag = 2;
        }

        private void simpleButonSuagiaovien_Click(object sender, EventArgs e)
        {
            simpleButtonhuy.Enabled = true;
            textEditTenGiaoVien.Enabled = true;
            simpleButtonLuuGiaoVien.Enabled = true;
            this.simpleButonSuagiaovien.Enabled = false;
            flag = 3;
        }

        private void simpleButtonLuuGiaoVien_Click(object sender, EventArgs e)
        {
            if (flag==1||flag==3)
            {
                if (KiemtraNull(textEditMaGiaoVien.Text.Trim()))
                {
                    string MaGV = textEditMaGiaoVien.Text.Trim();
                    MaGV = GVBUS.Doichuoi(MaGV, "'", "''", true);
                    GVDTO = new GiaoVienDTO();
                      if (textEditTenGiaoVien.Text.Trim() != "")
                        {
                            string TenGV = textEditTenGiaoVien.Text.Trim();
                            TenGV= GVBUS.Doichuoi(TenGV, "'", "''", true);
                                if (flag == 1)
                                {                                                          
                                   
                                    GVDTO.MaGiaoVien = MaGV;
                                    GVDTO.TenGiaoVien = TenGV;
                                    int kq=GVBUS.ThemGiaoVien(GVDTO);
                                    if (kq>0)
                                    {
                                        Utilities.MessageboxUtilities.MessageSuccess("Bạn đã thêm thành công" + kq + " Giáo viên vào cơ sở dữ liệu");
                                    }
                                    else
                                    {
                                        Utilities.MessageboxUtilities.MessageError("Hành động thêm thất bại. Có thể giáo viên này đã tồn tại trong cơ sở dữ liệu");
                                    }
                            
                                }
                       
                                else  if (flag==3)
                                 {
                                
                                    GVDTO.MaGiaoVien=MaGV;
                                    GVDTO.TenGiaoVien=textEditTenGiaoVien.Text.Trim();
                                    GVBUS.CapNhatGiaoVien(GVDTO);                          
                                }
                               
                    }
                    else
                    {
                          MessageboxUtilities.MessageError("Tên lớp không thể để trống");
                          this.Cursor = textEditTenGiaoVien.Cursor;
                    }

                }
                else
                {
                    MessageboxUtilities.MessageError("Mã lớp không thể để trống");

                }
                frmGiaoVien_Load(sender, e);
            }
            
        }

       
       
        private void gridViewGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for (int i = 0; i < gridViewGiaoVien.RowCount; )
           {
               textEditMaGiaoVien.Text = gridViewGiaoVien.GetFocusedRowCellValue("MaGiaoVien").ToString();
               textEditTenGiaoVien.Text = gridViewGiaoVien.GetFocusedRowCellValue("TenGiaoVien").ToString();
               break;
           }
        
            
        }

        private void simpleButtonLoadlaidulieu_Click(object sender, EventArgs e)
        {
            dt = GVBUS.TableGiaoVien();
            load_dulieu(dt);
            KhoiTaoTrangthai();
            GridcontrolGiaoVien.DataSource = dt;
        }


        private void simpleButtonhuy_Click_1(object sender, EventArgs e)
        {
            KhoiTaoTrangthai();
            flag = 0;
        }

     

     


        

    }
}