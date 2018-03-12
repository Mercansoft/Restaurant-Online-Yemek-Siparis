using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class Yonetici_Hizmet : System.Web.UI.Page
{
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    SqlConnection _cnn;
    SqlCommand _cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Sayfalar();
        }
        try
        {
            if (Request.QueryString["Sil"].ToString() != "")
            {
                _clsData._fncSQLCalistir("DELETE FROM Hizmet WHERE HizmetID=" + Request.QueryString["Sil"].ToString());
                _fnc_Sayfalar();
            }
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_Sayfalar()
    {
        _lstYoneticilerListesi.DataSource = _clsData._fncVeriGetir("select * from Hizmet");
        _lstYoneticilerListesi.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Hizmet (HizmetAdi,Resim,Icerik) VALUES (@HizmetAdi,@Resim,@Icerik)", _cnn);
            _cmd.Parameters.AddWithValue("HizmetAdi", _txtSayfaAdi.Text);
            _cmd.Parameters.AddWithValue("Resim", "Upload/" + FileUpload1.FileName.ToString());
            _cmd.Parameters.AddWithValue("Icerik", CKEditorControl1.Text);
            _fnc_ResimYukle();
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _cnn.Close();
            Label1.Text = "Hizmetiniz Başarıyla Oluşturulmuştur.";
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_ResimYukle()
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