using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_UyariMailAyar : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    private DataTable _dtUyari;
    private DataTable _dtDurum;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Ayar();
        }
    }
    private void _fnc_Ayar()
    {
        try
        {
            _dtUyari = _clsData._fncVeriGetir("select * from MailAyar");
            _txtAliciMail.Text = _dtUyari.Rows[0]["AliciMail"].ToString();
            _txtGonderenMail.Text = _dtUyari.Rows[0]["GonderenMail"].ToString();
            _txtSifre.Text = _dtUyari.Rows[0]["Sifre"].ToString();
            _txtSmtpMail.Text = _dtUyari.Rows[0]["Smtp"].ToString();
            _txtPortNo.Text = _dtUyari.Rows[0]["Port"].ToString();
            _txtMailKonusu.Text = _dtUyari.Rows[0]["Konu"].ToString();
            _chkUyari.Checked = Convert.ToBoolean(_dtUyari.Rows[0]["Durum"]);
        }
        catch (Exception)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        _dtDurum = _clsData._fncVeriGetir("select * from MailAyar");

        try
        {
            if (1 == Convert.ToInt32(_dtDurum.Rows[0]["MailID"]))
            {
                _fncGuncelle();
            }
        }
        catch (IndexOutOfRangeException)
        {
            _fncEkle();
        }

    }
    private void _fncGuncelle()
    {
                    try
            {
                _cnn = new SqlConnection(Baglan);
                _cnn.Open();
                _cmd = new SqlCommand("UPDATE MailAyar SET AliciMail = @AliciMail,GonderenMail = @GonderenMail,Sifre = @Sifre,Smtp= @Smtp,Port= @Port,Konu= @Konu,Durum= @Durum", _cnn);
                _cmd.Parameters.AddWithValue("AliciMail", _txtAliciMail.Text);
                _cmd.Parameters.AddWithValue("GonderenMail", _txtGonderenMail.Text);
                _cmd.Parameters.AddWithValue("Sifre", _txtSifre.Text);
                _cmd.Parameters.AddWithValue("Smtp", _txtSmtpMail.Text);
                _cmd.Parameters.AddWithValue("Port", _txtPortNo.Text);
                _cmd.Parameters.AddWithValue("Konu", _txtMailKonusu.Text);
                _cmd.Parameters.AddWithValue("Durum", Convert.ToBoolean(_chkUyari.Checked));
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
                _cnn.Close();
                _lblDurumu.Text = "Uyarı Ayarlarınız Başarıyla Güncellendi.";
                _fnc_Ayar(); ;
            }
            catch (Exception)
            {

            }
    }
    private void _fncEkle()
    {
                   try
            {
                _cnn = new SqlConnection(Baglan);
                _cnn.Open();
                _cmd = new SqlCommand("INSERT INTO MailAyar (AliciMail,GonderenMail,Sifre,Smtp,Port,Konu,Durum) VALUES (@AliciMail,@GonderenMail,@Sifre,@Smtp,@Port,@Konu,@Durum)", _cnn);
                _cmd.Parameters.AddWithValue("AliciMail", _txtAliciMail.Text);
                _cmd.Parameters.AddWithValue("GonderenMail", _txtGonderenMail.Text);
                _cmd.Parameters.AddWithValue("Sifre", _txtSifre.Text);
                _cmd.Parameters.AddWithValue("Smtp", _txtSmtpMail.Text);
                _cmd.Parameters.AddWithValue("Port", _txtPortNo.Text);
                _cmd.Parameters.AddWithValue("Konu", _txtMailKonusu.Text);
                _cmd.Parameters.AddWithValue("Durum", Convert.ToBoolean(_chkUyari.Checked));
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
                _cnn.Close();
                _lblDurumu.Text = "Uyarı Ayarlarınız Başarıyla Eklendi.";
                _fnc_Ayar(); ;
            }
            catch (Exception)
            {

            } 
    }
}