using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Siparis : System.Web.UI.Page
{
    DataTable _dtSiparis;
    DataTable _dtSiparisEklenti;
    Data _clsData = new Data();
    Sepet _clsSepet = new Sepet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _pnlEklentiSiparisleri.Visible = false;
                SepetGetir();
        }
        
        try
        {
            if (Request.QueryString["myp"].ToString() != "")
            {
                string YemekID = Request.QueryString["myp"].ToString();
                _dtSiparis = _clsData._fncVeriGetir("select * from Yemek where YemekID=" + YemekID.ToString());
                _dtSiparisEklenti = _clsData._fncVeriGetir("select * from Eklenti where YemekID=" + YemekID.ToString());
                _clsSepet.Ekle(YemekID, _dtSiparis.Rows[0]["YemekAdi"].ToString(), _dtSiparis.Rows[0]["Resim"].ToString(),1, Convert.ToDouble(_dtSiparis.Rows[0]["Fiyat"]));

                SepetGetir();
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["SiparisSil"].ToString() != "")
            {
                _clsSepet.Sil(Request.QueryString["SiparisSil"].ToString());
                SepetGetir();
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["EklentiSiparisSil"].ToString() != "")
            {
                _clsSepet.EklentiSil(Request.QueryString["EklentiSiparisSil"].ToString());
                SepetGetir();
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Sepet"].ToString() == "null")
            {
                Session.Clear();
                Response.Redirect("Anasayfa.aspx");
            }
        }
        catch (Exception)
        {
            
        }
       // _fncSepetGuncelle();
    }

    private void SepetGetir()
    {
        if (Session["sepet"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["sepet"];
            _lstSepet.DataSource = dt.DefaultView;
            _lstSepet.DataBind();
            lblToplam.Text = _clsSepet.SepetToplam().ToString();
            EklentiSepetGetir(Convert.ToDouble(_clsSepet.SepetToplam()));
        }
    }
    private void EklentiSepetGetir(double Ucret)
    {
        if (Session["Eklentisepet"] != null)
        {
            _pnlEklentiSiparisleri.Visible = true;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Eklentisepet"];
            _lstEklenti.DataSource = dt.DefaultView;
            _lstEklenti.DataBind();
            double toplam = Ucret + Convert.ToDouble(_clsSepet.EklentiToplam());
            lblToplam.Text = toplam.ToString() + " TL.";
        }
    }
    protected void _lstSepet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.FindControl("TextBox1").ID =="TextBox1")
        {
            TextBox _txAdet;
            _txAdet = (TextBox)e.Item.FindControl("TextBox1");
            
        }
    }

    protected void _lstSepet_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (Request.QueryString["Guncelle"].ToString()!="")
            {
                TextBox _txAdet = (TextBox)e.Item.FindControl("Text1");
                _clsSepet.Guncelle(Request.QueryString["Guncelle"].ToString(), Convert.ToInt32(_txAdet.Text));
                
            }
        }
        catch (Exception)
        {

        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}