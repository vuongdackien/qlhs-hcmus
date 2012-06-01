using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLHS.BUS;
using QLHS.DTO;
namespace QLHS
{
    public partial class frmPhanLop : DevExpress.XtraEditors.XtraForm
    {
        private NamHocBUS _NamHocBUS;
        private KhoiBUS _KhoiBUS;
        private LopBUS _LopBUS;
        private HocSinhBUS _hocSinhBUS;
        private PhanLopBUS _phanLopBUS;
        private QuyDinhBUS _quyDinhBUS;
        private ChuyenLopBUS _ChuyenLopBUS;
        private int _dongHT_GridHocSinh, _dongHT_GridHocSinhMoi = -1;
        private string _maNamHocHienTai;

        private enum YeuCau
        {
            PhanLop_HoSoChuaPhanLop,
            PhanLop_HoSoNamCu,
            ChuyenLop_CungKhoi
        };

        public frmPhanLop()
        {
            InitializeComponent();
            _NamHocBUS = new NamHocBUS();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _hocSinhBUS = new HocSinhBUS();
            _phanLopBUS = new PhanLopBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _ChuyenLopBUS = new ChuyenLopBUS();
            _maNamHocHienTai = _quyDinhBUS.LayMaNamHoc_HienTai();
        }
      

        private void _Show_Control(YeuCau yc)
        {
            // Disable all control
            dateEditTu.Enabled = false;
            dateEditDen.Enabled = false;
            simpleButtonLayHSo.Enabled = false;

            checkEditChuyenBangDiem.Enabled = false;
            textEditLyDoChuyen.Enabled = false;

            groupControlLopCu.Enabled = true;

            simpleButtonXoaPL.Enabled = true;
            simpleButtonChuyenTatCa.Enabled = true;

            // Show control
            if (yc == YeuCau.PhanLop_HoSoChuaPhanLop)
            {
                dateEditTu.Enabled = true;
                dateEditDen.Enabled = true;
                simpleButtonLayHSo.Enabled = true;
                groupControlLopCu.Enabled = false;
            }
            else if (yc == YeuCau.PhanLop_HoSoNamCu)
            {
               
            }
            else if(yc == YeuCau.ChuyenLop_CungKhoi)
            {
                checkEditChuyenBangDiem.Enabled = true;
                textEditLyDoChuyen.Enabled = true;
                simpleButtonXoaPL.Enabled = false;
                simpleButtonChuyenTatCa.Enabled = false;
            }
        }
        private void _LoadGridcontrolDSHocSinhMoi()
        {
            gridControlDSHocSinhMoi.DataSource =  _hocSinhBUS.LayDTHocSinh_LopHoc(
                                                        Util.CboUtil.GetValueItem(comboBoxEditLopMoi)
                                                  );
        }
        private void _LoadGridcontrolDSHocSinh()
        {
            // Chưa phân lớp
            if(radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                gridControlDSHocSinh.DataSource =   _hocSinhBUS.LayDT_HocSinh_ChuaPhanLop(
                                                            Convert.ToDateTime(dateEditTu.EditValue),
                                                            Convert.ToDateTime(dateEditDen.EditValue)
                                                     );
            }
            // phân lớp từ năm cũ || chuyển lớp cùng khối
            else if(radioButtonPhanLopHocSinh_NamTruoc.Checked || 
                    radioButtonChuyenLopCungKhoi.Checked)
            {
                  gridControlDSHocSinh.DataSource = _hocSinhBUS.LayDTHocSinh_LopHoc(
                         Util.CboUtil.GetValueItem(comboBoxEditLop)
                  );
            }
        }
 
        private bool _KiemTraCbThongTinLopCu()
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
            {
                Util.MsgboxUtil.Error("Không có năm học sau năm học hiện tại, bạn hãy chọn chức năng khác");
                return false;

            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditKhoi))
            {
                Util.MsgboxUtil.Error("Năm học này không tồn tại lớp học");
                return false;
            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLop))
            {
                Util.MsgboxUtil.Error("Năm học này không có lớp");
                return false;
            }
            return true;
        }
        private bool _KiemTraCbThongTinLopMoi()
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHocMoi))
            {
                Util.MsgboxUtil.Error("Không có năm học sau năm học hiện tại, bạn hãy chọn chức năng khác");
                return false;

            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditKhoiMoi))
            {
                Util.MsgboxUtil.Error("Năm học này không tồn tại lớp học");
                return false;
            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLopMoi))
            {
                Util.MsgboxUtil.Error("Năm học này không có lớp");
                return false;
            }
            return true;
        }
        private bool _KiemTraKhoiLop_ChuyenLop(string MaNamHoc)
        {
            return _phanLopBUS.LayDTKhoi(MaNamHoc).Rows.Count > 0;
        }

        private void _Load_Form()
        {
            simpleButtonPhanLop.Enabled = false;
            simpleButtonXoaPL.Enabled = false;
            simpleButtonChuyenTatCa.Enabled = false;
        }

        /// <summary>
        /// Chuyển tất cả học sinh sang lớp mới
        /// </summary>
        private void _ChuyenTatCa()
        {
            string maLop = Util.CboUtil.GetValueItem(comboBoxEditLop),
                    tenLop = Util.CboUtil.GetDisplayItem(comboBoxEditLop),
                    maLopMoi = Util.CboUtil.GetValueItem(comboBoxEditLopMoi),
                    tenLopMoi = Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi),
                    maNamHoc = Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                    tenNamHoc = Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc),
                    maNamHocMoi = Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi),
                    tenNamHocMoi = Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi),
                    tenKhoi = Util.CboUtil.GetDisplayItem(comboBoxEditKhoi),
                    tenKhoiMoi = Util.CboUtil.GetDisplayItem(comboBoxEditKhoiMoi);
            int siSoToiDa = _quyDinhBUS.LaySiSoCanTren();
            int siSoLopMoi = _phanLopBUS.Dem_SiSo_Lop(maLopMoi);
            int siSoLop = _phanLopBUS.Dem_SiSo_Lop(maLop);
            if ((siSoLop + siSoLopMoi) >= siSoToiDa)
            {
                Util.MsgboxUtil.Error("Không thể chuyển tất cả vì sau khi chuyển học sinh từ lớp " + tenLop
                            + " (" + siSoLop + " hs) sang lớp " + tenLopMoi + " (" + siSoLopMoi + " hs) sẽ vượt quá quy định (" + siSoToiDa + ")!");
                return;
            }

            Dictionary<string, string> ds_HocSinhChon = new Dictionary<string, string>();
            for (int i = 0; i < gridViewDSHocSinh.RowCount; i++)
            {
                ds_HocSinhChon.Add(this.gridViewDSHocSinh.GetRowCellValue(i, "MaHocSinh").ToString(),
                                        this.gridViewDSHocSinh.GetRowCellValue(i, "TenHocSinh").ToString());
            }
            if (ds_HocSinhChon.Count == 0)
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn học sinh để chuyển!");
                return;
            }
            _phanLopBUS.PhanLop_DSHocSinh_Lop(ds_HocSinhChon, maLopMoi);


        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
            {
                return;
            }
            Util.CboUtil.SetDataSource(comboBoxEditKhoi, _phanLopBUS.LayDTKhoi(
                Util.CboUtil.GetValueItem(comboBoxEditNamHoc)), "MaKhoi", "TenKHoi", 0);
        }

        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            Util.CboUtil.SetDataSource(comboBoxEditLop, _LopBUS.LayDTLop_MaNam_MaKhoi(
                       Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                         Util.CboUtil.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
            
            comboBoxEditLop_SelectedIndexChanged(sender, e);
        }

        private void loadComboboxLopHoc_Moi(object sender, EventArgs e)
        {
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                Util.CboUtil.SetDataSource(comboBoxEditLopMoi, _phanLopBUS.LayDTLop_MaNam_MaKhoi_KhacMaLop(
                    Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi),
                    Util.CboUtil.GetValueItem(comboBoxEditKhoiMoi),
                    Util.CboUtil.GetValueItem(comboBoxEditLop)), "MaLop", "TenLop", 0);
            }
            else
            {
                Util.CboUtil.SetDataSource(comboBoxEditLopMoi, _LopBUS.LayDTLop_MaNam_MaKhoi(
                        Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi),
                        Util.CboUtil.GetValueItem(comboBoxEditKhoiMoi)), "MaLop", "TenLop", 0);
            }
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            _LoadGridcontrolDSHocSinh();
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                this.loadComboboxLopHoc_Moi(sender, e);
            }
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc) || Util.CboUtil.CheckSelectedNull(comboBoxEditKhoi))
                return;
            this.LoadComboboxLopHoc(sender, e);
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _phanLopBUS.LayDTKhoi_Chuyen(Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi), Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);

            }
            else
            {
                Util.CboUtil.SetDataSource(
                    comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_PL(Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
            }
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            string tb = "";
            if (_NamHocBUS.LayDTNamHocHienTai().Rows.Count > 0)
            {
                if (_KiemTraKhoiLop_ChuyenLop(_maNamHocHienTai))
                {
                    _Load_Form();
                }
                else
                    tb = tb + "Chưa có lớp trong năm học, bạn hãy tạo lớp trước khi sử dụng chức năng này";
            }
            else
            {
                tb = tb + "Trong dữ liệu chưa có năm học = năm học hiện tại trong quy định, bạn hãy tạo năm học trước khi sử dụng chức năng này";
            }
            if (tb != "")
            {
                Util.MsgboxUtil.Error(tb);
            }
            // khoi tao 2 input datetime từ và đến
            DateTime dateTu = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            dateEditTu.Properties.MaxValue = DateTime.Now;
            dateEditDen.Properties.MaxValue = DateTime.Now;
            dateEditTu.EditValue = dateTu;
            dateEditDen.EditValue = DateTime.Now;
            radioButtonPhanLopHocSinhMoi_CheckedChanged(this, new EventArgs());

        }
        private void comboBoxEditLopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLopMoi))
            {
                gridControlDSHocSinhMoi.DataSource = null;
                return;
            }
            _LoadGridcontrolDSHocSinhMoi();
        }

        private void comboBoxEditNamHocMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, 
                    _phanLopBUS.LayDTKhoi10(Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi)),
                    "MaKhoi", "TenKHoi", 0);
            }
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _phanLopBUS.LayDTKhoi_Chuyen(Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi), Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
            }
            if(radioButtonPhanLopHocSinh_NamTruoc.Checked)
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_PL(Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
        }
        
        private void comboBoxEditKhoiMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadComboboxLopHoc_Moi(sender, e);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewDSHocSinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            _dongHT_GridHocSinh = e.FocusedRowHandle;
        }

        private void simpleButtonChuyenLop_Click(object sender, EventArgs e)
        {
            if (!_KiemTra_LopMoi_DaChon())
            {
                return;
            }

            Dictionary<string,string> ds_HocSinhChon = new Dictionary<string,string>();
            for (int i = 0; i < gridViewDSHocSinh.RowCount ; i++)
            {
                if (Convert.ToBoolean(this.gridViewDSHocSinh.GetRowCellValue(i, "Check")))
                {
                    ds_HocSinhChon.Add(this.gridViewDSHocSinh.GetRowCellValue(i, "MaHocSinh").ToString(),
                                        this.gridViewDSHocSinh.GetRowCellValue(i, "TenHocSinh").ToString());
                }
            }
            if (ds_HocSinhChon.Count == 0)
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn học sinh để chuyển!");
                return;
            }

            int siSoToiDa = _quyDinhBUS.LaySiSoCanTren();
          

            // Chuyển cùng khối, chuyển và xóa hồ sơ cũ
            if(radioButtonChuyenLopCungKhoi.Checked)
            {

                string  maLop = Util.CboUtil.GetValueItem(comboBoxEditLop),
                        tenLop = Util.CboUtil.GetDisplayItem(comboBoxEditLop),
                        maLopMoi = Util.CboUtil.GetValueItem(comboBoxEditLopMoi),
                        tenLopMoi = Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi);

                int siSoLopMoi = _phanLopBUS.Dem_SiSo_Lop(maLopMoi);
                if ( siSoLopMoi >= siSoToiDa)
                {
                    Util.MsgboxUtil.Error("Không thể thực hiện vì lớp "+
                            tenLopMoi+" ("+siSoLopMoi+" hs) đã đủ sỉ số học sinh quy định ("+siSoToiDa+" hs/Lớp)!");
                    return;
                }

                ChuyenLopDTO chuyenLopDTO = new ChuyenLopDTO();
                chuyenLopDTO.TuLop = maLop;
                chuyenLopDTO.DenLop = maLopMoi;
                chuyenLopDTO.NgayChuyen = DateTime.Now;
                chuyenLopDTO.LyDoChuyen = textEditLyDoChuyen.Text.Replace("'","''");
                chuyenLopDTO.GiuLaiBangDiem = checkEditChuyenBangDiem.Checked;


                if (_ChuyenLopBUS.ChuyenLop_HocSinh_Lop(ds_HocSinhChon,chuyenLopDTO))
                {
                        Util.MsgboxUtil.Success("Đã chuyển toàn bộ hồ sơ học sinh từ lớp "
                                +tenLop+" sang lớp "+tenLopMoi+" thành công!");
                }
                else
                {
                    Util.MsgboxUtil.Info("Có lỗi trong quá trình chuyển!");
                }
            }
            else // phân lớp 
            {
                string  maLopMoi = Util.CboUtil.GetValueItem(comboBoxEditLopMoi),
                        tenLopMoi = Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi),
                        tenNamHocMoi = Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi),
                        tenKhoiMoi = Util.CboUtil.GetDisplayItem(comboBoxEditKhoiMoi);


                int siSoLopMoi = _phanLopBUS.Dem_SiSo_Lop(maLopMoi);
                int siSoDSChuyen = ds_HocSinhChon.Count;
                if ((siSoDSChuyen+siSoLopMoi)  >= siSoToiDa)
                {
                    Util.MsgboxUtil.Error("Không thể thực hiện vì sau khi chuyển học sinh đến lớp "+
                            tenLopMoi+" ("+siSoLopMoi+" hs) sẽ vượt quá quy định ("+siSoToiDa+")!");
                    return;
                }

                if (Util.MsgboxUtil.YesNo(
                        "Lưu ý: Các học sinh đã chọn nếu đã được phân lớp vào khối "+ tenKhoiMoi
                        +" trong năm học "+tenNamHocMoi
                        +" sẽ được giữ nguyên hồ sơ.\nChương trình chỉ chuyển những học sinh chưa được phân lớp vào khối "+tenKhoiMoi+" năm này."
                        +"\n\nBạn có muốn chuyển các học sinh đã chọn" 
                        +" sang lớp: " + tenLopMoi + " năm học: " +  tenNamHocMoi + " hay không?")  == DialogResult.No)
                {
                    return;
                }
                if(_phanLopBUS.PhanLop_DSHocSinh_Lop(ds_HocSinhChon,maLopMoi))
                {
                    Util.MsgboxUtil.Success("Đã phân lớp danh sách học sinh đến lớp mới: "+tenLopMoi+".");
                }
                else
                {
                     Util.MsgboxUtil.Info("Không có học sinh nào được chuyển!");
                }
            }
            // Cập nhật lại danh sách lớp mới
            comboBoxEditLopMoi_SelectedIndexChanged(sender, e);
            _LoadGridcontrolDSHocSinh();
            _LoadGridcontrolDSHocSinhMoi();
            // Cập nhật lại danh sách lớp cũ
            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked || radioButtonChuyenLopCungKhoi.Checked)
            {
                this._LoadGridcontrolDSHocSinh();
            }
         
            _HienThi_Button();
 
        }

        private void gridViewDSHocSinhMoi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            if (e.FocusedRowHandle < 0)
                return;
            _dongHT_GridHocSinhMoi = e.FocusedRowHandle;
        }

        private void simpleButtonXoaPLMoi_Click(object sender, EventArgs e)
        {
            if (!_KiemTra_LopMoi_DaChon())
            {
                return;
            }

            string   maLopMoi = Util.CboUtil.GetValueItem(comboBoxEditLopMoi),
                    tenLopMoi = Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi),
                    tenNamHocMoi = Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi);

            Dictionary<string, string> ds_HocSinhChon = new Dictionary<string, string>();
            for (int i = 0; i < gridViewDSHocSinhMoi.RowCount; i++)
            {
                if (Convert.ToBoolean(this.gridViewDSHocSinhMoi.GetRowCellValue(i, "Check")))
                {
                    ds_HocSinhChon.Add(this.gridViewDSHocSinhMoi.GetRowCellValue(i, "MaHocSinh").ToString(),
                                        this.gridViewDSHocSinhMoi.GetRowCellValue(i, "TenHocSinh").ToString());
                }
            }
            if (ds_HocSinhChon.Count == 0)
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn học sinh để xóa!");
                return;
            }

            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked || radioButtonPhanLopHocSinh_NamTruoc.Checked)
            {
                if (Util.MsgboxUtil.YesNo("Bạn có muốn xóa các hồ sơ học sinh đã chọn thuộc lớp " + maLopMoi
                           + " năm học " + tenNamHocMoi + " hay không?")
                               == DialogResult.No)
                {
                    return;
                }

                if (_phanLopBUS.Xoa_DSHocSinh_Lop(ds_HocSinhChon,maLopMoi))
                {
                      Util.MsgboxUtil.Success("Đã xóa các hồ sơ trong lớp: "+tenLopMoi+" thành công!");
                }
                else
                {
                     Util.MsgboxUtil.Info("Không có hồ sơ học sinh nào được xóa!");
                }

                this._LoadGridcontrolDSHocSinhMoi();

                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    this._LoadGridcontrolDSHocSinh();
                }
            }
            _HienThi_Button();
        }
       

        private void gridViewDSHocSinh_MouseEnter(object sender, EventArgs e)
        {
            simpleButtonChuyenTatCa.Enabled = true;
            simpleButtonPhanLop.Enabled = true;
            simpleButtonXoaPL.Enabled = false;
            _HienThi_Button();
        }

        private void gridViewDSHocSinhMoi_MouseEnter(object sender, EventArgs e)
        {
            simpleButtonPhanLop.Enabled = false;
            simpleButtonChuyenTatCa.Enabled = false;
            if (radioButtonChuyenLopCungKhoi.Checked == false)
            {
                simpleButtonXoaPL.Enabled = true;
            }
            _HienThi_Button();
        }
        private void _HienThi_Button()
        {
            if (gridViewDSHocSinh.RowCount == 0)
            {
                simpleButtonPhanLop.Enabled = false;
                simpleButtonChuyenTatCa.Enabled = false;
                if (gridViewDSHocSinhMoi.RowCount > 0)
                {
                    if (radioButtonChuyenLopCungKhoi.Checked)
                    {
                        simpleButtonXoaPL.Enabled = true;
                    }
                }
            }
            if (gridViewDSHocSinhMoi.RowCount == 0)
            {
                simpleButtonXoaPL.Enabled = false;
                if (gridViewDSHocSinh.RowCount > 0)
                {
                    simpleButtonPhanLop.Enabled = true;
                }
            }
        }
        public bool _KiemTra_LopMoi_DaChon()
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLopMoi))
            {
                Util.MsgboxUtil.Error("Chưa có lớp trong năm học này, hoặc khối chỉ tồn tại 1 lớp, bạn cần phải tạo lớp trước khi muốn chuyển");
                return false;
            }
            return true;
        }

        private void checkEditHocSinhChuaChuyen_CheckedChanged(object sender, EventArgs e)
        {   
            _LoadGridcontrolDSHocSinh();
            _LoadGridcontrolDSHocSinhMoi();
        }

        private void checkEditChuyenLop_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditKhoi_SelectedIndexChanged(sender, e);
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocHienTai(),
                                                "MaNamHoc", "TenNamHoc", 0);
            }
            else
            {
                Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocTruoc(),
                                                    "MaNamHoc", "TenNamHoc", 0);
            }
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                simpleButtonPhanLop.Text = "Chuyển Lớp";
                checkEditChuyenBangDiem.Enabled = true;
                textEditLyDoChuyen.Enabled = true;
            }
            else
            {
                simpleButtonPhanLop.Text = "Phân Lớp";
                checkEditChuyenBangDiem.Checked = false;
                textEditLyDoChuyen.Text = "";
                groupBoxPhanLop.Enabled = true;
            }
        }
        
       
        private void simpleButtonChuyenHet_Click(object sender, EventArgs e)
        {
            if (_KiemTra_LopMoi_DaChon())
            {
                string chuyen = "";
                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    chuyen = chuyen + " từ hồ sơ ";
                }
                else
                    chuyen = chuyen + Util.CboUtil.GetDisplayItem(comboBoxEditLop) + "trong năm học " 
                        + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
                if (Util.MsgboxUtil.YesNo("Bạn có muốn phân lớp hết học sinh đã chọn sang lớp " 
                    + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " trong năm học "
                    + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " hay không?")
                    == DialogResult.Yes)
                {
                    _ChuyenTatCa();
                    this._LoadGridcontrolDSHocSinh();
                    this._LoadGridcontrolDSHocSinhMoi();
                }
            }
        }

        private void radioButtonChuyenLop_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonChuyenLopCungKhoi.Checked)
            {
                _Show_Control(YeuCau.ChuyenLop_CungKhoi);
            }
            // Load combobox 2 bên chuyển lớp
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);
            Util.CboUtil.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);
        }

        private void radioButtonPhanLopHocSinhMoi_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                _Show_Control(YeuCau.PhanLop_HoSoChuaPhanLop);
            }
            Util.CboUtil.SetDataSource(comboBoxEditNamHocMoi,
                _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);

            this._LoadGridcontrolDSHocSinh();

        }

        private void radioButtonPhanLopHocSinhCu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPhanLopHocSinh_NamTruoc.Checked)
            {
                this._Show_Control(YeuCau.PhanLop_HoSoNamCu);

                // Load năm học trước
                Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocTruoc(), "MaNamHoc", "TenNamHoc", 0);
                
                if (_KiemTraCbThongTinLopCu())
                {
                    Util.CboUtil.SetDataSource(comboBoxEditNamHocMoi,
                        _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);
                }
                
            }
            
        }

        private void simpleButtonLayHSo_Click(object sender, EventArgs e)
        {
            this._LoadGridcontrolDSHocSinh();
        }

        private void gridViewDSHocSinh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            gridViewDSHocSinh.SetRowCellValue(e.RowHandle, "Check",
                !Convert.ToBoolean(gridViewDSHocSinh.GetRowCellValue(e.RowHandle, "Check"))
           );
        }

        private void gridViewDSHocSinhMoi_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            gridViewDSHocSinhMoi.SetRowCellValue(e.RowHandle, "Check",
                           !Convert.ToBoolean(gridViewDSHocSinhMoi.GetRowCellValue(e.RowHandle, "Check"))
                      );
        }

        private void chonTatCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridViewDSHocSinh.RowCount; i++)
            {
                gridViewDSHocSinh.SetRowCellValue(i, "Check", true);
            }
        }

        private void chonTatCaDSLopDenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridViewDSHocSinhMoi.RowCount; i++)
            {
                gridViewDSHocSinhMoi.SetRowCellValue(i, "Check", true);
            }
        }

        private void xoaPhanLopMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButtonXoaPLMoi_Click(this, new EventArgs());
        }

        private void phanLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButtonChuyenLop_Click(this, new EventArgs());
        }

    }
}