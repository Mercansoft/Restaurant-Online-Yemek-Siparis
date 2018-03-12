using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Yonetici_Ayar : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    DataTable _dtAyar;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Ayar();
        }
    }
    private void _fnc_Ayar()
    {
        try
        {
            _dtAyar = _clsData._fncVeriGetir("select * from Ayar");
            _txtAciklama.Text = _dtAyar.Rows[0]["Aciklama"].ToString();
            _txtAdres.Text = _dtAyar.Rows[0]["Adres"].ToString();
            _txtAnahtarKelime.Text = _dtAyar.Rows[0]["AnahtarKelime"].ToString();
            _txtCepTelefon.Text = _dtAyar.Rows[0]["CepTelefon"].ToString();
            _txtFax.Text = _dtAyar.Rows[0]["FaxTelefon"].ToString();
            _txtFooter.Text = _dtAyar.Rows[0]["Footer"].ToString();
            _txtSabitTelefon.Text = _dtAyar.Rows[0]["SabitTelefon"].ToString();
            _txtTitle.Text = _dtAyar.Rows[0]["Title"].ToString();
            Image1.ImageUrl = "../" + _dtAyar.Rows[0]["Logo"].ToString();
            //  _chkEklenti.Checked = Convert.ToBoolean(_dtAyar.Rows[0]["Eklenti"]);
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
            _cmd = new SqlCommand("UPDATE Ayar SET Logo=@Logo,Title=@Title,Footer=@Footer,Aciklama=@Aciklama,AnahtarKelime=@AnahtarKelime,Adres=@Adres,SabitTelefon=@SabitTelefon,FaxTelefon=@FaxTelefon,CepTelefon=@CepTelefon", _cnn);
            if (FileUpload1.HasFile !=false)
            {
                _cmd.Parameters.AddWithValue("Logo", "Upload/" + FileUpload1.FileName.ToString());
                _fnc_ResimYükle();
            }
            else
            {
                _cmd.Parameters.AddWithValue("Logo", _dtAyar.Rows[0]["Logo"].ToString());  
            }
            _cmd.Parameters.AddWithValue("Title", _txtTitle.Text);
            _cmd.Parameters.AddWithValue("Footer",_txtFooter.Text);
            _cmd.Parameters.AddWithValue("Aciklama",_txtAciklama.Text);
            _cmd.Parameters.AddWithValue("AnahtarKelime",_txtAnahtarKelime.Text);
            _cmd.Parameters.AddWithValue("Adres",_txtAdres.Text);
            _cmd.Parameters.AddWithValue("SabitTelefon",_txtSabitTelefon.Text);
            _cmd.Parameters.AddWithValue("FaxTelefon", _txtFax.Text);
            _cmd.Parameters.AddWithValue("CepTelefon", _txtCepTelefon.Text);
        //    _cmd.Parameters.AddWithValue("Eklenti", Convert.ToBoolean(_chkEklenti.Checked));
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _cnn.Close();
            _lblDurumu.Text = "Ayarlarınız Başarıyla Güncellendi.";
            Response.Redirect("Ayar.aspx");
        }
        catch (Exception)
        {
        }
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