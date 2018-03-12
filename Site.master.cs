using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Net;

public partial class Site : System.Web.UI.MasterPage
{
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    Data _clsData = new Data();
    DataTable _dtAyar;
    DataTable _dtLisanslama;
    TimeSpan fark;
    string Url;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["IPAdres"] = Request.ServerVariables["REMOTE_ADDR"];
        if (!Page.IsPostBack)
        {
          //  _fncLisanslama();
            _fnc_Ayar();
            _fnc_Kategoriler();
            _lblTarih.Text = DateTime.Now.ToLongDateString();
            SepetGetir();
        }
    }
    private void _fnc_Kategoriler()
    {
        try
        {
            _lstUstMenu.DataSource = _clsData._fncVeriGetir("select * from Kategori");
            _lstUstMenu.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    private void _fncLisanslama()
    {
        string GetUrl = HttpContext.Current.Request.Url.Host.ToString();
        DataTable _dtLisanslama = new DataTable();
        try
        {
            net.mercanyazilim.LisansSorgulama webservis = new net.mercanyazilim.LisansSorgulama();
            _dtLisanslama = webservis._fncLisansSorgulama(GetUrl);
        }
        catch (IndexOutOfRangeException ex)
        {
            _pnlKapat.Visible = false;
            Mail._fncLisansMailGonder(_dtLisanslama.Rows[0]["WebAdres"].ToString(), HttpContext.Current.Request.Url.Host.ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Write("<br><br><br><br><br><br><br><br><br><center><font size='5'>Lisanssız Kullanım!</font></center>");
        }
        catch (WebException ex)
        {
            //Mesaj.Body = "Lisanslanan Domain : " + LisanslananDomain.ToString() + " <br><br>Kullanılan Domain : " + KullanilanDomain.ToString() + " <br><br>IP Adres : " + IPAdres.ToString() + "<br><br> Tarih :" + DateTime.Now.ToLongTimeString();
            //  Mail._fncMailGonder("yavuz@mercanyazilim.net","Lisans Hata Robotu",HttpContext.Current.Request.Url.Host.ToString() +" Adresinden Hata alındı. <br><br> Çözüm ; <br> 1-| Web Servisinizin Çalışıp Çalışmadığını Kontrol Ediniz.<br> 2-| Lisansın <br>"+ex.Message.ToString());
            //Response.Write("<br><br><br><br><br><br><br><br><br><center><font size='5'>Hata! : " + ex.Message.ToString() + "</font></center>");
        }
        finally
        {

        }

        try
        {
            DateTime BitisTarih = Convert.ToDateTime(_dtLisanslama.Rows[0]["BitisTarihi"]);
            fark = BitisTarih - DateTime.Now;
            Url = _dtLisanslama.Rows[0]["WebAdres"].ToString();
        }
        catch (Exception)
        {
            
        }
            if (_dtLisanslama.Rows.Count != null)
            {
                if (Url != GetUrl)
                {
                    try
                    {
                        _pnlKapat.Visible = false;
                        Mail._fncLisansMailGonder(_dtLisanslama.Rows[0]["WebAdres"].ToString(), HttpContext.Current.Request.Url.Host.ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    }
                    catch (Exception)
                    {

                    }
                    Response.Write("<br><br><br><br><br><br><br><br><br><center><font size='5'>Lisanssız Kullanım!</font></center>");

                }
                else
                {
                if (fark.Hours < 1)
                {
                    _pnlKapat.Visible = false;
                    Mail._fncLisansMailGonder(_dtLisanslama.Rows[0]["WebAdres"].ToString(), HttpContext.Current.Request.Url.Host.ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    Response.Write("<br><br><br><br><br><br><br><br><br><center><font size='5'>Lisans Süreniz Doldu!</font></center>");
                }
             } 
            }

    }
    private void _fnc_Ayar()
    {
        try
        {
            _dtAyar = _clsData._fncVeriGetir("select * from Ayar");
            _lblTitle.Text = _dtAyar.Rows[0]["Title"].ToString();
            Page.Title = _dtAyar.Rows[0]["Title"].ToString();
            Page.MetaDescription = _dtAyar.Rows[0]["Aciklama"].ToString();
            Page.MetaKeywords = _dtAyar.Rows[0]["AnahtarKelime"].ToString();
            _lblFooter.Text = _dtAyar.Rows[0]["Footer"].ToString();
            Image1.ImageUrl = _dtAyar.Rows[0]["Logo"].ToString();
        }
        catch (Exception)
        {
            
        }
    }
    private void SepetGetir()
    {
        try
        {
            if (Session["sepet"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["sepet"];
                _lstSepet.DataSource = dt.DefaultView;
                _lstSepet.DataBind();
                _lblToplam.Text = SepetToplam().ToString() + " TL.";
                _lblToplam2.Text = SepetToplam().ToString() + " TL.";
                _lblAdet.Text = dt.Rows.Count.ToString() + " Adet";
            }
        }
        catch (Exception)
        {
            
        }
    }
    public double SepetToplam()
    {
            double toplam = 0;//toplam değişkeni tanımlanıyor
            if (HttpContext.Current.Session["sepet"] != null)//sessiomn kontolü yapılıyor
            {
                DataTable dt = new DataTable();//tablo oluşturuluyor
                dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
                for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
                {
                    toplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
                }
            }
            return toplam; //toplam değeri döndürülüyor.
    }
}
