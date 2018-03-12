<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Setup_Default" %>

<html>
<head>
    <title>Mercan Yazılım .NET Restaurant Online Sipariş Yazılımı v3 Setup Bölümü</title>
    <link rel="stylesheet" href="style/default.css" type="text/css" />
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.5.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
    <table style="height: 100%; width: 100%" align="center">
        <tr>
            <td align="center" valign="middle">
                <table cellspacing="0" cellpadding="0" border="0" style="background-color: #ffffff;
                    border: solid 1px #999999; height: 525; width: 100%">
                    <tbody>
                        <tr>
                            <td colspan="2" valign="top" height="75" background="images/installer_top_bg.png"
                                style="background-repeat: repeat-x; color: #fff; font-size: 20px; padding: 10px;">
                                Mercan Yazılım .NET Restaurant Online Sipariş Yazılımı v3 Setup Bölümü
                            </td>
                        </tr>
                        <tr>

                            <td valign="top">
                                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 0px">
                                    <asp:Panel ID="PreInstall" runat="server">
                                        <div class="mainTitle">
                                            Hostunuzda Olması Gereken Yazılmlar</div>
                                        <div class="wizardsectionheader">
                                            <strong>Yazılımlar:</strong></div>
                                        <div class="wizardsection">
                                            <ul>
                                                <li style="margin-bottom: 8px;">
                                                    <div class="bold">
                                                        Microsoft .NET Framework</div>
                                                    <div>
                                                        Version 4.0 of the .NET framework yüklü olmalı</div>
                                                    <div>
                                                        <a href="http://www.asp.net/Default.aspx?tabindex=0&tabid=1" target="_blank">Yüklü değil ise
                                                            tıklayarak .NET framework'ü yükleyiniz</a></div>
                                                </li>
                                                <li style="margin-bottom: 8px;">
                                                    <div class="bold">
                                                        Internet Information Server</div>
                                                    <div>
                                                        IIS yada Compatible Web Server yazılımı yüklü olmalı</div>
                                                    <div>
                                                        <a href="http://www.google.com/search?q=install+iis" target="_blank">Yüklü değil ise
                                                            tıklayarak ISS'i yükleyiniz</a></div>
                                                </li>
                                                <li style="margin-bottom: 8px;">
                                                    <div class="bold">
                                                        Microsoft SQL Server</div>
                                                      <div>
                                                        Restaurant Online Sipariş Sistemi Veritabanının çalışabilmesi içinr SQL Server 2005, SQL Server 2008, yada SQL Server Express 2008
                                                        yüklü olmalı.</div>
                                                    <div>
                                                        <a href="http://www.microsoft.com/sqlserver/" target="_blank">Yüklü değilse lütfen tıklayarak
                                                            SQL Serverı yükleyiniz</a></div>
                                                </li>
                                            </ul>
                                            <div align="right" style="padding-right: 50px;">
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Bütün Hepsi Yüklü" Checked="false" 
                                                AutoPostBack="True" />
                                            <br />
                                            <asp:Literal ID="Literal1" runat="server" Visible="false"><span class="err" style="color:Red">İşaretlemeden Geçemezsiniz</span></asp:Literal>
                                        </div>
                                        </div>
                                                                                
                                    </asp:Panel>
                                    <asp:Panel ID="_pnlLisans" runat="server">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <span class="mainTitle">Restaurant Online Sipariş Yazılımı v3 Kullanım Şartları / Lisans</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="right" colspan="2">
                                                    <iframe frameborder="1" scrolling="auto" src="http://www.mercanyazilim.net/Lisans/MercanRestaurant.html" height="300" width="680">
                                                    </iframe>
                                                </td>
                                            </tr>
                                        </table>
                                        <br>
                                        <div align="right" style="padding-right: 50px;">
                                            <asp:CheckBox ID="chkIAgree" runat="server" Text="Okudum Kabul Ediyorum" Checked="false" 
                                                AutoPostBack="True" />
                                            <br />
                                            <asp:Literal ID="errIAgree" runat="server" Visible="false"><span class="err" style="color:Red">İşaretlemeniz gerekli</span></asp:Literal>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="_pnlConnectToDb" runat="server">
                                        <div class="mainTitle">
                                            Veri Tabanı Bilgileri</div>
                                        <div class="wizardsection">

                                            <div style="padding-left: 20px; padding-top: 20px">
                                                &nbsp;
                                                <div style="padding-left: 20px; padding-top: 20px">
                                                    <table>
                                                                                                            <tr>
                                                            <td align="left">
                                                                 Host IP Adresi:
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox CssClass="dataentry" ID="_txtDomain" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                                                                            <tr>
                                                            <td align="left">
                                                                VeriTabanı Adı:
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox CssClass="dataentry" ID="_txtDbName" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Kullanıcı Adı:
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox CssClass="dataentry" ID="_txtDbUser" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Şifre :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox CssClass="dataentry" ID="_txtDbPassword" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr><td align="left"></td><td align="left">
                                                            </td></tr>
                                                    </table>
                                                </div>
                                            </div>
                                                                                    <div align="right" style="padding-right: 50px;">
                                            <asp:CheckBox ID="_chkDbBilgi" runat="server" Text="Devam Et" Checked="false" 
                                                AutoPostBack="True"/>
                                            <br />
                                            <asp:Literal ID="Literal2" runat="server" Visible="false"><span class="err" style="color:Red">İşaretlemeniz gerekli</span></asp:Literal>
                                        </div>

                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="_pnlSiteAyar" runat="server">
                                        <div class="mainTitle">
                                            Site Ayarları / Yönetici</div>
                                        <div class="wizardsectionheader">
                                            Siteniz ile ilgili Ayarların Girileceği Panel
                                        </div>
                                        <div class="wizardsection">
                                            <table cellpadding="2" cellspacing="0" border="0">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        Site Title:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="_txtTitle" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td width="50%" nowrap="nowrap">
                                                        Sitenizin Title Kısmı Örn: "Mercan Restaurant Lezzen Durağınız"
                                                    </td>
                                                </tr>
                                               <tr>
                                                    <td align="left" valign="top">
                                                        Anahtar Kelimeler(Keywords):
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="_txtAnahtarKelime" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td width="50%" nowrap="nowrap">
                                                        Sitenizin Google Arama Kelimeleri Örn: "online yemek siparişi,yemek sipariş"
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        Açıklama (Description):
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="_txtAciklama" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td width="50%" nowrap="nowrap">
                                                        Sitenizin için Açıklama Giriniz Örn: "Bu sitede Aradığınız tüm bilgilere ulaşmanız mümkün"
                                                    </td>
                                                </tr>
                                              <tr>
                                                    <td align="left" valign="top">
                                                        Kullanıcı Adı:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="_txtKullaniciAdi" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td width="50%" nowrap="nowrap">
                                                        Admin Panelinize giriş için Kullanıcı Adı Giriniz
                                                    </td>
                                                </tr>
                                                                                              <tr>
                                                    <td align="left" valign="top">
                                                        Şifreniz:
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="_txtSifre" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td width="50%" nowrap="nowrap">
                                                        Admin Panelinize giriş için Şifre Giriniz
                                                    </td>
                                                </tr>
                                            </table>
                                            <div align="right" style="padding-right: 50px;">
                                                <asp:Button ID="Button1" runat="server" Text="Gönder" onclick="Button1_Click" />
                                            <br />
                                            <asp:Literal ID="Literal3" runat="server" Visible="false"><span class="err" style="color:Red">Butonu Tıklamanız gerekli</span></asp:Literal>
                                        </div>
                                        </div>
                                    </asp:Panel>
                                    
                                    <asp:Panel ID="Tamam" runat="server">
                                        <div class="mainTitle">
                                            Site Kurulumu Tamamlandı.<br /><br /><a href="../Default.aspx">Siteye Git</a>   |  <a href="../Yonetici/Default.aspx">Admin Panel</a></div>

                                    </asp:Panel>
                                    <asp:Panel ID="Hata" runat="server">
                                        <div class="mainTitle">
                                            Hata!</div>
                                        <div class="wizardsection">
                                            <div>
                                                <div>
                                                    <a href="Default.aspx">Başa Dön ve Ayarlarını Kontrol Et</a><br /><br />
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" colspan="2">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right" bgcolor="#cecece" height="45">
                                <div style="padding-right: 30px;">
                                    &nbsp;</div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
