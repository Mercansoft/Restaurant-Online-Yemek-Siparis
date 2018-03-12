using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Media;
using System.Threading;
using System.IO;
using System.Globalization;

public partial class Yonetici_Admin : System.Web.UI.MasterPage
{
    private Data _clsData = new Data();
    private DataTable _dtYonetici;
    private DataTable _dtMesaj;
    public string _deger;
    DataTable _dtVeritabaniBilgileri;
    DataTable _dtUyariAyar;
    DataTable _dtSes;
    DataTable _iNtSiparis;
    SiparisServis _WebServis = new SiparisServis();
    protected void Page_Load(object sender, EventArgs e)
    {
        _fncSiparisSayisi();
        if (!Page.IsPostBack)
        {
            _WebServis._FncSiparis();
           // _fncSure();
           if (Session["YoneticiID"] == null)
            {
                Response.Redirect("Giris.aspx");
            }
            _lblTarih.Text = DateTime.Now.ToLongDateString();
            _fnc_Yonetici();
            _fncVeritabaniBoyutu();
            _fncDiskBouyutu();
            _fncUyariSistemi();
        }
        //_fncSure();
        _fncVeritabaniBoyutu();
        _fncDiskBouyutu();
        _fncUyariSistemi();
        
    }

    private void _fncSiparisSayisi()
    {
        try
        {
            DataTable _dtYeniSiparis = _clsData._fncVeriGetir("SELECT * FROM SiparisApp WHERE SiparisDurumID=3");
            DataTable _dtGonderilecekSiparis = _clsData._fncVeriGetir("SELECT * FROM SiparisApp WHERE SiparisDurumID=1");
            DataTable _dtGonderilenSiparis = _clsData._fncVeriGetir("SELECT * FROM SiparisApp WHERE SiparisDurumID=2");
            _lblGonderilecekSiparis.Text = _dtGonderilecekSiparis.Rows.Count.ToString();
            _lblYeniGelenSiparis.Text = _dtYeniSiparis.Rows.Count.ToString();
            _lblGonderilenSiparis.Text = _dtGonderilenSiparis.Rows.Count.ToString();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_Yonetici()
    {
        try
        {
            _dtYonetici = _clsData._fncVeriGetir("select * from Yonetici where YoneticiID=" + Session["YoneticiID"].ToString());
            _lblYoneticiAdi.Text = _dtYonetici.Rows[0]["KullaniciAdi"].ToString();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fncSure()
    {
        try
        {
            net.mercanyazilim.LisansSorgulama webservis = new net.mercanyazilim.LisansSorgulama();
          //  MercanYazilimLisans.LisansSorgulamaSoapClient WebServis = new MercanYazilimLisans.LisansSorgulamaSoapClient();
            //ServiceReference1.LisansSorgulamaSoapClient sdas = new ServiceReference1.LisansSorgulamaSoapClient();
            DataTable _dtSure = webservis._fncLisansSorgulama(HttpContext.Current.Request.Url.Host.ToString());
            DateTime BitisTarih = Convert.ToDateTime(_dtSure.Rows[0]["BitisTarihi"]);
            TimeSpan fark = BitisTarih - DateTime.Now;
            string Url = _dtSure.Rows[0]["WebAdres"].ToString();
            _lblLisans.Text = fark.Days.ToString() + " Gün " + fark.Hours.ToString() + " Saat Kaldı";
            if (Url != HttpContext.Current.Request.Url.Host.ToString())
            {
                try
                {
                    _pnlYonetim.Visible = false;
                    Mail._fncLisansMailGonder(_dtSure.Rows[0]["WebAdres"].ToString(), HttpContext.Current.Request.Url.Host.ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
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
                    _pnlYonetim.Visible = false;
                    Mail._fncLisansMailGonder(_dtSure.Rows[0]["WebAdres"].ToString(), HttpContext.Current.Request.Url.Host.ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    Response.Write("<br><br><br><br><br><br><br><br><br><center><font size='5'>Lisans Süreniz Doldu!</font></center>");
                }
            }
        }
        catch (Exception)
        {
          _lblLisans.Text = "null";
        }
    }
    private void _fncUyariSistemi()
    {
        try
        {
            _iNtSiparis = _clsData._fncVeriGetir("SELECT Durum FROM Siparis WHERE Durum=1");
            if (_iNtSiparis.Rows.Count!= 0)
            {
            _dtUyariAyar = _clsData._fncVeriGetir("select * from UyariAyar");
            if (Convert.ToBoolean(_dtUyariAyar.Rows[0]["Durum"])==true)
            {
                int sure = Convert.ToInt32(_dtUyariAyar.Rows[0]["Sure"])*60;
                int Zaman = sure * 1000;
                Timer1.Enabled = true;
                Timer1.Interval = Zaman;
            }
            }
        }
        catch (Exception)
        {
            
        }
    }
    private void _fncVeritabaniBoyutu()
    {
        try
        {
            _dtVeritabaniBilgileri = _clsData._fncVeriGetir("use [MercanRestorant] exec sp_helpdb MercanRestorant");
            _lblVeritabaniBoyutu.Text = _dtVeritabaniBilgileri.Rows[0]["db_size"].ToString();
        }
        catch (Exception)
        {
            _lblVeritabaniBoyutu.Text = "null";
        }
    }
    public static long KlasorBoyut(DirectoryInfo yol)
    {
        return yol.GetFiles().Sum(fi => fi.Length) +
        yol.GetDirectories().Sum(di => KlasorBoyut(di));
    }
    private void _fncDiskBouyutu()
    {
        try
        {
            string ServerPath2 = Server.MapPath(@"~/");
            DirectoryInfo klasoryolu = new DirectoryInfo(ServerPath2);
            long boyutyol = KlasorBoyut(klasoryolu);
            long Kilobyte = boyutyol / 1000;
            Label1.Text = Kilobyte.ToString("0,0", CultureInfo.InvariantCulture) + " KB";
        }
        catch (Exception)
        {
            
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            _dtUyariAyar = _clsData._fncVeriGetir("select * from UyariAyar");
            _dtSes = _clsData._fncVeriGetir("select * from Ses where SesID=" + _dtUyariAyar.Rows[0]["SesID"].ToString());
        }
        catch (Exception)
        {

        }
        try
        {
            _iNtSiparis = _clsData._fncVeriGetir("SELECT Durum FROM Siparis WHERE Durum=1");
            if (_iNtSiparis.Rows.Count != 0)
            {
                if (Convert.ToBoolean(_dtUyariAyar.Rows[0]["Durum"]) == true)
                {
                    string _player = " <audio controls autoplay='True' hidden='True'><source src='horse.ogg' type='audio/ogg'><source src='../Ses/didit.WAV' type='audio/mpeg'>Your browser does not support the audio element.</audio> ";
                    _lblPlayer.Text = _player;
                    //SoundPlayer player = new SoundPlayer();
                    //player.SoundLocation = HttpContext.Current.Request.PhysicalApplicationPath.ToString() + _dtSes.Rows[0]["SesYolu"].ToString();
                    //Label2.Text = player.SoundLocation.ToString();
                    //player.Play();
                    //Timer1.Enabled = false;
                   
                }
            }
        }
        catch (Exception)
        {
            
        }
        //Response.Redirect("Default.aspx");
    }
}