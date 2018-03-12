using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data;
using System.Drawing;

public partial class Yonetici_Yemek : System.Web.UI.Page
{
    SqlConnection _cnn;
    SqlCommand _cmd;
    Data _clsData = new Data();
    private string Baglan = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _pnlListe.Visible = false;
            _pnlEkle.Visible = false;
            _fnc_Kategori();
            _fnc_Yemekler();
            _fncEklentiler();
            OnLoad();
            _pnlEklenti.Visible = false;
        }
        try
        {
            if (Request.QueryString["Komut"] != "")
            {
                string Komut = Request.QueryString["Komut"].ToString();
                switch (Komut)
                {
                    case "Ekle":
                        _pnlListe.Visible = false;
                        _pnlEkle.Visible = true;
                        break;
                    case "Listele":
                        _pnlListe.Visible = true;
                        _pnlEkle.Visible = false;
                        break;
                }

            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Sil"].ToString()!="")
            {
                DataTable _dtresim = _clsData._fncVeriGetir("SELECT * FROM Yemek WHERE YemekID="+ Request.QueryString["Sil"].ToString());
                _clsData._Metot_SQL_Calistir("DELETE FROM Yemek WHERE YemekID="+Request.QueryString["Sil"].ToString());
                _fnc_dosyaSil("../" + _dtresim.Rows[0]["Resim"].ToString());
                //_fnc_Yemekler();
                Response.Redirect("Yemek.aspx?Komut=Listele");
            }
        }
        catch (Exception)
        {
            
        }
    }
    private void OnLoad()
    {
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "../ckfinder/";
        _FileBrowser.SetupCKEditor(CKEditorControl1);
    }
    private void _fncEklentiler()
    {
        DropDownList1.DataSource = _clsData._fncVeriGetir("select * from EklentiKat Where AltEklentiID=0");
        DropDownList1.DataTextField = "EklentiAdi";
        DropDownList1.DataValueField = "EklentiKatID";
        DropDownList1.DataBind();
    }
    private void _fnc_Kategori()
    {
        _drpKategori.DataSource = _clsData._fncVeriGetir("select * from Kategori");
        _drpKategori.DataTextField = "KategoriAdi";
        _drpKategori.DataValueField = "KategoriID";
        _drpKategori.DataBind();
    }
    private void _fnc_Yemekler()
    {
        _lstYemekler.DataSource = _clsData._fncVeriGetir("select * from Yemek ORDER BY YemekID DESC");
        _lstYemekler.DataBind();
    }
    private void _fnc_dosyaSil(string dosyayolu)
    {
        File.Delete(Server.MapPath(dosyayolu));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            _cnn = new SqlConnection(Baglan);
            _cnn.Open();
            _cmd = new SqlCommand("INSERT INTO Yemek (KategoriID,EklentiKatID,YemekAdi,BuyukResim,KucukResim,Fiyat,UrunKodu,YemekAciklama,Hit) VALUES (@KategoriID,@EklentiKatID,@YemekAdi,@BuyukResim,@KucukResim,@Fiyat,@UrunKodu,@YemekAciklama,@Hit)", _cnn);
            _cmd.Parameters.AddWithValue("KategoriID",Convert.ToInt32(_drpKategori.SelectedValue));
            if (CheckBox1.Checked==true)
            {
                _cmd.Parameters.AddWithValue("EklentiKatID", Convert.ToInt32(DropDownList1.SelectedValue));
            }
            else
            {
                _cmd.Parameters.AddWithValue("EklentiKatID", 0);
            }
            _cmd.Parameters.AddWithValue("YemekAdi",_txtYemekAdi.Text);
            _cmd.Parameters.AddWithValue("BuyukResim", "Restaurantv2/Upload/" + FileUpload1.FileName.ToString());
            _cmd.Parameters.AddWithValue("KucukResim", "Restaurantv2/Upload/thumbnail/" + FileUpload1.FileName.ToString());
            _fnc_ResimYükle();
            _cmd.Parameters.AddWithValue("Fiyat",Convert.ToDouble(_txtFiyat.Text));
            _cmd.Parameters.AddWithValue("UrunKodu",_txtUrunKodu.Text);
            _cmd.Parameters.AddWithValue("YemekAciklama",CKEditorControl1.Text);
            _cmd.Parameters.AddWithValue("Hit",1);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _cnn.Close();
            _lblKayit.Text = "Yemek Başarıyla Kayıt Edildi.";
        }
        catch (Exception)
        {
            
        }
    }
    static Size Boyutu(System.Drawing.Image org)
    {
        const int max = 200;// resmimizin max olacak boyutu.
        int uzunluk = org.Width;// orjinal resmin uzunluğu
        int genislik = org.Height;// orjinal resmin genişliği
        double f;// küçültme oranımız.
        if (uzunluk > genislik)// hangi kenar büyük kontrolü
        {
            f = (double)max / uzunluk;//küçültme oranını hesapla
        }
        else
        {
            f = (double)max / genislik;//küçültme oranı hesapla.
        }
        return new Size((int)(uzunluk * f), (int)(genislik * f));
        //oluşturulan yeni boyutu gönder.
    }
    private void _fnc_ResimYükle()
    {

        string dosyaadi;//file Upload ile gelecek olan dosyanın adını
                        //tuttuğumuz değişken



        try
        {

            if (FileUpload1.HasFile)//fileUpload'da dosya var mı diye kontrol ediyoruz.
            {
                if (Directory.Exists(Server.MapPath("~/Upload/")))
                {
                    //FileUpload1.SaveAs(Server.MapPath("~/Upload/") + FileUpload1.FileName);
                    dosyaadi = FileUpload1.FileName;//dosyanın adını dosyaadi değişkenine atadık.
                    FileUpload1.SaveAs(Server.MapPath("~/Upload/" + dosyaadi));
                    //orjinal resmi kaydediyoruz.
                    System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Upload/" + dosyaadi));
                    //img adında bir nesne tanımlayarak orjinal resmi çağırıyoruz.
                    Size byt = Boyutu(img);// yazdığımı Boyutu fonksiyonu yardımıyla yeni boyutumuzu alıyoruz.
                    System.Drawing.Image kucukResim = img.GetThumbnailImage(byt.Width, byt.Height, null, IntPtr.Zero);
                    // Boyutu küçültme oranımıza göre küçültüp küçük resmi oluşturuyoruz.
                    if (Directory.Exists(Server.MapPath("~/Upload/thumbnail/")))
                    {
                        kucukResim.Save(Server.MapPath("~/Upload/thumbnail/" + dosyaadi));
                    }
                    else
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Upload/thumbnail/"));
                        kucukResim.Save(Server.MapPath("~/Upload/thumbnail/" + dosyaadi));
                    }

                }
                else
                {
                    Directory.CreateDirectory(Server.MapPath("~/Upload/"));
                    //FileUpload1.SaveAs(Server.MapPath("~/Upload/") + FileUpload1.FileName);
                    dosyaadi = FileUpload1.FileName;//dosyanın adını dosyaadi değişkenine atadık.
                    FileUpload1.SaveAs(Server.MapPath("~/Upload/" + dosyaadi));
                    //orjinal resmi kaydediyoruz.
                    System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Upload/" + dosyaadi));
                    //img adında bir nesne tanımlayarak orjinal resmi çağırıyoruz.
                    Size byt = Boyutu(img);// yazdığımı Boyutu fonksiyonu yardımıyla yeni boyutumuzu alıyoruz.
                    System.Drawing.Image kucukResim = img.GetThumbnailImage(byt.Width, byt.Height, null, IntPtr.Zero);
                    // Boyutu küçültme oranımıza göre küçültüp küçük resmi oluşturuyoruz.
                    if (Directory.Exists(Server.MapPath("~/Upload/thumbnail/")))
                    {
                        kucukResim.Save(Server.MapPath("~/Upload/thumbnail/" + dosyaadi));
                    }
                    else
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Upload/thumbnail/"));
                        kucukResim.Save(Server.MapPath("~/Upload/thumbnail/" + dosyaadi));
                    }
                        
                }


                
                //Küçük resmi kaydediyoruz.

            }


        }
        catch (Exception)
        {

        }

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        _pnlEklenti.Visible = true;
        _pnlEklentiCheck.Visible = false;
    }
}