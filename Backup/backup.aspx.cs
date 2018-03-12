using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class backup : System.Web.UI.Page
{
     string connStr = "Data Source=78.135.111.139;Initial Catalog=yavuzata_yemek;User ID=yavuzata_ymkuser;Password=@Yzq1w2e3";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateDatabaseTables();
        }
    }

    /// <summary>
    /// Populate database tables first
    /// </summary>
    private void PopulateDatabaseTables()
    {
        string tableName = string.Empty;
        string sql = "SELECT *, name AS table_name " +
                        " FROM sys.tables WHERE Type = 'U' ORDER BY table_name";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (DataTable table = new DataTable())
            {
                conn.Open();
                using (SqlDataAdapter dAd = new SqlDataAdapter(sql, conn))
                {
                    dAd.Fill(table);
                }

                ListBox1.DataSource = table;
                ListBox1.DataBind();
            }
        }
    }

    /// <summary>
    /// Backup the selected table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackUpNow(object sender, EventArgs e)
    {
        string tableName = ListBox1.SelectedValue;
        using (DataSet dSetBackup = new DataSet())
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select * from " + tableName, conn))
                {
                    dAd.Fill(dSetBackup, tableName);
                }
            }
            dSetBackup.WriteXml(Server.MapPath("~/Backup/" + tableName + ".xml"));
            lblMessage.Text = "Backup for table <b>" + tableName + "</b> successful!";
        }
    }

    /// <summary>
    /// Restore the selected table 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RestoreNow(object sender, EventArgs e)
    {
 try {


        string restoreConnStr = connStr;
        string tableName = ListBox1.SelectedValue;

        using (SqlConnection conn = new SqlConnection(restoreConnStr))
        {
            using (DataSet dSetBackup = new DataSet())
            {
                // get the schema of the selected table from the database to restore
                using (SqlDataAdapter dAd = new SqlDataAdapter("select * from " + tableName, conn))
                {
                    dAd.Fill(dSetBackup, tableName);
                    // get the data from XML to restore
                    using (DataSet dSet = new DataSet())
                    {
                        dSet.ReadXml(Server.MapPath("~/Backup/" + tableName + ".xml"));

                        // Loop through all rows of Sql server data table and add into MySql dataset
                        foreach (DataRow row in dSet.Tables[0].Rows)
                        {
                            dSetBackup.Tables[0].NewRow();
                            dSetBackup.Tables[0].Rows.Add(row.ItemArray);
                        }

                        // Create a command builder to update MySql dataset
                        SqlCommandBuilder cmd = new SqlCommandBuilder(dAd);

                        // Following update command will push all added rows into Sql dataset to database
                        dAd.Update(dSetBackup, tableName); // We are done !!!
                    }
                }
                lblMessage.Text = "Restore of table <b>" + tableName + "</b> successful!";
            }
        }
    }
catch (Exception) {
lblMessage.Text = "Hata!";
}
}

}
