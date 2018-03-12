using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Yonetici_Default : System.Web.UI.Page
{
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    Data _clsData = new Data();
    DataTable _dtIstatistik;
    DataTable _dtSonSiparis;
    DataTable _dtSonMesaj;
    SqlConnection _cnn;
    SqlCommand _cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Panel1.Visible = false;
            _fnc_Istatistik();
            _fnc_Olaylar();
            _fnc_Hatirlatma();
            _fnc_Kur();
        }
        try
        {
            if (Request.QueryString["myp"].ToString()=="Cikis")
            {
                Session.Abandon();
                Response.Redirect("Giris.aspx");
            }
        }
        catch (Exception)
        {
            
        }
        try
        {
            if (Request.QueryString["sil"].ToString() != "")
            {
                _clsData._fncSQLCalistir("DELETE FROM Hatirlat WHERE HatirlatID=" + Request.QueryString["sil"].ToString());
                _fnc_Hatirlatma();
            }
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_Istatistik()
    {
        try
        {
            _dtIstatistik = _clsData._fncVeriGetir("select * from Mesaj where Durum=1");
            _lblYeniMesaj.Text = _dtIstatistik.Rows.Count.ToString();
            _dtIstatistik = _clsData._fncVeriGetir("select * from SiparisApp where SiparisDurumID=3");
            _lblYeniSiparis.Text = _dtIstatistik.Rows.Count.ToString();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_Kur()
    {
        try
        {
            Doviz _clsDoviz = new Doviz();
            DataTable _dtKur = _clsDoviz.source();
            _lblDolarAlis.Text = _dtKur.Rows[0][2].ToString() + " " + _dtKur.Rows[0][1].ToString();
            _lblDolarSatis.Text = _dtKur.Rows[0][3].ToString() + " " + _dtKur.Rows[0][1].ToString();
            _lblEuroAlis.Text = _dtKur.Rows[3][2].ToString() + " " + _dtKur.Rows[3][1].ToString();
            _lblEuroSatis.Text = _dtKur.Rows[3][3].ToString() + " " + _dtKur.Rows[3][1].ToString();
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_Hatirlatma()
    {
        _lstHatirlatma.DataSource = _clsData._fncVeriGetir("select * from Hatirlat");
        _lstHatirlatma.DataBind();

        _lstHatirlat.DataSource = _clsData._fncVeriGetir("select TOP 5 * from Hatirlat");
        _lstHatirlat.DataBind();
    }
    private void _fnc_Olaylar()
    {
        try
        {
            _dtSonMesaj = _clsData._fncVeriGetir("select * from Mesaj where Durum=1 ORDER BY Tarih DESC");
            //_dtSonSiparis = _clsData._fncVeriGetir("SELECT TOP 5 dbo.Siparis.SiparisID, dbo.Yemek.YemekAdi, dbo.Siparis.Miktar,dbo.Siparis.AdSoyad, dbo.Siparis.Telefon, dbo.Siparis.SiparisTarihi,dbo.OdemeTuru.OdemeAdi, dbo.Siparis.Toplam FROM dbo.Siparis INNER JOIN  dbo.OdemeTuru ON dbo.Siparis.OdemeID = dbo.OdemeTuru.OdemeID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID WHERE Durum=1 ORDER BY SiparisTarihi DESC");
            _dtSonSiparis = _clsData._fncVeriGetir("SELECT TOP (100) PERCENT SiparisApp.SiparisAppID, Siparis.SiparisID, dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.SiparisApp.SiparisDurumID, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID WHERE     (dbo.SiparisApp.SiparisDurumID = 3) ORDER BY dbo.Siparis.SiparisAppID DESC");
        //_dtSonSiparis = _clsData._fncVeriGetir("SELECT TOP (100) PERCENT SiparisApp.SiparisAppID, Siparis.SiparisID, dbo.Siparis.AdSoyad, dbo.Siparis.Toplam, dbo.SiparisApp.Durum, dbo.Siparis.SiparisTarihi, dbo.Yemek.YemekAdi FROM dbo.Siparis INNER JOIN dbo.SiparisApp ON dbo.Siparis.SiparisAppID = dbo.SiparisApp.SiparisAppID INNER JOIN dbo.Yemek ON dbo.Siparis.YemekID = dbo.Yemek.YemekID WHERE     (dbo.SiparisApp.Durum = 1) ORDER BY dbo.Siparis.SiparisAppID DESC");
        _lstSonSiparis.DataSource = _dtSonSiparis;
        _lstSonSiparis.DataBind();
        _lstSonMesajlar.DataSource = _dtSonMesaj;
        _lstSonMesajlar.DataBind();
        }
        catch (Exception)
        {
            
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Hatirlat (Baslik,Konu,Tarih) VALUES (@Baslik,@Konu,@Tarih)", _cnn);
            _cmd.Parameters.AddWithValue("Baslik", TextBox1.Text);
            _cmd.Parameters.AddWithValue("Konu", TextBox2.Text);
            _cmd.Parameters.AddWithValue("Tarih", Convert.ToDateTime(DateTime.Now));
            _cmd.ExecuteNonQuery();
            _cnn.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            _fnc_Hatirlatma();
            Response.Write("<script lang='JavaScript'>alert('Hatırlatma Eklendi.');</script>");
        }
        catch (Exception)
        {
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}