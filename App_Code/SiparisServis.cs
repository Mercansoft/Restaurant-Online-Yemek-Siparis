using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Timers;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for SiparisServis
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SiparisServis : System.Web.Services.WebService {
    Timer timer = new System.Timers.Timer(5000);
    public SiparisServis () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        timer.Elapsed += timer_Elapsed;
        timer.Start();
        _FncSiparis();
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public void _FncSiparis()
    {
        string Baglan = "Data Source=localhost;Initial Catalog=MercanRestorant;User ID=sa;Password=123456 providerName=System.Data.SqlClient";
        DataTable _dtVeri = new DataTable();
        try
        {
            SqlConnection _SqlCnnBaglan = new SqlConnection(Baglan);
            _SqlCnnBaglan.Open();
            SqlCommand _SqlCmdBaglan = new SqlCommand("SELECT * FROM Siparis Durum=1", _SqlCnnBaglan);
            SqlDataAdapter _SqlDAdapter = new SqlDataAdapter(_SqlCmdBaglan);
            _SqlDAdapter.Fill(_dtVeri);
            _SqlCnnBaglan.Close();
        }
        catch (Exception ex)
        {
           
        }
        try
        {
            if (_dtVeri.Rows.Count!=0)
            {
            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("yavuz@yavuzmercan.com");
            Mesaj.To.Add("yavuz@yavuzmercan.com");
            Mesaj.Subject = "Sipariş Geldi.";
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = "Sipariş Var";
            SmtpClient smtp = new SmtpClient("mail.yavuzmercan.com", Convert.ToInt32("25"));
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("yavuz@yavuzmercan.com", "q1w2e39420522");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = SMTPUserInfo;
            smtp.Send(Mesaj);
            }
        }
        catch
        {
            
        }


    }
    protected void timer_Elapsed(object sender, EventArgs e)
    {
        string Baglan = "Data Source=localhost;Initial Catalog=MercanRestorant;User ID=sa;Password=123456 providerName=System.Data.SqlClient";
        DataTable _dtVeri = new DataTable();
        try
        {
            SqlConnection _SqlCnnBaglan = new SqlConnection(Baglan);
            _SqlCnnBaglan.Open();
            SqlCommand _SqlCmdBaglan = new SqlCommand("SELECT * FROM Siparis Durum=1", _SqlCnnBaglan);
            SqlDataAdapter _SqlDAdapter = new SqlDataAdapter(_SqlCmdBaglan);
            _SqlDAdapter.Fill(_dtVeri);
            _SqlCnnBaglan.Close();
        }
        catch (Exception ex)
        {

        }
        try
        {
            if (_dtVeri.Rows.Count != 0)
            {
                MailMessage Mesaj = new MailMessage();
                Mesaj.From = new MailAddress("yavuz@yavuzmercan.com");
                Mesaj.To.Add("yavuz@yavuzmercan.com");
                Mesaj.Subject = "Sipariş Geldi.";
                Mesaj.IsBodyHtml = true;
                Mesaj.Body = "Sipariş Var";
                SmtpClient smtp = new SmtpClient("mail.yavuzmercan.com", Convert.ToInt32("25"));
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("yavuz@yavuzmercan.com", "q1w2e39420522");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = SMTPUserInfo;
                smtp.Send(Mesaj);
            }
        }
        catch
        {

        }
        timer.Stop();
    }
}
