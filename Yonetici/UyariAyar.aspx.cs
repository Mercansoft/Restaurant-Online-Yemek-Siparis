using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_UyariAyar : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    DataTable _dtAyar;
    DataTable _dtSes;
    private DataTable _dtUyari;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Ayar();
            _fncSesler();
        }
    }
    private void _fnc_Ayar()
    {
        try
        {
            _dtAyar = _clsData._fncVeriGetir("select * from UyariAyar");
            _lstSes.SelectedValue = _dtAyar.Rows[0]["SesID"].ToString();
            _txtSure.Text = _dtAyar.Rows[0]["Sure"].ToString();
            _chkUyari.Checked = Convert.ToBoolean(_dtAyar.Rows[0]["Durum"]);
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


            //System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            //System.IO.Stream s = a.GetManifestResourceStream(Server.MapPath("~") + _dtSes.Rows[0]["SesYolu"].ToString());
            //SoundPlayer player = new SoundPlayer(s);
            //player.Play();       



            SoundPlayer player = new SoundPlayer();
            _lblDurumu.Text = "Alarm Yolu : " + Server.MapPath("~") + _dtSes.Rows[0]["SesYolu"].ToString();
            player.SoundLocation = Server.MapPath("~") + _dtSes.Rows[0]["SesYolu"].ToString();
            player.SoundLocation = HttpContext.Current.Request.PhysicalApplicationPath.ToString() + _dtSes.Rows[0]["SesYolu"].ToString();
            player.Play();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fncSesler()
    {
        try
        {
            _lstSes.DataSource = _clsData._fncVeriGetir("select * from Ses");
            _lstSes.DataValueField = "SesID";
            _lstSes.DataTextField = "SesAdi";
            _lstSes.DataBind();
            //_dtSes = _clsData._fncVeriGetir("select * from Ses");
            //_lblDurumu.Text = Server.MapPath(@"~/") + _dtSes.Rows[0]["SesYolu"].ToString();
            
        }
        catch (Exception)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int sayi = _clsData._fncSQLCalistir_int("select * from UyariAyar");

        if (sayi == 1)
        {
                        try
            {
                _cnn = new SqlConnection(Baglan);
                _cnn.Open();
                _cmd = new SqlCommand("UPDATE UyariAyar SET SesID=@SesID,Sure=@Sure,Durum=@Durum", _cnn);
                _cmd.Parameters.AddWithValue("SesID", _lstSes.SelectedValue.ToString());
                _cmd.Parameters.AddWithValue("Sure", _txtSure.Text);
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
        else
        {
                                    try
            {
                _cnn = new SqlConnection(Baglan);
                _cnn.Open();
                _cmd = new SqlCommand("INSERT INTO UyariAyar (SesID,Sure,Durum) VALUES (@SesID,@Sure,@Durum)", _cnn);
                _cmd.Parameters.AddWithValue("SesID", _lstSes.SelectedValue.ToString());
                _cmd.Parameters.AddWithValue("Sure", _txtSure.Text);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            _clsData._Metot_SQL_Calistir("DELETE FROM Ses WHERE SesID=" + _lstSes.SelectedValue.ToString());
            _fncSesler();
        }
	catch (Exception)
	{
		
	}
    }
}