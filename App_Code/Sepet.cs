using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Sepet
/// </summary>
public class Sepet
{
	public Sepet()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Ekle(string id, string isim, string resim, int adet, double fiyat)
    {

        try
        {
            DataTable dt = new DataTable(); // sepeti tutacağımız bir datatable oluşturuyoruz
            if (HttpContext.Current.Session["sepet"] != null)//daha önceden sepet oluşturulmuş mu diye sessiona bakıyoruz
            {
                dt = (DataTable)HttpContext.Current.Session["sepet"];//session varsa  sessionu datatbale ye cast edip datatablemizi elde ediyoruz
            }
            else//session yok ise yani sepet daha önce oluşturulup sessiona atılmamış ise dataTableyi oluşturuyoruz
            {
                dt.Columns.Add("id");// DataTableye id colonunu ekliyoruz
                dt.Columns.Add("isim");//DataTableye isim colonunu ekliyoruz
                dt.Columns.Add("resim");//DataTableye isim colonunu ekliyoruz
                dt.Columns.Add("fiyat");//DataTableye fiyat colonunu ekliyoruz
                dt.Columns.Add("adet");//DataTableye adet colonunu ekliyoruz
                dt.Columns.Add("tutar");//DataTableye tutar colonunu ekliyoruz
            }

            bool varmi = Kontrol(id.ToString());//Kontrol adındaki methoda gelen id  değerini gönderiyoruz
            // böylece aynı id ye sahip ürün daha önce eklendiyse aynı ürünü birdaha eklemek yerine sadece ürünnün sepeteki adetini artıracağız
            // Kontrol methodu ürün varsa true yoks false değer döndürüyor
            if (varmi == false)//ürün daha önce eklenmemiş ise            
            {

                DataRow drow = dt.NewRow();//yeni bir row (satır) oluşturuluyor.
                drow["id"] = id;//satırın id colonuna gelen id yazılıyor.
                drow["isim"] = isim;//satırın isim colonuna gelen isim yazılıyor.
                drow["resim"] = resim;//satırın isim colonuna gelen isim yazılıyor.
                drow["fiyat"] = fiyat;//satırın fiyat colonuna gelen fiyat yazılıyor.
                drow["adet"] = adet;//satırın adet colonuna gelen adet yazılıyor.
                drow["tutar"] = (fiyat * adet).ToString();//satırın tutar alanına gelen fiyat ile adet çarpımı  yazılıyor.
                dt.Rows.Add(drow);//oluşturulan satır tabloya ekleniyor. 
            }

            else//eğer ürün tabloya daha önce eklenmiş ise
            {
                Artir(id, adet, fiyat);//Artir methoduna gelen id fiyat ve adet değerleri gönderiliyor. Fiyata gerek yok aslında ama neyse :)
                //artir metoduna giddip bakalım şimdi
            }
            HttpContext.Current.Session["sepet"] = dt;//en son olarak olşturulan DataTable nin sayfa postback olduğunda kaybolmaması için
            // sessiona atılıyor. artık birdaki sefere session olduğu için tablo bu sessiondan alınıp üzerine yazılcak
        }
        catch
        {
        }
    }
    public void EklentiEkle(string id, string isim, string resim, int adet, double fiyat)
    {

        try
        {
            DataTable dt = new DataTable(); // sepeti tutacağımız bir datatable oluşturuyoruz
            if (HttpContext.Current.Session["Eklentisepet"] != null)//daha önceden sepet oluşturulmuş mu diye sessiona bakıyoruz
            {
                dt = (DataTable)HttpContext.Current.Session["Eklentisepet"];//session varsa  sessionu datatbale ye cast edip datatablemizi elde ediyoruz
            }
            else//session yok ise yani sepet daha önce oluşturulup sessiona atılmamış ise dataTableyi oluşturuyoruz
            {
                dt.Columns.Add("id");// DataTableye id colonunu ekliyoruz
                dt.Columns.Add("isim");//DataTableye isim colonunu ekliyoruz
                dt.Columns.Add("resim");//DataTableye isim colonunu ekliyoruz
                dt.Columns.Add("fiyat");//DataTableye fiyat colonunu ekliyoruz
                dt.Columns.Add("adet");//DataTableye adet colonunu ekliyoruz
                dt.Columns.Add("tutar");//DataTableye tutar colonunu ekliyoruz
            }

            bool varmi = KontrolEklenti(id.ToString());//Kontrol adındaki methoda gelen id  değerini gönderiyoruz
            // böylece aynı id ye sahip ürün daha önce eklendiyse aynı ürünü birdaha eklemek yerine sadece ürünnün sepeteki adetini artıracağız
            // Kontrol methodu ürün varsa true yoks false değer döndürüyor
            if (varmi == false)//ürün daha önce eklenmemiş ise            
            {

                DataRow drow = dt.NewRow();//yeni bir row (satır) oluşturuluyor.
                drow["id"] = id;//satırın id colonuna gelen id yazılıyor.
                drow["isim"] = isim;//satırın isim colonuna gelen isim yazılıyor.
                drow["resim"] = resim;//satırın isim colonuna gelen isim yazılıyor.
                drow["fiyat"] = fiyat;//satırın fiyat colonuna gelen fiyat yazılıyor.
                drow["adet"] = adet;//satırın adet colonuna gelen adet yazılıyor.
                drow["tutar"] = (fiyat * adet).ToString();//satırın tutar alanına gelen fiyat ile adet çarpımı  yazılıyor.
                dt.Rows.Add(drow);//oluşturulan satır tabloya ekleniyor. 
            }

            else//eğer ürün tabloya daha önce eklenmiş ise
            {
                ArtirEklenti(id, adet, fiyat);//Artir methoduna gelen id fiyat ve adet değerleri gönderiliyor. Fiyata gerek yok aslında ama neyse :)
                //artir metoduna giddip bakalım şimdi
            }
            HttpContext.Current.Session["Eklentisepet"] = dt;//en son olarak olşturulan DataTable nin sayfa postback olduğunda kaybolmaması için
            // sessiona atılıyor. artık birdaki sefere session olduğu için tablo bu sessiondan alınıp üzerine yazılcak
        }
        catch
        {
        }
    }
    public double SepetToplam()
    {
        double toplam = 0;//toplam değişkeni tanımlanıyor
        if (HttpContext.Current.Session["sepet"] != null)//sessiomn kontolü yapılıyor
        {
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
            for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
            {
                toplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
            }
        }
        return toplam; //toplam değeri döndürülüyor.

    }
    public double EklentiToplam()
    {
        double toplam = 0;//toplam değişkeni tanımlanıyor
        if (HttpContext.Current.Session["Eklentisepet"] != null)//sessiomn kontolü yapılıyor
        {
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["Eklentisepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
            for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
            {
                toplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
            }
        }
        return toplam; //toplam değeri döndürülüyor.

    }
    public void Sil(string id)//silinecek olan ürünün id değeri alınıyor
    {
        DataTable dt = new DataTable();//tablo örneği oluşturuluyor
        if (HttpContext.Current.Session["sepet"] != null)//sessin  kontrolü yapılıyor
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++)//tablonun satır sayısı kadar yine bir döngü oluşturuluyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//o naki satırın id alanı ile gelen id alanı eşit ise
                {
                    dt.Rows[i].Delete();//tablonun o satırı siliniyor. 
                    HttpContext.Current.Session["sepet"] = dt;//tablonun son hali sessiona aktarılıyor
                    break;//dögüden çıkılıyor
                }
            }
        }
    }

    public void EklentiSil(string id)//silinecek olan ürünün id değeri alınıyor
    {
        DataTable dt = new DataTable();//tablo örneği oluşturuluyor
        if (HttpContext.Current.Session["Eklentisepet"] != null)//sessin  kontrolü yapılıyor
        {
            dt = (DataTable)HttpContext.Current.Session["Eklentisepet"];//sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++)//tablonun satır sayısı kadar yine bir döngü oluşturuluyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//o naki satırın id alanı ile gelen id alanı eşit ise
                {
                    dt.Rows[i].Delete();//tablonun o satırı siliniyor. 
                    HttpContext.Current.Session["Eklentisepet"] = dt;//tablonun son hali sessiona aktarılıyor
                    break;//dögüden çıkılıyor
                }
            }
        }
    }
    private bool Kontrol(string id)//gelen ürün id si alınıyor
    {
        bool r = false;//dönüş değeri tanımlanıyor
        DataTable dt = new DataTable();//tablo luşturutuluyor
        if (HttpContext.Current.Session["sepet"] != null)//session boş değilse işleme başlanıyor
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki bilgiler tabloya alınıyor

            for (int i = 0; i < dt.Rows.Count; i++)//tablonun içindeki satırlara tek tek dönügü ile bakıloyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//eğer o anki satırın id alanı ile gelen id alanı eşit ise
                {
                    r = true;// dömüş değeri true yapılıyor ve dmngüden çıkılıyor.
                    break;
                }
            }
        }
        return r;//geri değer dönürülüyor ürün varsa true yoksa false dönecek

    }
    private bool KontrolEklenti(string id)//gelen ürün id si alınıyor
    {
        bool r = false;//dönüş değeri tanımlanıyor
        DataTable dt = new DataTable();//tablo luşturutuluyor
        if (HttpContext.Current.Session["Eklentisepet"] != null)//session boş değilse işleme başlanıyor
        {
            dt = (DataTable)HttpContext.Current.Session["Eklentisepet"];//sessiondaki bilgiler tabloya alınıyor

            for (int i = 0; i < dt.Rows.Count; i++)//tablonun içindeki satırlara tek tek dönügü ile bakıloyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//eğer o anki satırın id alanı ile gelen id alanı eşit ise
                {
                    r = true;// dömüş değeri true yapılıyor ve dmngüden çıkılıyor.
                    break;
                }
            }
        }
        return r;//geri değer dönürülüyor ürün varsa true yoksa false dönecek

    }
    public void Artir(string id, int adet, double fiyat)//değerler alınıyor
    {
        try
        {
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++)//tablonun tüm satırlarında dönülüyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//eğer gelen id ile o anki satırın id değeri eşit ise
                {
                    int adet1 = Convert.ToInt32(dt.Rows[i]["adet"].ToString());//o anfdaki ürün adeti geçici bir değişkene atanıyor
                    adet1 += adet;//eski adete yeni gelen adet ekleniyor.
                    dt.Rows[i]["adet"] = adet1.ToString();//ve o tablonun adet alanına toplam adet ekleniyor
                    double tutar1 = Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//tutar alanı geçici değişkene atanıyor.
                    tutar1 = (adet * Convert.ToDouble(dt.Rows[i]["fiyat"])) + tutar1;//yeni tutar yeni adete göre hesaplanıyor
                    dt.Rows[i]["tutar"] = tutar1.ToString();//yeni tutar tabloya ekleniyor
                    HttpContext.Current.Session["sepet"] = dt;//tablonun son hali sessiona atılıyor
                    break;//döngüden çıkılıyor.
                }
            }
        }
        catch
        {
        }
    }
    public void ArtirEklenti(string id, int adet, double fiyat)//değerler alınıyor
    {
        try
        {
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["Eklentisepet"];//sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++)//tablonun tüm satırlarında dönülüyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//eğer gelen id ile o anki satırın id değeri eşit ise
                {
                    int adet1 = Convert.ToInt32(dt.Rows[i]["adet"].ToString());//o anfdaki ürün adeti geçici bir değişkene atanıyor
                    adet1 += adet;//eski adete yeni gelen adet ekleniyor.
                    dt.Rows[i]["adet"] = adet1.ToString();//ve o tablonun adet alanına toplam adet ekleniyor
                    double tutar1 = Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//tutar alanı geçici değişkene atanıyor.
                    tutar1 = (adet * Convert.ToDouble(dt.Rows[i]["fiyat"])) + tutar1;//yeni tutar yeni adete göre hesaplanıyor
                    dt.Rows[i]["tutar"] = tutar1.ToString();//yeni tutar tabloya ekleniyor
                    HttpContext.Current.Session["Eklentisepet"] = dt;//tablonun son hali sessiona atılıyor
                    break;//döngüden çıkılıyor.
                }
            }
        }
        catch
        {
        }
    }
    public void Artir_My(string id, int adet)//değerler alınıyor
    {
        try
        {
            DataTable dt = new DataTable();//tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++)//tablonun tüm satırlarında dönülüyor
            {
                if (dt.Rows[i]["id"].ToString() == id)//eğer gelen id ile o anki satırın id değeri eşit ise
                {
                    int adet1 = Convert.ToInt32(dt.Rows[i]["adet"].ToString());//o anfdaki ürün adeti geçici bir değişkene atanıyor
                    adet1 += adet;//eski adete yeni gelen adet ekleniyor.
                    dt.Rows[i]["adet"] = adet1.ToString();//ve o tablonun adet alanına toplam adet ekleniyor
                    double tutar1 = Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//tutar alanı geçici değişkene atanıyor.
                    tutar1 = (adet * Convert.ToDouble(dt.Rows[i]["fiyat"])) + tutar1;//yeni tutar yeni adete göre hesaplanıyor
                    dt.Rows[i]["tutar"] = tutar1.ToString();//yeni tutar tabloya ekleniyor
                    HttpContext.Current.Session["sepet"] = dt;//tablonun son hali sessiona atılıyor
                    break;//döngüden çıkılıyor.
                }
            }
        }
        catch
        {
        }
    }
    public void Guncelle(string id, int adet)//değerler alınıyor
    {
        try
        {
            DataTable dt = new DataTable(); //tablo oluşturuluyor
            dt = (DataTable)HttpContext.Current.Session["sepet"]; //sessiondaki tablo alınıyor
            for (int i = 0; i < dt.Rows.Count; i++) //tablonun tüm satırlarında dönülüyor
            {
                if (dt.Rows[i]["id"].ToString() == id) //eğer gelen id ile o anki satırın id değeri eşit ise
                {
                    dt.Rows[i]["adet"] = adet.ToString();
                    double tutar1 = (adet * Convert.ToDouble(dt.Rows[i]["fiyat"]));
                    dt.Rows[i]["tutar"] = tutar1.ToString();
                    HttpContext.Current.Session["sepet"] = dt; //tablonun son hali sessiona atılıyor
                    break; //döngüden çıkılıyor.
                }
            }
            
        }
        catch (Exception)
        {
            
        }
    }
}