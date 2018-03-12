<%@ Page Language="C#" AutoEventWireup="true" CodeFile="backup.aspx.cs" Inherits="backup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mercan Yazýlým .NET SQL Server Veritabaný Yedekleme Sistemi v1.1</title>
    <style>
        body
        {
            font-family:verdana, arial;
            font-size:10pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="2" cellspacing="1" border="1" style="border-collapse: collapse;">
                <tr>
                    <th style="background-color:#e0e0e0;">
                        Backup and Restore SQL Server
                        <br />
                        database using ASP.NET</th>
                </tr>
                <tr>
                    <td align="Center">
                        List of Tables</td>
                </tr>
                <tr>
                    <td align="Center">
                        <asp:ListBox ID="ListBox1" Rows="10" runat="Server" DataTextField="table_name" DataValueField="table_name">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="Center">
                        <span onclick="return confirm('Are you sure to backup selected table?')">
                        <asp:Button ID="btnBackup" runat="Server" Text="Backup" OnClick="BackUpNow" />
                        </span>
                        <span onclick="return confirm('Are you sure to restore selected table?')">
                        <asp:Button ID="btnRestore" runat="Server" Text="Restore" OnClick="RestoreNow" />
                        </span>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMessage" runat="Server" EnableViewState="False" ForeColor="Blue"></asp:Label>
            <asp:GridView ID="GridView1" runat="Server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
