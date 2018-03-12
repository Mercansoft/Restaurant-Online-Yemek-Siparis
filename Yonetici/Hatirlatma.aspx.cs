using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_Hatirlatma : System.Web.UI.Page
{
    Data _clsData = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _fnc_Hatirlat();
        }

        try
        {
            if (Request.QueryString["Sil"].ToString() != "")
            {
                _clsData._fncVeriGetir("DELETE FROM Hatirlat WHERE HatirlatID=" + Request.QueryString["Sil"].ToString());
               _fnc_Hatirlat();
            }
        }
        catch (Exception)
        {

        }
    }
    private void _fnc_Hatirlat()
    {
        _lstTumSiparis.DataSource = _clsData._fncVeriGetir("select * from Hatirlat");
        _lstTumSiparis.DataBind();
    }
}