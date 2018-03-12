using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Mail
/// </summary>
public class Mail
{
    private static DataTable _dtAyar;
    private static Data _clsData;
    public Mail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static bool _fncLisansMailGonder(string LisanslananDomain, string KullanilanDomain, string IPAdres)
    {

        try
        {
            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("lisans@mercanyazilim.net");
            Mesaj.To.Add("yavuz@mercanyazilim.net");
            Mesaj.Subject = "Lisanssız Kullanım!";
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = "Lisanslanan Domain : " + LisanslananDomain.ToString() + " <br><br>Kullanılan Domain : " + KullanilanDomain.ToString() + " <br><br>IP Adres : " + IPAdres.ToString() + "<br><br> Tarih :" + DateTime.Now.ToLongTimeString();
            SmtpClient smtp = new SmtpClient("mail.mercanyazilim.net", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("lisans@mercanyazilim.net", "q1w2e39420522");
            smtp.Credentials = SMTPUserInfo;
            smtp.Send(Mesaj);
            return true;
        }
        catch
        {
            return false;
        }

    }
    public static bool _fncMailGonder(string MailAdres, string Konu, string MailIcerik)
    {
        try
        {
            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("lisans@mercanyazilim.net");
            Mesaj.To.Add(MailAdres);
            Mesaj.Subject = Konu.ToString();
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = MailIcerik;
            SmtpClient smtp = new SmtpClient("mail.mercanyazilim.net", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("lisans@mercanyazilim.net", "q1w2e39420522");
            smtp.Credentials = SMTPUserInfo;


            smtp.Send(Mesaj);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public static void _fncEmailKayit(string AdiSoyadi, string Email, string Sifre)
    {
        try
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailFormat/Kayit.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{AdiSoyadi}", AdiSoyadi);
            body = body.Replace("{Email}", Email);
            body = body.Replace("{Sifre}", Sifre);

            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("destek@mercanyazilim.net");
            Mesaj.To.Add(Email);
            Mesaj.Subject = AdiSoyadi + " Müşteri Bilgileriniz";
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = body;
            SmtpClient smtp = new SmtpClient("mail.mercanyazilim.net", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("destek@mercanyazilim.net", "q1w2e39420522");
            smtp.Credentials = SMTPUserInfo;
            smtp.Send(Mesaj);
        }
        catch (Exception)
        {

        }
    }
    public static void _fncSiparisKayit(string AdiSoyadi, string Email, string Sifre, string UrunAdi, string Adet, string Fiyat, string Toplam)
    {
        try
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailFormat/Siparis.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{AdiSoyadi}", AdiSoyadi);
            body = body.Replace("{Email}", Email);
            body = body.Replace("{Sifre}", Sifre);
            body = body.Replace("{UrunAdi}", UrunAdi);
            body = body.Replace("{Adet}", Adet);
            body = body.Replace("{Fiyat}", Fiyat);
            body = body.Replace("{Toplam}", Toplam);

            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("destek@mercanyazilim.net");
            Mesaj.To.Add(Email);
            Mesaj.Subject = AdiSoyadi + "MercanYazılım.NET / Sipariş Bilgileriniz";
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = body;
            SmtpClient smtp = new SmtpClient("mail.mercanyazilim.net", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("destek@mercanyazilim.net", "q1w2e39420522");
            smtp.Credentials = SMTPUserInfo;
            smtp.Send(Mesaj);
        }
        catch (Exception)
        {

        }
    }
    //public static bool _fncMailGonder(string MailAdres, string Konu, string MailIcerik)
    //{
    //    try
    //    {
    //        MailMessage Mesaj = new MailMessage();
    //        Mesaj.From = new MailAddress("destek@mercanyazilim.net");
    //        Mesaj.To.Add(MailAdres);
    //        Mesaj.Subject = Konu.ToString();
    //        Mesaj.IsBodyHtml = true;
    //        Mesaj.Body = MailIcerik;
    //        SmtpClient smtp = new SmtpClient("mail.mercanyazilim.net", 587);
    //        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("destek@mercanyazilim.net", "q1w2e39420522");
    //        smtp.Credentials = SMTPUserInfo;


    //        smtp.Send(Mesaj);
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }

    //}
    public static bool _fncMailGonder(string Konu, string _Mail)
    {
        try
        {
            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("destek@mercanyazilim.net");
            Mesaj.To.Add(_Mail);
            Mesaj.Subject = Konu.ToString();
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = Konu.ToString();
            SmtpClient smtp = new SmtpClient("mail.mercanyazilim.net", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("destek@mercanyazilim.net", "q1w2e39420522");
            smtp.Credentials = SMTPUserInfo;


            smtp.Send(Mesaj);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public static void _fncSiparisBilgileri(DataTable _dtYemekSiparis, DataTable _dtEklentiSiparis, string _strAdSoyad, string _strTelefon, string _strOdeme, string _strAdres, string Toplam, string AliciMail, string GonderenMail, string Sifre, string Smtp, int Port, string Konu)
    {
        _dtAyar = _clsData._fncVeriGetir("select Logo from Ayar");

        string Mesaj = "<html><head><title>Sipariş Bilgileri</title><style type='text/css'>body {font-family:Tahoma;}img {border:0;}#page {width:800px;margin:0 auto;padding:15px;}";
        Mesaj += "#logo {float:left;margin:0;}#address {height:181px;margin-left:250px; }table {width:100%;}td {padding:5px;}tr.odd {background:#e1ffe1;}--></style></head><body>";




        Mesaj += "<div id='page'><div id='logo'><img src='" + _dtAyar.Rows[0]["Logo"].ToString() + "'></div><div id='address'><p><strong>Sipariş Bilgileri</strong><br/><br/>";
        Mesaj += "Müşteri Adı: " + _strAdSoyad.ToString() + "<br/>Telefon: " + _strTelefon.ToString() + "<br/>Ödeme Türü: " + _strOdeme.ToString() + "<br/>Adres : " + _strAdres.ToString() + "</p></div><div id='content'><br/>..::Yemek Siparişleri ::..<hr/><table>";
        Mesaj += "<tr><td><strong>Ürün Adı</strong></td><td><strong>Miktar</strong></td><td><strong>Fiyat</strong></td><td><strong>Toplam</strong></td></tr>";
        for (int i = 0; i < _dtYemekSiparis.Rows.Count; i++)
        {
            Mesaj += " <tr class='odd'><td>" + _dtYemekSiparis.Rows[i]["isim"].ToString() + "</td><td>" + _dtYemekSiparis.Rows[i]["adet"].ToString() + "</td><td>" + _dtYemekSiparis.Rows[i]["fiyat"].ToString() + " TL</td><td>" + _dtYemekSiparis.Rows[i]["tutar"].ToString() + " TL</td></tr><tr class='even'></tr>";
        }

        Mesaj += "</table><hr/>..:: Eklenti Siparişleri ::..<hr/><table><tr><td><strong>Ürün Adı</strong></td><td><strong>Miktar</strong></td><td><strong>Fiyat</strong></td><td><strong>Toplam</strong></td></tr>";

        try
        {
            for (int i = 0; i < _dtEklentiSiparis.Rows.Count; i++)
            {
                Mesaj += " <tr class='odd'><td>" + _dtEklentiSiparis.Rows[i]["isim"].ToString() + "</td><td>" + _dtEklentiSiparis.Rows[i]["adet"].ToString() + "</td><td>" + _dtEklentiSiparis.Rows[i]["fiyat"].ToString() + " TL</td><td>" + _dtEklentiSiparis.Rows[i]["tutar"].ToString() + " TL</td></tr><tr class='even'></tr>";
            }
        }
        catch (Exception)
        {

        }

        Mesaj += "</table><hr><table><tr><td><strong>Genel Toplam&nbsp; </strong></td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td>&nbsp; &nbsp;</td><td><strong>" + Toplam.ToString() + "</strong></td></tr></table></div></div></body></html>";

        MailMessage _mailMesaj = new MailMessage();
        _mailMesaj.From = new MailAddress(GonderenMail);
        _mailMesaj.To.Add(AliciMail);
        _mailMesaj.Subject = Konu.ToString();
        _mailMesaj.IsBodyHtml = true;
        _mailMesaj.Body = Mesaj;
        SmtpClient smtp = new SmtpClient(Smtp, Port);
        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(GonderenMail, Sifre);
        smtp.Credentials = SMTPUserInfo;

        try
        {
            smtp.Send(_mailMesaj);
        }
        catch
        {

        }
    }
}