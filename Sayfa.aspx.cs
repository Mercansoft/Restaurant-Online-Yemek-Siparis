using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sayfa : System.Web.UI.Page
{
    Data _clsData = new Data();
    DataTable _dtSayfa;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_IcerikGetir();
            _fnc_Sayfalar();
            try
            {
                DataTable _dtAyar = _clsData._fncVeriGetir("select * from Ayar");
            _lblTitle.Text = _dtAyar.Rows[0]["Title"].ToString();
            }
            catch (Exception)
            {
                
            }
        }
        try
        {
            if (Request.QueryString["myp"].ToString()!="")
            {
                _dtSayfa = _clsData._fncVeriGetir("select * from Sayfa where SayfaID="+Request.QueryString["myp"].ToString());
                _imgIcerikResim.ImageUrl = _dtSayfa.Rows[0]["Resim"].ToString();
                _lblIcerik.Text = _dtSayfa.Rows[0]["Icerik"].ToString();
            }
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_IcerikGetir()
    {
        try
        {
            _dtSayfa = _clsData._fncVeriGetir("select * from Sayfa");
            _imgIcerikResim.ImageUrl = _dtSayfa.Rows[0]["SayfaAdi"].ToString();
            _lblIcerik.Text = _dtSayfa.Rows[0]["Icerik"].ToString();
        }
        catch (Exception)
        {
            
        }

    }
    private void _fnc_Sayfalar()
    {
        try
        {
            _lstSayfalar.DataSource = _clsData._fncVeriGetir("select * from Sayfa");
            _lstSayfalar.DataBind();
        }
        catch (Exception)
        {
            
        }
    }
}