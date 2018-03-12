<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Eklenti.aspx.cs" Inherits="Yonetici_Eklenti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincontent">
        	<div class="contentinner">
    <asp:Panel ID="_pnlListe" runat="server">
    <h4 class="widgettitle">Eklenti Listesi</h4>
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
                          	<th class="head0 nosort">#ID</th>
                            <th class="head0">Eklenti Adı</th>
                            <th class="head0">Resim</th>
                            <th class="head1">Fiyat</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstYemekler" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("EklentiKatID") %>
                          </span></td>
                            <td><%#Eval("EklentiAdi") %></td>
                            <td class="center"><img src="../<%#Eval("Resim") %>" height="30" width="30" /></td>
                            <td class="center"><%#String.Format("{0:C}",Eval("Fiyat")) %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="#"><i class="iconsweets-pdf"></i> &nbsp;-</a></li>
                                              <li><a href="#"><i class="iconsweets-like"></i> &nbsp;-</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Eklenti.aspx?Sil=<%#Eval("EklentiKatID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                            </ul>
                                        </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                
                <div class="divider15"></div>
    </asp:Panel>
        <asp:Panel ID="_pnlEkle" runat="server">
                        <h4 class="widgettitle nomargin shadowed">Yeni Eklenti Ekle</h4>
                <div class="widgetcontent bordered">
                   <%-- <form id="form1" class="stdform stdform2" runat="server">--%>
                            <p>
                                <label>Eklenti Adı</label>
                                <span class="field">
                                    <asp:TextBox ID="_txtEklentiAdi" CssClass="input-xxlarge" runat="server"></asp:TextBox>
                                </span>
                            </p>
                            <p>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Ana Kategori Ekleyeceğim" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" /></p>
                            <p>
                                <label>Eklenti Kategori</label>
                                <span class="field">
                                    <asp:DropDownList ID="_drpKategori" runat="server"></asp:DropDownList>
                                </span>
                            </p>
                                   <p>
                                       <label>
                                       Eklenti Resmi</label> <span class="field">
                                       <asp:FileUpload ID="FileUpload1" runat="server" />
                                       <asp:RegularExpressionValidator ID="PictureExpressionValidator" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Lütfen bir imaj dosyası seçiniz." SetFocusOnError="True" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$">  
</asp:RegularExpressionValidator>
                                       </span>
                                   </p>
                                   <p>
                                       <label>
                                       Eklenti Ücreti</label> <span class="field">
                                       <asp:TextBox ID="_txtFiyat" runat="server"></asp:TextBox>
                                       Örnek : 9,5 </span>
                                   </p>
                                   <p class="stdformbutton">
                                       <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Kaydet" OnClick="Button1_Click" />
                                       <button class="btn" type="reset">
                                           Temizle
                                       </button>
                                   </p>
                                   <asp:Label ID="_lblKayit" runat="server" Text=""></asp:Label>
                                   <%--  </form>--%>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                            </p>
                            
                    </div><!--widgetcontent-->
    </asp:Panel>
    </div></div>
</asp:Content>

