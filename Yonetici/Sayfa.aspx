<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Sayfa.aspx.cs" Inherits="Yonetici_Sayfa" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="maincontent">
        	<div class="contentinner">

                <h4 class="widgettitle nomargin shadowed">Sayfa Ekle</h4>
                <div class="widgetcontent bordered">
                    <%--<form id="form1" class="stdform stdform2" runat="server">--%>
                            <p>
                                <label>Sayfa Adı</label>
                                <span class="field">
                                    <asp:TextBox ID="_txtSayfaAdi" CssClass="input-xxlarge" runat="server"></asp:TextBox>
                                </span>
                            </p>
                            
                            <p>
                                <label>Sayfa Resimi</label>
                                <span class="field">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </span>
                            </p>
                            
                            <p>
                                <label>Sayfa İçeriği</label>
                                <span class="field"><CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl></span>
                            </p>
                                                    
                            <p class="stdformbutton">
                                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" 
                                    Text="Kaydet" onclick="Button1_Click" /> 
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </p>
                        <%--</form>--%>
                    </div><!--widgetcontent-->



                                    <asp:Panel ID="_pnlSayfaListesi" runat="server">
            	<h4 class="widgettitle">Sayfa Listesi</h4>
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
                            <th class="head0">Sayfa Adı</th>
                            <th class="head1">Resim</th>
                            <th class="head1">Admin</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstYoneticilerListesi" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                           <%#Eval("SayfaID") %>
                          </span></td>
                            <td><%#Eval("SayfaAdi") %></td>
                            <td><img src='../<%#Eval("Resim") %>' height="50" width="50" /></td>
                            <td class="center"><a href="Sayfa.aspx?Sil=<%#Eval("SayfaID") %>" class="btn"><span class="icon-edit"></span> Sil</a></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>                
    </asp:Panel>

        	</div></div>
</asp:Content>

