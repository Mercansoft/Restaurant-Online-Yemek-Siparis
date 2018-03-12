<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="Yonetici_Kategori" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincontent">
<div class="contentinner">
<h4 class="widgettitle nomargin shadowed">Kategori Ekle</h4>
            <div class="widgetcontent bordered shadowed nopadding">
                    <%--<form class="stdform stdform2" method="post" runat="server">--%>
                            <p>
                                <label>Kategori Adı</label>
                                <span class="field"><asp:TextBox ID="_txtKategoriAdi" CssClass="input-xxlarge" runat="server"></asp:TextBox></span>
                            </p>
                            
                            <p>
                                <label>Üst Kategori</label>
                                <span class="field">
                                    <asp:CheckBox ID="_chkAltKategori" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="_chkAltKategori_CheckedChanged" /> <asp:DropDownList ID="_drpKategoriList" runat="server">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            
                            <p>
                                <label>Kategori Resmi</label>
                                <span class="field">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </span>
                            </p>
                                                    
                            <p class="stdformbutton">
                                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" 
                                    Text="Kaydet" onclick="Button1_Click" />
                            </p>
                       <%-- </form>--%>
                    </div>
            	<h4 class="widgettitle">Kategoriler</h4>
            	<table class="table table-bordered" id="dyntable">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                          	<th class="head0 nosort"># ID</th>
                            <th class="head0">Kategori Adı</th>
                            <th class="head1">Resim</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstKategori" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("KategoriID") %>
                          </span></td>
                            <td><%#Eval("KategoriAdi") %></td>
                            <td><img src="../<%#Eval("Resim") %>" height="50" width="50" /></td>
                            <td><a href="Kategori.aspx?Sil=<%#Eval("KategoriID") %>">Sil</a></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                
                <div class="divider15">
                <cc1:CollectionPager ID="cpSayfala" runat="server" BackText="« Önceki" FirstText="İlk" LabelText="Sayfa :" LastText="Son" NextText ="Sonraki »" PageNumbersDisplay="Numbers" PageSize="10" SectionPadding="10" QueryStringKey="myp" ResultsLocation="None" ShowFirstLast="False" ShowLabel="True" ShowPageNumbers="True" BackNextLinkSeparator="">
</cc1:CollectionPager> 
                </div>
                                
            </div></div>
</asp:Content>

