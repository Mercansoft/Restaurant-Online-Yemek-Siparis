<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Yemek.aspx.cs" Inherits="Yonetici_Yemek" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="maincontent">
        	<div class="contentinner">
    <asp:Panel ID="_pnlListe" runat="server">
    <h4 class="widgettitle">Yemek Listesi</h4>
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
                            <th class="head0">Yemek Adı</th>
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
                            <%#Eval("YemekID") %>
                          </span></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="center"><img src="../<%#Eval("KucukResim") %>" height="30" width="30" /></td>
                            <td class="center"><%#String.Format("{0:C}",Eval("Fiyat")) %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="#"><i class="iconsweets-pdf"></i> &nbsp;-</a></li>
                                              <li><a href="#"><i class="iconsweets-like"></i> &nbsp;-</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Yemek.aspx?Sil=<%#Eval("YemekID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
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
                        <h4 class="widgettitle nomargin shadowed">Yeni Yemek Ekle</h4>
                <div class="widgetcontent bordered">
                   <%-- <form id="form1" class="stdform stdform2" runat="server">--%>
                            <p>
                                <label>Yemek Adı</label>
                                <span class="field">
                                    <asp:TextBox ID="_txtYemekAdi" CssClass="input-xxlarge" runat="server"></asp:TextBox>
                                </span>
                            </p>
                            
                            <p>
                                <label>Yemek Kategori</label>
                                <span class="field">
                                    <asp:DropDownList ID="_drpKategori" runat="server"></asp:DropDownList>
                                </span>
                            </p>
                               <p>
                                <label>Yemek Eklentisi</label>
                                <span class="field">
                                    <asp:Panel ID="_pnlEklentiCheck" runat="server"><asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Yemek Yanına Eklentisi Varmı?" /></asp:Panel>
                                    <asp:Panel ID="_pnlEklenti" runat="server"><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></asp:Panel>
                                   
                                </span>
                                   <p>
                                   </p>
                                   <p>
                                       <label>
                                       Yemek Resmi</label> <span class="field">
                                       <asp:FileUpload ID="FileUpload1" runat="server" />
                                       <asp:RegularExpressionValidator ID="PictureExpressionValidator" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Lütfen bir imaj dosyası seçiniz." SetFocusOnError="True" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$">  
</asp:RegularExpressionValidator>
                                       </span>
                                   </p>
                                   <p>
                                       <label>
                                       Yemek Ücreti</label> <span class="field">
                                       <asp:TextBox ID="_txtFiyat" runat="server"></asp:TextBox>
                                       Örnek : 9,5 </span>
                                   </p>
                                   <p>
                                       <label>
                                       Yemek Kodu</label> <span class="field">
                                       <asp:TextBox ID="_txtUrunKodu" runat="server"></asp:TextBox>
                                       </span>
                                   </p>
                                   <p>
                                       <label>
                                       Yemek Açıklaması <small>Yemek içeriği ve Servisi Hakkında detaylı Bilgi verebilirsiniz.</small></label> <span class="field">
                                       <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>
                                       </span>
                                   </p>
                                   <p class="stdformbutton">
                                       <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" onclick="Button1_Click" Text="Kaydet" />
                                       <button class="btn" type="reset">
                                           Temizle
                                       </button>
                                   </p>
                                   <asp:Label ID="_lblKayit" runat="server"></asp:Label>
                                   <%--  </form>--%>
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

