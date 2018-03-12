using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Yonetici_Siparis : System.Web.UI.Page
{
    Data _clsData = new Data();
    DataTable _dtSiparis;
    DataTable _dtEklenti;
    DataTable _dtSiparisGoruntule;
    DataTable _dtSiparisOnayla;
    double Toplam;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _pnlTumu.Visible = false;
            _pnlYeni.Visible = false;
            _pnlGonderilecek.Visible = false;
            _pnlGonderilen.Visible = false;
            _fncAyar();
        }
        try
        {
            if (Request.QueryString["Komut"] != "")
            {
                string Komut = Request.QueryString["Komut"].ToString();
                switch (Komut)
                {
                    case "Yeni":
                        _pnlTumu.Visible = false;
                        _pnlYeni.Visible = true;
                        _pnlGoruntule.Visible = false;
                        _pnlGonderilen.Visible = false;
                        _pnlGonderilecek.Visible = false;
                        _fnc_YeniSiparis();
                        break;
                    case "Gonderilecek":
                        _pnlTumu.Visible = false;
                        _pnlYeni.Visible = false;
                        _pnlGonderilecek.Visible = true;
                        _pnlGoruntule.Visible = false;
                        _fnc_GonderilecekSiparis();
                        break;
                    case "Gonderilen":
                        _pnlTumu.Visible = false;
                        _pnlYeni.Visible = false;
                        _pnlGonderilecek.Visible = false;
                        _pnlGonderilen.Visible = true;
                        _pnlGoruntule.Visible = false;
                        _fnc_GonderilenSiparis();
                        break;
                    case "Tumu":
                        _pnlTumu.Visible = true;
                        _pnlYeni.Visible = false;
                        _pnlGonderilecek.Visible = false;
                        _pnlGonderilen.Visible = false;
                        _pnlGoruntule.Visible = false;
                        _fnc_TumSiparis();
                        break;
                }

            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Sil"].ToString()!= "")
            {
                DataTable _dtSiparisAppSil = _clsData._fncVeriGetir("SELECT * FROM Siparis WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Sil"].ToString()));
                for (int i = 0; i < _dtSiparisAppSil.Rows.Count; i++)
                {
                    _clsData._Metot_SQL_Calistir("DELETE FROM Siparis WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Sil"].ToString()));
                }
                
                 _clsData._Metot_SQL_Calistir("DELETE FROM SiparisApp WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Sil"].ToString()));
                _fnc_YeniSiparis();
                _fnc_GonderilenSiparis();
                _fnc_GonderilecekSiparis();
                Response.Redirect("Siparis.aspx?Komut=Yeni");
            }
        }
        catch (Exception)
        {
            
        }
        try
        {
            if (Request.QueryString["Onay"].ToString() != "")
            {
                _clsData._Metot_SQL_Calistir("UPDATE SiparisApp SET SiparisDurumID=1 WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Onay"].ToString()));
                DataTable _dtSiparislerApp = _clsData._fncVeriGetir("SELECT * FROM Siparis WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Onay"].ToString()));
                for (int i = 0; i < _dtSiparislerApp.Rows.Count; i++)
                {
                    _clsData._Metot_SQL_Calistir("UPDATE Siparis SET Durum=0 WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Onay"].ToString()));
                }
                _fnc_YeniSiparis();
                _fnc_GonderilenSiparis();
                _fnc_GonderilecekSiparis();
                Response.Redirect("Siparis.aspx?Komut=Yeni");
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Gonderildi"].ToString() != "")
            {
                _clsData._Metot_SQL_Calistir("UPDATE SiparisApp SET SiparisDurumID=2 WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Gonderildi"].ToString()));
                DataTable _dtSiparislerApp = _clsData._fncVeriGetir("SELECT * FROM Siparis WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Gonderildi"].ToString()));
                for (int i = 0; i < _dtSiparislerApp.Rows.Count; i++)
                {
                    _clsData._Metot_SQL_Calistir("UPDATE Siparis SET Durum=0 WHERE SiparisAppID=" + Guvenlik._SqlBugKontrol(Request.QueryString["Gonderildi"].ToString()));
                }
                _fnc_YeniSiparis();
                _fnc_GonderilenSiparis();
                _fnc_GonderilecekSiparis();
                Response.Redirect("Siparis.aspx?Komut=Gonderilecek");
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Goruntule"].ToString() != "")
            {                                     
                          _pnlTumu.Visible = false;
                        _pnlYeni.Visible = false;
                        _pnlGoruntule.Visible = true;
                        _fnc_SiparisGoruntule(Guvenlik._SqlBugKontrol(Request.QueryString["Goruntule"].ToString()));
                      
            }
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_SiparisGoruntule(string IdSiparis)
    {
        CultureInfo ci = new CultureInfo("en-us");
        DataTable _dtSiparis = new DataTable();
        try
        {
            _dtSiparis = _clsData._fncVeriGetir("SELECT dbo.Siparis.AdSoyad, dbo.Siparis.Toplam,dbo.Siparis.IPAdres,dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi, dbo.Yemek.Fiyat, dbo.Siparis.Aciklama, dbo.Siparis.Adres, dbo.Siparis.Telefon, dbo.OdemeTuru.OdemeAdi, dbo.Siparis.Miktar, dbo.Siparis.Durum FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE dbo.SiparisApp.SiparisAppID =" + IdSiparis.ToString());
            _lblAdSoyad.Text = _dtSiparis.Rows[0]["AdSoyad"].ToString();
            _lblOdemeTuru.Text = _dtSiparis.Rows[0]["OdemeAdi"].ToString();
            _lblTelefon.Text = _dtSiparis.Rows[0]["Telefon"].ToString();
            _lblAdres.Text = _dtSiparis.Rows[0]["Adres"].ToString();
           // _lblAciklama.Text = _dtSiparis.Rows[0]["Aciklama"].ToString();
            _lblIPAdres.Text = _dtSiparis.Rows[0]["IPAdres"].ToString();
            _lblSiparisTarih.Text = _dtSiparis.Rows[0]["SiparisTarihi"].ToString();
            if (Convert.ToBoolean(_dtSiparis.Rows[0]["Durum"])==false)
            {
                _pnlOnaylaButonu.Visible = false;
            }
            
        }
        catch (Exception)
        {
            
        }
        try
        {
            _dtEklenti = _clsData._fncVeriGetir("SELECT EklentiSiparis.EklentiSiparisID, EklentiKat.EklentiAdi, EklentiSiparis.Adet, EklentiSiparis.Tarih, EklentiKat.Fiyat, EklentiSiparis.Toplam, EklentiSiparis.SiparisAppID FROM EklentiSiparis INNER JOIN EklentiKat ON EklentiSiparis.EklentiKatID = EklentiKat.EklentiKatID WHERE EklentiSiparis.SiparisAppID=" + IdSiparis.ToString());
            _lstEklenti.DataSource = _dtEklenti;
            _lstEklenti.DataBind();
        }
        catch (Exception)
        {
            
        }
        try
        {
            DataTable _dtKisiSiparis = _clsData._fncVeriGetir("SELECT dbo.SiparisApp.SiparisAppID, Siparis.SiparisID,dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi, dbo.Yemek.Fiyat, dbo.Siparis.Aciklama, dbo.Siparis.Adres, dbo.Siparis.Telefon, dbo.OdemeTuru.OdemeAdi, dbo.Siparis.Miktar FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE dbo.SiparisApp.SiparisAppID =" + IdSiparis.ToString());
            //DataTable _dtKisiSiparis = _clsData._fncVeriGetir("SELECT dbo.Siparis.SiparisID, dbo.Yemek.YemekAdi, dbo.Siparis.Miktar, dbo.OdemeTuru.OdemeAdi, dbo.Siparis.AdSoyad, dbo.Siparis.Telefon, dbo.Siparis.SiparisTarihi, dbo.Siparis.Adres,dbo.Siparis.Aciklama, dbo.Siparis.Toplam, dbo.Siparis.YemekID FROM dbo.Siparis INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE SiparisID=" + IdSiparis.ToString());
            _lstKisiSiparisler.DataSource = _dtKisiSiparis;
            _lstKisiSiparisler.DataBind();
            HyperLink1.NavigateUrl = "Siparis.aspx?Onay=" + IdSiparis.ToString();
            for (int i = 0; i < _dtKisiSiparis.Rows.Count; i++)
            {
                Toplam += Convert.ToDouble(_dtKisiSiparis.Rows[i]["Toplam"]);
            }
            for (int i = 0; i < _dtEklenti.Rows.Count; i++)
            {
                Toplam += Convert.ToDouble(_dtEklenti.Rows[i]["Toplam"]);
            }
            _lblAciklama.Text = _dtKisiSiparis.Rows[0]["Aciklama"].ToString();
            _lblGenelToplam.Text = Toplam.ToString()+" TL";
           // _lblGenelToplam.Text = _dtKisiSiparis.Rows[0]["Toplam"].ToString()+" TL";
           // double Toplam = Convert.ToDouble(_dtKisiSiparis.Rows[0]) * Convert.ToDouble(_dtKisiSiparis.Rows[0]);
            foreach (Control k in _lstKisiSiparisler.Controls)
            {

                if (((RepeaterItem)k).ItemType == ListItemType.Item || ((RepeaterItem)k).ItemType == ListItemType.AlternatingItem)
                {
                   // Label _lbToplam2 = (Label)k.FindControl("_lblToplam").;
                }
            }
        }
        catch (Exception)
        {
            
        }
    }

    private void _fncAyar()
    {
        DataTable _dtAyar = _clsData._fncVeriGetir("SELECT * FROM Ayar");
        Image1.ImageUrl = "../"+_dtAyar.Rows[0]["Logo"].ToString();
    }
    private void _fnc_YeniSiparis()
    {
        try
        {
            _dtSiparis = _clsData._fncVeriGetir("SELECT Siparis.SiparisAppID, Siparis.SiparisID, Siparis.Miktar,Siparis.Telefon,OdemeTuru.OdemeAdi,dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN  dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE (dbo.SiparisApp.SiparisDurumID = 3) ORDER BY dbo.Siparis.SiparisAppID DESC");
            _lstSiparisler.DataSource = _dtSiparis;
            _lstSiparisler.DataBind();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_GonderilecekSiparis()
    {
        try
        {
            _dtSiparis = _clsData._fncVeriGetir("SELECT Siparis.SiparisAppID, Siparis.SiparisID, Siparis.Miktar,Siparis.Telefon,OdemeTuru.OdemeAdi,dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN  dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE (dbo.SiparisApp.SiparisDurumID = 1) ORDER BY dbo.Siparis.SiparisAppID DESC");
            _lstGonderilecek.DataSource = _dtSiparis;
            _lstGonderilecek.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_GonderilenSiparis()
    {
        try
        {
           DataTable _dtGonderilenSiparis = _clsData._fncVeriGetir("SELECT Siparis.SiparisAppID, Siparis.SiparisID, Siparis.Miktar,Siparis.Telefon,OdemeTuru.OdemeAdi,dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN  dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE (dbo.SiparisApp.SiparisDurumID = 2) ORDER BY dbo.Siparis.SiparisAppID DESC");
           //CollectionPager1.DataSource = _dtGonderilenSiparis.DefaultView;
           // CollectionPager1.BindToControl = _lstGonderilen;
           // _lstGonderilen.DataSource = cpSayfala.DataSourcePaged;
            _lstGonderilen.DataSource = _dtGonderilenSiparis;
            _lstGonderilen.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_TumSiparis()
    {
        try
        {
            _dtSiparis = _clsData._fncVeriGetir("SELECT Siparis.SiparisAppID, Siparis.SiparisID, Siparis.Miktar,Siparis.Telefon,OdemeTuru.OdemeAdi,dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID INNER JOIN  dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID WHERE (dbo.SiparisApp.SiparisDurumID = 4) ORDER BY dbo.Siparis.SiparisAppID DESC");
            cpSayfala.DataSource = _dtSiparis.DefaultView;
            cpSayfala.BindToControl = _lstTumSiparis;
            _lstTumSiparis.DataSource = cpSayfala.DataSourcePaged;
            _lstTumSiparis.DataBind();
        }
        catch (Exception)
        {

        }
    }
    protected void _lstKisiSiparisler_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Panel _pnlSiparisOnaylaButonu = (Panel)e.Item.FindControl("_pnlOnaylaButonu");
            _dtSiparisOnayla = _clsData._fncVeriGetir("select * from Siparis where YemekID=" + Request.QueryString["Goruntule"].ToString());
            if (Convert.ToInt32(_dtSiparisOnayla.Rows[0]["Durum"]) != 1)
            {
                _pnlSiparisOnaylaButonu.Visible = false;
            }
        }
        catch (Exception)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable _dtGonderilnSil = _clsData._fncVeriGetir("SELECT * FROM SiparisApp WHERE SiparisDurumID = 2");
        for (int i = 0; i < _dtGonderilnSil.Rows.Count; i++)
        {
            _clsData._Metot_SQL_Calistir("UPDATE SiparisApp SET SiparisDurumID = 4 WHERE SiparisDurumID = 2");
        }
        Response.Redirect("Siparis.aspx?Komut=Gonderilen");
    }
}