using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Odeme : System.Web.UI.Page
{
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    SqlConnection _cnn;
    SqlCommand _cmd;
    DataTable dt;
    DataTable _dtEklentiSepet;
    DataTable _dtOdeme;
    DataTable _dtEklentiSiparis;
    Data _clsData = new Data();
    DataTable _dtSiparisApp;
    Sepet _clsSepet = new Sepet();
    double toplam;
    private DataTable _dtMailUyari;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SepetGetir();
            _fnc_Odeme();
            if (Session["sepet"] == null)
            {
                Response.Redirect("Anasayfa.aspx");
            }
        }
    }
    private void _fnc_Odeme()
    {
        _dtOdeme = _clsData._fncVeriGetir("select * from OdemeTuru");
        _lstOdeme.DataSource = _dtOdeme;
        _lstOdeme.DataValueField = "OdemeID";
        _lstOdeme.DataTextField = "OdemeAdi";
        _lstOdeme.DataBind();
    }
    private void SepetGetir()
    {
        try
        {
            if (Session["sepet"] != null)
            {
                dt = (DataTable)Session["sepet"];
                _lstSepet.DataSource = dt.DefaultView;
                _lstSepet.DataBind();
                _lblToplam.Text = _clsSepet.SepetToplam().ToString() + " TL.";
                EklentiSepetGetir(Convert.ToDouble(_clsSepet.SepetToplam()));
            }
        }
        catch (Exception)
        {
            
        }
    }
    private void EklentiSepetGetir(double Ucret)
    {
        
        if (Session["Eklentisepet"] != null)
        {
            _dtEklentiSepet = (DataTable)Session["Eklentisepet"];
            _lstEklenti.DataSource = _dtEklentiSepet.DefaultView;
            _lstEklenti.DataBind();
            _lblEklentiToplam.Text = _clsSepet.EklentiToplam().ToString() + " TL.";
            toplam = Ucret + Convert.ToDouble(_clsSepet.EklentiToplam());
            _lblGenelToplam.Text = toplam.ToString() + " TL.";
            Session["GenelToplam"] = toplam.ToString();
        }
        else
        {
            _lblGenelToplam.Text = Ucret.ToString() + " TL.";
            Session["GenelToplam"] = Ucret.ToString();
        }
    }
    private void _fnc_Temizlik()
    {
        _txtAciklama.Text = "";
        _txtAdres.Text = "";
        _txtAdSoyad.Text = "";
        _txtTelefon.Text = "";
        _lstOdeme.SelectedIndex = -1;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //SepetGetir();
        _cnn = new SqlConnection(Baglan);
        _cnn.Open();
        try
        {
            _cmd = new SqlCommand("INSERT INTO SiparisApp (AdSoyad,SiparisAppTarih,Tutar,SiparisDurumID) VALUES (@AdSoyad,@SiparisAppTarih,@Tutar,@SiparisDurumID)", _cnn);
            _cmd.Parameters.AddWithValue("AdSoyad", _txtAdSoyad.Text);
            _cmd.Parameters.AddWithValue("SiparisAppTarih", Convert.ToDateTime(DateTime.Now));
            _cmd.Parameters.AddWithValue("Tutar", Convert.ToDouble(Session["GenelToplam"]));
            _cmd.Parameters.AddWithValue("SiparisDurumID", 3);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _dtSiparisApp = _clsData._fncVeriGetir("SELECT TOP 1 SiparisAppID FROM SiparisApp ORDER BY SiparisAppID DESC");
        }
        catch (Exception ex)
        {
            _lblSiparisTamamlandi.Text = "Siparişiniz Alındı.";
            //_lblSiparisTamamlandi.Text = ex.Message.ToString() + "1";
        }
        try
        {
            _dtEklentiSepet = (DataTable)Session["Eklentisepet"];
            for (int i = 0; i < _dtEklentiSepet.Rows.Count; i++)
            {

                _cmd = new SqlCommand("INSERT INTO EklentiSiparis (EklentiKatID,SiparisAppID,Adet,Tarih,Toplam) VALUES (@EklentiKatID,@SiparisAppID,@Adet,@Tarih,@Toplam)", _cnn);
                _cmd.Parameters.AddWithValue("EklentiKatID", Convert.ToInt32(_dtEklentiSepet.Rows[i]["id"]));
                _cmd.Parameters.AddWithValue("SiparisAppID", Convert.ToInt32(_dtSiparisApp.Rows[0]["SiparisAppID"]));
                _cmd.Parameters.AddWithValue("Adet", Convert.ToInt32(_dtEklentiSepet.Rows[i]["adet"]));
                _cmd.Parameters.AddWithValue("Tarih", Convert.ToDateTime(DateTime.Now));
                _cmd.Parameters.AddWithValue("Toplam", Convert.ToDouble(_dtEklentiSepet.Rows[i]["tutar"]));
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
        }
        catch (Exception ex)
        {
            _lblSiparisTamamlandi.Text = "Siparişiniz Alındı.";
        }
        try
        {
            dt = (DataTable)Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _cmd = new SqlCommand("INSERT INTO Siparis (YemekID,Miktar,OdemeID,IPAdres,AdSoyad,Telefon,Adres,Aciklama,SiparisTarihi,Toplam,Durum,SiparisAppID) VALUES (@YemekID,@Miktar,@OdemeID,@IPAdres,@AdSoyad,@Telefon,@Adres,@Aciklama,@SiparisTarihi,@Toplam,@Durum,@SiparisAppID)", _cnn);
                _cmd.Parameters.AddWithValue("YemekID", Convert.ToInt32(dt.Rows[i]["id"]));
                _cmd.Parameters.AddWithValue("Miktar", Convert.ToInt32(dt.Rows[i]["adet"]));
                _cmd.Parameters.AddWithValue("OdemeID", Convert.ToInt32(_lstOdeme.SelectedValue));
                _cmd.Parameters.AddWithValue("IPAdres", Session["IPAdres"].ToString());
                _cmd.Parameters.AddWithValue("AdSoyad", _txtAdSoyad.Text);
                _cmd.Parameters.AddWithValue("Telefon", _txtTelefon.Text);
                _cmd.Parameters.AddWithValue("Adres", _txtAdres.Text);
                _cmd.Parameters.AddWithValue("Aciklama", _txtAciklama.Text);
                _cmd.Parameters.AddWithValue("SiparisTarihi", Convert.ToDateTime(DateTime.Now));
                _cmd.Parameters.AddWithValue("Toplam", Convert.ToDouble(dt.Rows[i]["tutar"]));
                _cmd.Parameters.AddWithValue("Durum", 1);
                _cmd.Parameters.AddWithValue("SiparisAppID", Convert.ToInt32(_dtSiparisApp.Rows[0]["SiparisAppID"]));
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
            _cnn.Close();
            _lblSiparisTamamlandi.Text = "Siparişiniz Alındı.";
            _fncMailUyari();
        }
        catch (Exception ex)
        {
            _lblSiparisTamamlandi.Text = "Siparişiniz Alındı.";
        }
        _cmd.Dispose();
        _cnn.Close();
        Session.Clear();
    }

    private void _fncMailUyari()
    {
        _dtMailUyari = _clsData._fncVeriGetir("SELECT * FROM MailAyar");
        if (Convert.ToBoolean(_dtMailUyari.Rows[0]["Durum"]) == true)
        {
            Mail._fncSiparisBilgileri(dt, _dtEklentiSepet, _txtAdSoyad.Text, _txtTelefon.Text, _lstOdeme.SelectedItem.Text,
    _txtAdres.Text, _lblGenelToplam.Text, _dtMailUyari.Rows[0]["AliciMail"].ToString(), _dtMailUyari.Rows[0]["GonderenMail"].ToString(), _dtMailUyari.Rows[0]["Sifre"].ToString(), _dtMailUyari.Rows[0]["Smtp"].ToString(), Convert.ToInt32(_dtMailUyari.Rows[0]["Port"]), _dtMailUyari.Rows[0]["Konu"].ToString());
        }
    }
    private void _fncSiparisTopla()
    {
        DataTable _dtSiparisGel = _clsData._fncVeriGetir("SELECT TOP 1 * FROM Siparis ORDER BY SiparisID DESC");
        _cnn = new SqlConnection(Baglan);
        _cnn.Open();
    }
}