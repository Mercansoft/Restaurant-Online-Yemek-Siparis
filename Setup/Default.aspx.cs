using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

public partial class Setup_Default : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    string SqlCumlesi;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _pnlLisans.Visible = false;
            _pnlConnectToDb.Visible = false;
            _pnlSiteAyar.Visible = false;
            Tamam.Visible = false;
            Hata.Visible = false;
        }
        else
        {
            if (CheckBox1.Checked==true)
            {
                _pnlLisans.Visible = true;
                PreInstall.Visible = false;
            }
            if (chkIAgree.Checked==true)
            {
                _pnlConnectToDb.Visible = true;
                _pnlLisans.Visible = false;
            }
            if (_chkDbBilgi.Checked==true)
            {
                //try
                //{
                AddConnection("SqlConnectionString", "Data Source=" + _txtDomain.Text + ";Initial Catalog=" + _txtDbName.Text + ";User ID=" + _txtDbUser.Text + ";Password=" + _txtDbPassword.Text + "");
                //}
                //catch (Exception)
                //{
                //    _pnlSiteAyar.Visible = false;
                //    Hata.Visible = true;
                //}
            }
        }
    }

    public void AddConnection(string name, string connString)
    {
        try
        {
            var webConfig = new ExeConfigurationFileMap { ExeConfigFilename = HttpContext.Current.Server.MapPath("~\\Web.config") };
            var config = ConfigurationManager.OpenMappedExeConfiguration(webConfig, ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, connString, "System.Data.SqlClient"));
            config.Save();
            ConfigurationManager.RefreshSection("SqlConnectionString");
            _fncVeriTabaniniOlustur();
            _pnlSiteAyar.Visible = true;
            _pnlConnectToDb.Visible = false; 
        }
        catch (Exception ex)
        {
            Hata.Visible = true;
            Label1.Text = ex.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _pnlSiteAyar.Visible = false;
            _fncSiteAyarlar();
            Tamam.Visible = true;
    }
    private void _fncSiteAyarlar()
    {
        try
        {
            string Baglan = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString.ToString();
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Ayar (Title,Footer,Aciklama,AnahtarKelime,Adres,SabitTelefon,FaxTelefon,CepTelefon) VALUES (@Title,@Footer,@Aciklama,@AnahtarKelime,@Adres,@SabitTelefon,@FaxTelefon,@CepTelefon)", _cnn);
            _cmd.Parameters.AddWithValue("Title", _txtTitle.Text);
            _cmd.Parameters.AddWithValue("Footer", "Powered By MercanYazilim.NET");
            _cmd.Parameters.AddWithValue("Aciklama", _txtAciklama.Text);
            _cmd.Parameters.AddWithValue("AnahtarKelime", _txtAnahtarKelime.Text);
            _cmd.Parameters.AddWithValue("Adres", "Adres");
            _cmd.Parameters.AddWithValue("SabitTelefon", "0262 222 22 22");
            _cmd.Parameters.AddWithValue("FaxTelefon", "0262 222 22 22");
            _cmd.Parameters.AddWithValue("CepTelefon", "0534 371 66 61");
            _cmd.ExecuteNonQuery();
            _cnn.Close();
        }
        catch (Exception ex)
        {
            Hata.Visible = true;
            Label1.Text = ex.ToString();
        }
        _fncYoneticiEkle();
    }
    private void _fncYoneticiEkle()
    {
        try
        {
            string Baglan = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString.ToString();
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Yonetici (KullaniciAdi,Sifre,Email,Isim,Soyisim) VALUES(@KullaniciAdi,@Sifre,@Email,@Isim,@Soyisim)", _cnn);
            _cmd.Parameters.AddWithValue("KullaniciAdi", _txtKullaniciAdi.Text);
            _cmd.Parameters.AddWithValue("Sifre", _txtSifre.Text);
            _cmd.Parameters.AddWithValue("Email", "admin@admin.com");
            _cmd.Parameters.AddWithValue("Isim", _txtKullaniciAdi.Text);
            _cmd.Parameters.AddWithValue("Soyisim", _txtKullaniciAdi.Text);
            _cmd.ExecuteNonQuery();
            _cnn.Close();
        }
        catch (Exception ex)
        {
            Hata.Visible = true;
            Label1.Text = ex.ToString();
        }
        
    }
    private void _fncVeriTabaniniOlustur()
    {
        
        try
        {
            FileStream akis;
            StreamReader Okuma;
            string Yol = Request.PhysicalApplicationPath + @"\Setup\sql.sql";
            akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
            Okuma = new StreamReader(akis);
            string metin = Okuma.ReadLine();
            while (metin != null)
            {
                SqlCumlesi = SqlCumlesi + "\n" + metin;
                metin = Okuma.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Hata.Visible = true;
            Label1.Text = ex.ToString();
        }

        try
        {
            string Baglan = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString.ToString();
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand(SqlCumlesi, _cnn);
            _cmd.ExecuteNonQuery();
            _cnn.Close();
        }
        catch (Exception ex)
        {
            Hata.Visible = true;
            Label1.Text = ex.ToString();
        }
    }
}