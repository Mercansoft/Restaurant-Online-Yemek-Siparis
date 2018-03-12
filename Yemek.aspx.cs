using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;

public partial class Yemek : System.Web.UI.Page
{
    DataTable _dtYemek;
    DataTable _dtSiparis;
    DataTable _dtSiparisEklenti;
    DataTable _dtEklenti;
    DataTable _dtEklentiAd;
    Data _clsData = new Data();
    Sepet _clsSepet = new Sepet();
    int YemekID = 0;
    int YemekHit = 0;
    DataTable _dtYemekEklenti;
    DataTable _dtAyarlar;
    SqlConnection _cnn;
    SqlCommand _cmd;
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fncSpetGetir();
        }
        _fncSpetGetir();
        try
        {
            string katID = Guvenlik._SqlBugKontrol(Request.QueryString["EklentiSil"].ToString());
            if (katID != "")
            {
                _clsSepet.EklentiSil(katID);
                Response.Redirect("Yemek.aspx?myp=" + Session["YemekID"].ToString());
            }
        }
        catch (Exception)
        {
           
        }
        try
        {
            string katID = Guvenlik._SqlBugKontrol(Request.QueryString["myp"].ToString());
            if (katID != "")
            {
                try
                {
                    YemekID = Convert.ToInt32(katID);
                    Session["YemekID"] = YemekID;
                    if (!Page.IsPostBack)
                    {
                        _fncEklentiler(YemekID.ToString());
                    }

                    _dtYemek = _clsData._fncVeriGetir("SELECT dbo.Yemek.YemekID, dbo.Yemek.YemekAdi, Yemek.EklentiKatID, dbo.Yemek.KategoriID,dbo.Kategori.KategoriAdi, dbo.Yemek.BuyukResim, dbo.Yemek.Fiyat, dbo.Yemek.YemekAciklama, dbo.Yemek.Hit FROM  dbo.Yemek INNER JOIN dbo.Kategori ON dbo.Yemek.KategoriID = dbo.Kategori.KategoriID where YemekID=" + Session["YemekID"].ToString());
                    Session["Yemek"] = _dtYemek;
                    // HyperLink1.NavigateUrl = "Yemek.aspx?myp=" + _dtYemek.Rows[0]["YemekID"].ToString(); 
                    _lblYemekAdi2.Text = _dtYemek.Rows[0]["YemekAdi"].ToString();
                    _imgYemek.ImageUrl = _dtYemek.Rows[0]["BuyukResim"].ToString();
                    _lblYemekTuru.Text = _dtYemek.Rows[0]["KategoriAdi"].ToString();
                    _lblAciklama.Text = _dtYemek.Rows[0]["YemekAciklama"].ToString();
                    zoom1.HRef = _dtYemek.Rows[0]["BuyukResim"].ToString();
                    var ulke = CultureInfo.GetCultureInfo("tr-TR");
                    var parabirimi = (NumberFormatInfo)ulke.NumberFormat.Clone();
                    parabirimi.CurrencySymbol = "TL";
                    double fiyat = Convert.ToDouble(_dtYemek.Rows[0]["Fiyat"]);
                    _lblFiyat.Text = (fiyat.ToString("C", parabirimi));
                    //_lstYemek.DataSource = _dtYemek;   <%#String.Format("{0:C}",Eval("Fiyat")) %>
                    //_lstYemek.DataBind();
                    YemekHit = Convert.ToInt32(_dtYemek.Rows[0]["Hit"]);
                    YemekHit += 1;
                    _lblYemekAdi.Text = _dtYemek.Rows[0]["YemekAdi"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx");
                }
                try
                {
                    _clsData._Metot_SQL_Calistir("UPDATE Yemek SET Hit=" + YemekHit.ToString() + " where YemekID=" + Guvenlik._SqlBugKontrol(Request.QueryString["myp"].ToString()));
                }
                catch (Exception)
                {

                }
                try
                {
                    _lstOnerilenYemekler.DataSource = _clsData._fncVeriGetir("select TOP 4 * from Yemek where KategoriID= " + _dtYemek.Rows[0]["KategoriID"].ToString() + " ORDER BY YemekID DESC");
                    _lstOnerilenYemekler.DataBind();
                }
                catch (Exception)
                {

                }
            }
        }
        catch (Exception)
        {

        }
    }
    private void _fncEklentiler(string Yemek_ID)
    {
        try
        {
            _dtSiparisEklenti = _clsData._fncVeriGetir("SELECT * FROM Yemek WHERE YemekID=" + Yemek_ID.ToString());
            _dtEklenti = _clsData._fncVeriGetir("SELECT * FROM EklentiKat WHERE EklentiKatID=" + _dtSiparisEklenti.Rows[0]["EklentiKatID"].ToString());
            _dtEklentiAd  = _clsData._fncVeriGetir("select * from EklentiKat where AltEklentiID=" + _dtEklenti.Rows[0]["EklentiKatID"].ToString());
            _drpEklenti.DataSource = _dtEklentiAd;
            _drpEklenti.DataValueField = "EklentiKatID";
            _drpEklenti.DataTextField = "EklentiAdi";
            _drpEklenti.DataBind();
        }
        catch (Exception)
        {
            _pnlEklenti.Visible = false;
        }
    }

    private void _fncSpetGetir()
    {
        try
        {
            if (Session["Eklentisepet"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["Eklentisepet"];
                _lstEklentiler.DataSource = dt.DefaultView;
                _lstEklentiler.DataBind();
            }
        }
        catch (Exception)
        {
            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _dtYemek = (DataTable)Session["Yemek"];
            string _id=Session["YemekID"].ToString();
            string _ad = _lblYemekAdi2.Text;
            string _resim = _imgYemek.ImageUrl.ToString();
            int _adet = Convert.ToInt32(_txtAdet.Text);
            double _fiyat = Convert.ToDouble(_dtYemek.Rows[0]["Fiyat"]);
            _clsSepet.Ekle(_id, _ad, _resim, _adet, _fiyat);
        }
        catch (Exception)
        {
            
        }
        //Response.Redirect("Siparis.aspx?myp=" + Session["YemekID"].ToString());
        Response.Redirect("Siparis.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _dtEklenti = _clsData._fncVeriGetir("SELECT * FROM EklentiKat WHERE EklentiKatID=" + _drpEklenti.SelectedValue.ToString());
            _clsSepet.EklentiEkle(_drpEklenti.SelectedValue.ToString(), _dtEklenti.Rows[0]["EklentiAdi"].ToString(), _dtEklenti.Rows[0]["Resim"].ToString(), 1, Convert.ToDouble(_dtEklenti.Rows[0]["Fiyat"].ToString()));
        }
        catch (Exception)
        {
            
        }
         _fncSpetGetir();
    }
}