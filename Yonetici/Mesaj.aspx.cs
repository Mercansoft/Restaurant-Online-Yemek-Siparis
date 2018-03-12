using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetici_Mesaj : System.Web.UI.Page
{
    Data _clsData = new Data();
    DataTable _dtMesaj;
    DataTable _dtOkunmusMesaj;
    DataTable _dtveri;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_GelenMesaj();
            _pnlOkunmusMesajlar.Visible = false;
            _pnlMesajOku.Visible = false;
        }
        try
        {
            if (Request.QueryString["Sil"].ToString() != "")
            {
                _clsData._fncVeriGetir("DELETE FROM Mesaj WHERE MesajID=" + Request.QueryString["Sil"].ToString());
                _fnc_GelenMesaj();
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["TumunuSil"].ToString() == "OK")
                _dtveri = _clsData._fncVeriGetir("SELECT * FROM Mesaj");
            {
                for (int i = 0; i < _dtveri.Rows.Count; i++)
                {
                    _clsData._fncSQLCalistir("DELETE FROM Mesaj WHERE MesajID="+ _dtveri.Rows[i]["MesajID"].ToString());
                }
            }
            Response.Redirect("Mesaj.aspx");
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Oku"].ToString() != "")
            {
                _pnlMesajOku.Visible = true;
                _pnlGelenMesajlar.Visible = false;
                _pnlOkunmusMesajlar.Visible = false;
               _lstMesaj.DataSource=_clsData._fncVeriGetir("SELECT * FROM Mesaj WHERE MesajID=" + Request.QueryString["Oku"].ToString());
               _lstMesaj.DataBind();
               _clsData._Metot_SQL_Calistir("UPDATE Mesaj SET Durum=0 WHERE MesajID=" + Request.QueryString["Oku"].ToString());
                
            }
        }
        catch (Exception)
        {

        }
        try
        {
            if (Request.QueryString["Listele"].ToString() != "")
            {
                _pnlMesajOku.Visible = false;
                _pnlGelenMesajlar.Visible = false;
                _pnlOkunmusMesajlar.Visible = true;
                _lstOkunmusMesaj.DataSource = _clsData._fncVeriGetir("SELECT * FROM Mesaj WHERE Durum=0");
                _lstOkunmusMesaj.DataBind();

            }
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_GelenMesaj()
    {
        try
        {
            _dtMesaj = _clsData._fncVeriGetir("SELECT * FROM Mesaj WHERE Durum=1");
            _lstSiparisler.DataSource = _dtMesaj;
            _lstSiparisler.DataBind();
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_OkunmusMesaj()
    {
        try
        {
            _dtOkunmusMesaj = _clsData._fncVeriGetir("SELECT * FROM Mesaj WHERE Durum=0");
            _lstOkunmusMesaj.DataSource = _dtOkunmusMesaj;
            _lstOkunmusMesaj.DataBind();
        }
        catch (Exception)
        {

        }
    }
}