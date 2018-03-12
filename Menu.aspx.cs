using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    Data _clsData = new Data();
    DataTable _dtKatYemek;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Slider();
            _fnc_PopulerYemekler();
            _Fnc_Menuler();
        }

        try
        {
            if (Request.QueryString["KatID"].ToString() != "")
            {
                _dtKatYemek = _clsData._fncVeriGetir("SELECT  dbo.Yemek.YemekID, dbo.Yemek.YemekAdi, dbo.Yemek.Resim, dbo.Yemek.Fiyat FROM dbo.Menu INNER JOIN dbo.Yemek ON dbo.Menu.YemekID = dbo.Yemek.YemekID");
                cpSayfala.DataSource = _dtKatYemek.DefaultView;
                cpSayfala.BindToControl = _lstKatYemekler;
                _lstKatYemekler.DataSource = cpSayfala.DataSourcePaged;
                _lstKatYemekler.DataBind();
            }
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_PopulerYemekler()
    {
        try
        {
            _lstPopulerYemekler.DataSource = _clsData._fncVeriGetir("SELECT TOP 3 * FROM Yemek ORDER BY Hit DESC");
            _lstPopulerYemekler.DataBind();
        }
        catch (Exception)
        {
            
        }
    }
    private void _Fnc_Menuler()
    {
        try
        {
                _dtKatYemek = _clsData._fncVeriGetir("SELECT  dbo.Yemek.YemekID, dbo.Yemek.YemekAdi, dbo.Yemek.Resim, dbo.Yemek.Fiyat FROM dbo.Menu INNER JOIN dbo.Yemek ON dbo.Menu.YemekID = dbo.Yemek.YemekID");
                cpSayfala.DataSource = _dtKatYemek.DefaultView;
                cpSayfala.BindToControl = _lstKatYemekler;
                _lstKatYemekler.DataSource = cpSayfala.DataSourcePaged;
                _lstKatYemekler.DataBind();
        }
        catch (Exception)
        {
            
        }
    }
    private void _fnc_Slider()
    {
        try
        {
            _lstSlider.DataSource = _clsData._fncVeriGetir("SELECT dbo.Slider.SliderID, dbo.Yemek.YemekID, dbo.Yemek.YemekAdi, dbo.Yemek.BuyukResim, dbo.Yemek.Fiyat FROM dbo.Slider INNER JOIN  dbo.Yemek ON dbo.Slider.YemekID = dbo.Yemek.YemekID");
            _lstSlider.DataBind();
        }
        catch (Exception)
        {
            
        }
    }
}