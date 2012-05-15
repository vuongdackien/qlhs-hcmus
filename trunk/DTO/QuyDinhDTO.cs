using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class QuyDinhDTO
    {
       
	
    private int TuoiCD;

	public int TuoiCanDuoi
	{
		get { return TuoiCD;}
		set { TuoiCD = value;}
	}
	private int TuoiCT;

	public int TuoiCanTren
	{
		get { return TuoiCT;}
		set { TuoiCT = value;}
	}
    private int SiSoCD;

	public int SiSoCanDuoi
	{
		get { return SiSoCD;}
		set { SiSoCD = value;}
	}
	 private int SiSoCT;

	public int SiSoCanTren
	{
		get { return SiSoCT;}
		set { SiSoCT = value;}
	}
	private int SoMH;

	public int SoMonHoc
	{
		get { return SoMH;}
		set { SoMH = value;}
	}
	private int SoLuongL;

	public int SoLuongLop
	{
		get { return SoLuongL;}
		set { SoLuongL = value;}
	}
    private decimal DiemCH;

	public decimal DiemChuan
	{
		get { return DiemCH;}
		set { DiemCH = value;}
	}
	private String TenTR;

	public String TenTruong
	{
		get { return TenTR;}
		set { TenTR = value;}
	}
	
	private string DiaChiTR;

	public string DiaChiTruong
	{
		get { return DiaChiTR;}
		set { DiaChiTR = value;}
	}
	
	
    }
}
