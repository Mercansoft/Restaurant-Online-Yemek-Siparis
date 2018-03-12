using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Yonetici_Manset : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Manset();
        }
        try
        {
            if (Request.QueryString["Sil"].ToString()!="")
            {
                _clsData._Metot_SQL_Calistir("DELETE FROM Manset where MansetID="+Request.QueryString["Sil"].ToString());
                _fnc_Manset();
            }
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
            _cmd = new SqlCommand("INSERT INTO Manset (Resim) VALUES (@Resim)",_cnn);
            _cmd.Parameters.AddWithValue("Resim","Upload/"+ FileUpload1.FileName.ToString());
            _fnc_ResimYükle();
            _cmd.ExecuteNonQuery();
            _cnn.Close();
            _cmd.Dispose();
            _lblKayit.Text = "Başarıyla Kayıt Edildi.";
            _fnc_Manset();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_Manset()
    {
        _lstMansetler.DataSource = _clsData._fncVeriGetir("select * from Manset");
        _lstMansetler.DataBind();
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
}