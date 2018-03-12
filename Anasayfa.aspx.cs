using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anasayfa : System.Web.UI.Page
{
    Data _clsData = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["IPAdres"] = Request.ServerVariables["REMOTE_ADDR"];
        if (!Page.IsPostBack)
        {
            Session["IPAdres"] = Request.ServerVariables["REMOTE_ADDR"];
            Data.deger = false;
            _fnc_Manset();
            _fnc_Yemekler2();
        }
    }
    private void _fnc_Manset()
    {
        _lstManset.DataSource = _clsData._fncVeriGetir("select * from Manset");
        _lstManset.DataBind();
    }
    private void _fnc_Yemekler2()
    {
        _lstYemekler.DataSource = _clsData._fncVeriGetir("select TOP 16 * from Yemek ORDER BY YemekID DESC");
        _lstYemekler.DataBind();
    }
    private void _fnc_Yemekler()
    {
        _lstYemekler.DataSource = _clsData._fncVeriGetir("select TOP 16 Yemek.YemekID, Kategori.KategoriAdi, Yemek.YemekAdi, Yemek.KucukResim, Yemek.Fiyat, Yemek.UrunKodu, Yemek.YemekAciklama, Yemek.Hit FROM Yemek INNER JOIN Kategori ON dbo.Yemek.KategoriID = dbo.Kategori.KategoriID ORDER BY YemekID DESC");
        _lstYemekler.DataBind();
    }
}