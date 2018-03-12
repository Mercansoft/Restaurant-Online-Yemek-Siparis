using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Kategori : System.Web.UI.Page
{
    Data _clsData = new Data();
    DataTable _dtKatYemek;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Slider();
            _fnc_PopulerYemekler();
        }

        try
        {
            string katID = Guvenlik._SqlBugKontrol(Request.QueryString["KatID"].ToString());
            if (katID != "")
            {
                _dtKatYemek = _clsData._fncVeriGetir("select * from Yemek where KategoriID=" + katID.ToString());
                cpSayfala.DataSource = _dtKatYemek.DefaultView;
                cpSayfala.BindToControl = _lstKatYemekler;
                _lstKatYemekler.DataSource = cpSayfala.DataSourcePaged;
                _lstKatYemekler.DataBind();
            }
        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }
    }
    private void _fnc_PopulerYemekler()
    {
        try
        {
            _lstPopulerYemekler.DataSource = _clsData._fncVeriGetir("SELECT TOP 6 * FROM Yemek ORDER BY Hit DESC");
            _lstPopulerYemekler.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    private void _fnc_Slider()
    {
        try
        {
            _lstSlider.DataSource = _clsData._fncVeriGetir("SELECT  dbo.Yemek.YemekID, dbo.Yemek.YemekAdi, dbo.Yemek.KucukResim, dbo.Yemek.Fiyat FROM dbo.Slider INNER JOIN dbo.Yemek ON dbo.Slider.YemekID = dbo.Yemek.YemekID");
            _lstSlider.DataBind();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}