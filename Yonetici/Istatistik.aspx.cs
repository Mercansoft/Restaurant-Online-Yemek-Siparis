using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetici_Istatistik : System.Web.UI.Page
{
    Data _clsData = new Data();
    DataTable _dtToplam;
    private DataTable _dtToplam2;
    DataTable _dtOnayBekleyen;
    private DataTable _dtGunluk;
    private DataTable _dtGunluk2;
    private DataTable _dtOnayBekleyen2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_ToplamVeri();
            _fnc_Gunluk();
        }
    }
    private void _fnc_ToplamVeri()
    {
        try
        {
            _dtToplam = _clsData._fncVeriGetir("select COUNT(*) AS ToplamSiparis , SUM(Tutar) AS ToplamUcret FROM SiparisApp WHERE SiparisDurumID=4");
            _dtToplam2 = _clsData._fncVeriGetir("select * FROM SiparisApp");
            _lblToplamSiparis.Text = _dtToplam2.Rows.Count.ToString();
            _lblToplamUcret.Text = String.Format("{0:C}", _dtToplam.Rows[0]["ToplamUcret"]);
            _dtOnayBekleyen = _clsData._fncVeriGetir("select * from SiparisApp where SiparisDurumID=3");
            _lblOnayBekleyenSiparis.Text = _dtOnayBekleyen.Rows.Count.ToString();
        }
        catch (Exception)
        {
            
        }
    }

    private void _fnc_Gunluk()
    {
        try
        {
            _dtGunluk =_clsData._fncVeriGetir(
                    "SELECT COUNT(*) AS ToplamSiparis,SUM(Tutar) AS ToplamUcret FROM SiparisApp WHERE SiparisAppTarih Between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00:000" + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59:000" + "'");
           // _dtGunluk = _clsData._fncVeriGetir("select COUNT(*) AS ToplamSiparis , SUM(Toplam) AS ToplamUcret FROM Siparis WHERE Durum=0 AND SiparisTarihi Between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00:000" + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:00:000" + "'");
            _dtGunluk2 = _clsData._fncVeriGetir("select COUNT(*) AS ToplamSiparis,SUM(Tutar) AS ToplamUcret FROM SiparisApp WHERE SiparisAppTarih Between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00:000" + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59:000" + "'");
            _lblToplamSiparisGunluk.Text = _dtGunluk2.Rows[0]["ToplamSiparis"].ToString();
            Label2.Text = String.Format("{0:C}", _dtGunluk.Rows[0]["ToplamUcret"]);

            _dtOnayBekleyen2 = _clsData._fncVeriGetir("select * from SiparisApp where SiparisDurumID=3");

            _lblOnayBekleyenSiparisGunluk.Text = _dtOnayBekleyen2.Rows.Count.ToString();
        }
        catch (Exception)
        {
            
        }
    }
}