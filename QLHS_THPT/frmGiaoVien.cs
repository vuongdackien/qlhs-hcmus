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
        private bool data = true;
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
            //dataGridViewGiaovien.Enabled = true;
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
            simpleButtonXoaGiaovien.Enabled = false;
            simpleButtonhuy.Enabled=true;
            this.Enabled = false;

            flag = 1;
           
           
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = GVBUS.TableGiaoVien();
            if (dt.Rows.Count==0)
            {
                data = false;
            }
            GridcontrolGiaoVien.DataSource = dt;
        }
        void load_dulieu(DataTable dt)
        {
            GridcontrolGiaoVien.DataSource = dt;
        }

        private void simpleButtonTìmkiem_Click(object sender, EventArgs e)
        {
           dt = new DataTable();   
            if (checkTenGiaoVien.Checked==true)
            {
                if (checkMaGiaoVien.Checked==true)
                {
                    dt=GVBUS.TableGiaoVien(3,textEditTKGiaoVien.Text.ToString());
                   
                }
                else
                {
                    dt=GVBUS.TableGiaoVien(1, textEditTKGiaoVien.Text.ToString());
                }
                
            }
            else
            {
                dt=GVBUS.TableGiaoVien(2, textEditTKGiaoVien.Text.ToString());
                
            }
            if (dt.Rows.Count==0)
            {
                data = false;
            }
            load_dulieu(dt);
                    
        }

       

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonXoaGiaovien_Click(object sender, EventArgs e)
        {
           // simpleButtonhuy.Show();
            /*for (int i = 0; i < gridViewGiaoVien.RowCount; i++)
            {
                if (textEditMaGiaoVien.Text == gridViewGiaoVien.GetRowCellValue(i,"MaGiaoVien").ToString())
                {
                    gridViewGiaoVien.DeleteRow(i);   
                }
            }*/
            if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có chắc chắn muốn xóa giáo viên này\"" + textEditTenGiaoVien.Text + "\" hay không?") == System.Windows.Forms.DialogResult.Yes)
            {
                GVBUS.XoaGiaoVien(textEditMaGiaoVien.Text.Trim());
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
            this.Enabled = false;
            flag = 3;
        }

        private void simpleButtonLuuGiaoVien_Click(object sender, EventArgs e)
        {
            if (flag==1||flag==2||flag==3)
            {
                if (KiemtraNull(textEditMaGiaoVien.Text.Trim()))
                {
                    if (flag==1)
                    {
                        if (textEditTenGiaoVien.Text.Trim() != "")
                        {
                            GVDTO = new GiaoVienDTO();
                            string MaGV = textEditTenGiaoVien.Text.Trim();
                            string TenGV = textEditTenGiaoVien.Text.Trim();
                            GVDTO.MaGiaoVien = MaGV;
                            GVDTO.TenGiaoVien = TenGV;
                            int kq=GVBUS.ThemGiaoVien(GVDTO);
                            if (kq>0)
                            {
                                Utilities.MessageboxUtilities.MessageSuccess("Bạn đã thêm thành công" + kq + " Giáo viên vao Cơ sở dữ liệu");
                            }
                            else
                            {
                                Utilities.MessageboxUtilities.MessageError("Hành động thêm thất bại");
                            }
                            flag=0;
                        }
                        else
                        {
                            MessageboxUtilities.MessageError("Tên lớp không thể để trống");
                            this.Cursor = textEditTenGiaoVien.Cursor;
                        } 
                    }
                    else  if (flag==3)
                    {
                        if (KiemtraNull(textEditTenGiaoVien.Text.Trim()))
                        {
                            GVDTO.MaGiaoVien=textEditMaGiaoVien.Text.Trim();
                            GVDTO.TenGiaoVien=textEditMaGiaoVien.Text.Trim();
                            GVBUS.CapNhatGiaoVien(GVDTO);
                            flag = 0;
                        }
                    }
                    

                }
                else
                {
                    MessageboxUtilities.MessageError("Mã lớp không thể để trống");

                }
                frmGiaoVien_Load(sender, e);
            }
            
        }

       
        private void simpleButtonhuy_Click(object sender, EventArgs e)
        {
            textEditTKGiaoVien.Text = "";
            KhoiTaoTrangthai();
            flag = 0;
        }
        private void gridViewGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for (int i = 0; i < gridViewGiaoVien.RowCount; )
           {
               textEditMaGiaoVien.Text = gridViewGiaoVien.GetFocusedRowCellValue("MaGiaoVien").ToString();
               textEditTenGiaoVien.Text = gridViewGiaoVien.GetFocusedRowCellValue("TenGiaoVien").ToString();
               break;
           }
         /*   if (data)
            {
               
                   
                               
            }*/
            
        }

        private void simpleButtonLoadlaidulieu_Click(object sender, EventArgs e)
        {
            dt = GVBUS.TableGiaoVien();
            load_dulieu(dt);
            KhoiTaoTrangthai();
            textEditTKGiaoVien.Text = "";
            GridcontrolGiaoVien.DataSource = dt;
        }

        
       

      

    
      

     

      
        
    }
}