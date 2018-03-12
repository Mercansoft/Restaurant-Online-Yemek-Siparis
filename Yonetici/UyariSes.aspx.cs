using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_UyariSes : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    DataTable _dtSes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fncSesler();
        }
    }
    private void _fncSesler()
    {
        try
        {
            _dtSes = _clsData._fncVeriGetir("select * from Ses");
            _lstSes.DataSource = _dtSes;
            _lstSes.DataValueField = "SesID";
            _lstSes.DataTextField = "SesAdi";
            _lstSes.DataBind();
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
            _cmd = new SqlCommand("INSERT INTO Ses (SesAdi,SesYolu) VALUES (@SesAdi,@SesYolu)", _cnn);
            _cmd.Parameters.AddWithValue("SesAdi", _txtSesAdi.Text);
            _cmd.Parameters.AddWithValue("SesYolu", "Ses/" + FileUpload1.FileName.ToString());
            _cmd.ExecuteNonQuery();
            _cnn.Close();
            _fnc_SesYükle();
            _fncSesler();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_SesYükle()
    {
        try
        {
            if (Directory.Exists(Server.MapPath("~/Ses/")))
            {
                FileUpload1.SaveAs(Server.MapPath("~/Ses/") + FileUpload1.FileName);

            }
            else
            {
                Directory.CreateDirectory(Server.MapPath("~/Ses/"));
                FileUpload1.SaveAs(Server.MapPath("~/Ses/") + FileUpload1.FileName);
            }
        }
        catch (Exception)
        {

        }

    }
    protected void _lstSes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _dtSes = _clsData._fncVeriGetir("select * from Ses where SesID=" + _lstSes.SelectedValue.ToString());
        }
        catch (Exception)
        {

        }
        try
        {
            SoundPlayer player = new SoundPlayer(); // SoundPlayer nesnemizi ekliyoruz.
            //Çalışacak ses dosyamızın yolunuzu gösteriyoruz.
            //_lblDurumu.Text = "Alarm Yolu : " + Server.MapPath("~") + _dtSes.Rows[0]["SesYolu"].ToString();
            _lblDurumu.Text = "Alarm Yolu : " + HttpContext.Current.Request.PhysicalApplicationPath.ToString() + _dtSes.Rows[0]["SesYolu"].ToString();
            player.SoundLocation = Server.MapPath("~") + _dtSes.Rows[0]["SesYolu"].ToString(); // yolunu göstermiş olduğumuz ses dosyamızı gönderdik
            //player.SoundLocation = Server.MapPath("~") + _dtSes.Rows[0]["SesYolu"].ToString(); 
            player.Play(); //Ses dosyasını çalmasını sağlıyoruz.
        }
        catch (Exception)
        {
            
        }
    }
}