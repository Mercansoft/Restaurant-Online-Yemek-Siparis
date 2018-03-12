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

public partial class Yonetici_Kategori : System.Web.UI.Page
{
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    SqlConnection _cnn;
    SqlCommand _cmd;
    DataTable _dtKategori;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Kategori_List();
            _drpKategoriList.Enabled = false;
        }
        try
        {
            if (Request.QueryString["Sil"].ToString()!="")
            {
                _clsData._Metot_SQL_Calistir("DELETE FROM Kategori where KategoriID="+Request.QueryString["Sil"].ToString());
                _fnc_Kategori_List();
            }
        }
        catch (Exception)
        {
            
  }
    }
    private void _fnc_Kategori_List()
    {
        try
        {
            _dtKategori = _clsData._fncVeriGetir("SELECT * FROM Kategori");
            cpSayfala.DataSource = _dtKategori.DefaultView;
            cpSayfala.BindToControl = _lstKategori;
            _lstKategori.DataSource = cpSayfala.DataSourcePaged;
            _lstKategori.DataBind();
            //_lstKategori.DataTextField = "KategoriAdi";
            //_lstKategori.DataValueField = "KategoriID";
            _lstKategori.DataBind();
            _drpKategoriList.DataSource = _clsData._fncVeriGetir("SELECT * FROM Kategori");
            _drpKategoriList.DataTextField = "KategoriAdi";
            _drpKategoriList.DataValueField = "KategoriID";
            _drpKategoriList.DataBind();
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
            _cmd = new SqlCommand("INSERT INTO Kategori (KategoriAdi,UstKategoriID,Resim) VALUES (@KategoriAdi,@UstKategoriID,@Resim)", _cnn);
            _cmd.Parameters.AddWithValue("KategoriAdi", _txtKategoriAdi.Text);
            if (_chkAltKategori.Checked==true)
            {
                _cmd.Parameters.AddWithValue("UstKategoriID",Convert.ToInt32(_drpKategoriList.SelectedValue));
            }
            else
            {
                _cmd.Parameters.AddWithValue("UstKategoriID", 0);
            }
            _cmd.Parameters.AddWithValue("Resim", "Upload/"+FileUpload1.FileName.ToString());
            _fnc_ResimYukle();
            _cmd.ExecuteNonQuery();
            _cnn.Close();
            _cmd.Dispose();
            _fnc_Kategori_List();
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
    protected void _chkAltKategori_CheckedChanged(object sender, EventArgs e)
    {
        if (_chkAltKategori.Checked==true)
        {
            _drpKategoriList.Enabled = true;
        }
        else
        {
            _drpKategoriList.Enabled = false;
        }
    }
}