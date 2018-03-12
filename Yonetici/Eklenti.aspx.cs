using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_Eklenti : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _pnlListe.Visible = false;
            _pnlEkle.Visible = false;
            _drpKategori.Visible = true;
            _fnc_Kategori();
            _fnc_Yemekler();
        }
        try
        {
            if (Request.QueryString["Komut"] != "")
            {
                string Komut = Request.QueryString["Komut"].ToString();
                switch (Komut)
                {
                    case "Ekle":
                        _pnlListe.Visible = false;
                        _pnlEkle.Visible = true;
                        break;
                    case "Listele":
                        _pnlListe.Visible = true;
                        _pnlEkle.Visible = false;
                        break;
                }

            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Sil"].ToString() != "")
            {
                _clsData._Metot_SQL_Calistir("DELETE FROM EklentiKat WHERE EklentiKatID=" + Request.QueryString["Sil"].ToString());
                _fnc_Yemekler();
                Response.Redirect("Eklenti.aspx?Komut=Listele");
            }
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_Kategori()
    {
        _drpKategori.DataSource = _clsData._fncVeriGetir("select * from EklentiKat where AltEklentiID=0");
        _drpKategori.DataTextField = "EklentiAdi";
        _drpKategori.DataValueField = "EklentiKatID";
        _drpKategori.DataBind();
    }
    private void _fnc_Yemekler()
    {
        _lstYemekler.DataSource = _clsData._fncVeriGetir("select * from EklentiKat ORDER BY EklentiKatID DESC");
        _lstYemekler.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO EklentiKat (EklentiAdi,AltEklentiID,Resim,Fiyat) VALUES (@EklentiAdi,@AltEklentiID,@Resim,@Fiyat)", _cnn);
            _cmd.Parameters.AddWithValue("EklentiAdi", _txtEklentiAdi.Text);
            if (CheckBox1.Checked==true)
            {
                _cmd.Parameters.AddWithValue("AltEklentiID", 0);
            }
            else
            {
                _cmd.Parameters.AddWithValue("AltEklentiID", Convert.ToInt32(_drpKategori.SelectedValue));
            }
            
            _cmd.Parameters.AddWithValue("Resim", "Upload/" + FileUpload1.FileName.ToString());
            _fnc_ResimYükle();
            if (_txtFiyat.Text != "")
            {
                _cmd.Parameters.AddWithValue("Fiyat", Convert.ToDouble(_txtFiyat.Text));
            }
            else
            {
                _cmd.Parameters.AddWithValue("Fiyat", Convert.ToDouble(0)); 
            }
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _cnn.Close();
            _lblKayit.Text = "Eklenti Başarıyla Kayıt Edildi.";
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_ResimYükle()
    {
        try
        {
            if (Directory.Exists(Server.MapPath("~/Upload/")))
            {
                FileUpload1.SaveAs(Server.MapPath("~/Upload/") + FileUpload1.FileName);

            }
            else
            {
                Directory.CreateDirectory(Server.MapPath("~/Upload/"));
                FileUpload1.SaveAs(Server.MapPath("~/Upload/") + FileUpload1.FileName);
            }
        }
        catch (Exception)
        {

        }

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked ==true)
        {
            _drpKategori.Visible = false;
        }
    }
}