using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Yonetici_Giris : System.Web.UI.Page
{
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    Data _clsData = new Data();
    SqlConnection _cnn;
    SqlCommand _cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cmd = new SqlCommand("SELECT * FROM Yonetici WHERE KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre", _cnn);
            _cnn.Open();
            _cmd.Parameters.AddWithValue("KullaniciAdi", SqlBugKontrol(username.Text));
            _cmd.Parameters.AddWithValue("Sifre", SqlBugKontrol(password.Text));
            SqlDataReader _dr = _cmd.ExecuteReader();
            if (_dr.Read())
            {
                Session["YoneticiID"] = _dr["YoneticiID"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = "Hatalı Giriş!";
            }
        }
        catch (Exception)
        {

        }
    }
    public string SqlBugKontrol(string Str)
    {
        Str = Str.Replace("'", "`");
        Str = Str.Replace("--", " ");
        Str = Str.Replace(";", " ");
        Str = Str.Replace("(", "[");
        Str = Str.Replace(")", "]");
        Str = Str.Replace("WAITFOR", " ");
        Str = Str.Replace("DELAY", " ");
        Str = Str.Replace("waitfor", " ");
        Str = Str.Replace("delay", " ");
        Str = Str.Replace("=", ":");
        return Str;
    }
}