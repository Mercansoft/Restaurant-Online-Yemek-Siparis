using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class Iletisim : System.Web.UI.Page
{
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
    Data _clsData = new Data();
    DataTable _dtAyar;
    SqlConnection _cnn;
    SqlCommand _cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Guvenlik(100, 40, "Tahoma", 14, 20, 10, Server.MapPath("image/arkaplan.png"));
            _fnc_Ayar();  
        }

    }
    protected void _btnGonder_Click(object sender, EventArgs e)
    {
        string capRand = Session["captcha"].ToString();
        if (TextBox1.Text == capRand)
        {

        
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Mesaj (Kimden,Konu,Email,Telefon,Mesaj,Tarih,Durum) VALUES (@Kimden,@Konu,@Email,@Telefon,@Mesaj,@Tarih,@Durum)", _cnn);
            _cmd.Parameters.AddWithValue("Kimden",_txtisim.Text);
            _cmd.Parameters.AddWithValue("Konu", _txtKonu.Text);
            _cmd.Parameters.AddWithValue("Email", _txtEmail.Text);
            _cmd.Parameters.AddWithValue("Telefon", _txtTelefon.Text);
            _cmd.Parameters.AddWithValue("Mesaj", _txtMesaj.Text);
            _cmd.Parameters.AddWithValue("Tarih", Convert.ToDateTime(DateTime.Now));
            _cmd.Parameters.AddWithValue("Durum",1);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _cnn.Close();
            _lblDurum.Text = "Mesajınız İletilmiştir.";
            _fncTemizle();
        }
        catch (Exception ex)
        {
            
        }
        }
        else
        {
            _lblDurum.Text = "Güvenlik Resmi Doğru Değil!";
        }
    }
    private void _fncTemizle()
    {
        _txtisim.Text = "";
        _txtEmail.Text = "";
        _txtKonu.Text = "";
        _txtMesaj.Text = "";
        _txtTelefon.Text = "";
    }
    private void _fnc_Ayar()
    {
        _dtAyar = _clsData._fncVeriGetir("select * from Ayar");
        _lblAdres.Text = _dtAyar.Rows[0]["Adres"].ToString();
        _lblFax.Text= _dtAyar.Rows[0]["FaxTelefon"].ToString();
        _lblSabitTelefon.Text= _dtAyar.Rows[0]["SabitTelefon"].ToString();
        _lblCepTelefon.Text= _dtAyar.Rows[0]["CepTelefon"].ToString();
    }
    //private void Guvenlik(int H, int W, string fonts, int Punto, int X, int Y, string arkaplanResmi)
    //{
    //    Bitmap bmp = new Bitmap(H, W);
    //    Graphics g = Graphics.FromImage(bmp);
    //    Font font = new Font(fonts, Punto);
    //    Random r = new Random();
    //    int sayi = r.Next(1000, 99999);
    //    Session["captcha"] = sayi;
    //    System.Drawing.Image img = System.Drawing.Image.FromFile(arkaplanResmi);
    //    g.DrawImage(img, 1, 1);
    //    g.DrawString(sayi.ToString(), font, Brushes.DarkRed, X, Y);
    //    g.CompositingQuality = CompositingQuality.HighQuality;
    //    bmp.Save(Server.MapPath("image/captcha.png"), ImageFormat.Png);
    //}
    //protected void sayikontrol(object source, ServerValidateEventArgs args)
    //{
    //    if (Session["captcha"] != null)
    //    {
    //        if (TextBox1.Text != Session["captcha"].ToString())
    //        {
    //            Guvenlik(100, 40, "Tahoma", 14, 20, 10, Server.MapPath("image/arkaplan.png"));
    //            args.IsValid = false;
    //            return;/* www.Aspnetornekleri.com */
    //        }
    //    }
    //    else
    //    {
    //        Guvenlik(100, 40, "Tahoma", 14, 20, 10, Server.MapPath("image/arkaplan.png"));
    //        args.IsValid = false;
    //        return;
    //    }

    //}
    
}