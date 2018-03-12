using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Yonetici_Yonetici : System.Web.UI.Page
{
    Data _clsData = new Data();
    SqlConnection _cnn;
    SqlCommand _cmd;
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Yoneticiler();
            _pnlYoneticiEkle.Visible = false;
            _pnlYoneticiTablosu.Visible = false;

            try
            {
                if (Request.QueryString["myp"].ToString() != "")
                {
                    switch (Request.QueryString["myp"].ToString())
                    {
                        case "Ekle":
                            _pnlYoneticiEkle.Visible = true;
                            _pnlYoneticiTablosu.Visible = false;
                            break;
                        case "Listele":
                            _pnlYoneticiTablosu.Visible = true;
                            _pnlYoneticiEkle.Visible = false;
                            _fnc_Yoneticiler();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        try
        {
            if (Request.QueryString["Sil"].ToString()!="")
            {
               // _clsData._fncSQLCalistir("DELETE FROM Yonetici WHERE YoneticiID="+Request.QueryString["Sil"].ToString());
                Response.Redirect("Yonetici.aspx?myp=Listele");
            }
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_Yoneticiler()
    {
        _lstYoneticilerListesi.DataSource = _clsData._fncVeriGetir("select * from Yonetici");
        _lstYoneticilerListesi.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Yonetici (KullaniciAdi,Sifre,Email,Isim,Soyisim) VALUES (@KullaniciAdi,@Sifre,@Email,@Isim,@Soyisim)", _cnn);
            _cmd.Parameters.AddWithValue("KullaniciAdi", _txtKullaniciAdi.Text);
            _cmd.Parameters.AddWithValue("Sifre", _txtSifre.Text);
            _cmd.Parameters.AddWithValue("Email", _txtEmail.Text);
            _cmd.Parameters.AddWithValue("Isim", _txtAdi.Text);
            _cmd.Parameters.AddWithValue("Soyisim", _txtSoyadi.Text);
           // _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _cnn.Close();
            _lblDurum.Text = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><strong>Tebrikler!</strong> Yönetici Başarıyla Kayıt Edildi.</div>";
        }
        catch (Exception)
        {

        }
    }
}