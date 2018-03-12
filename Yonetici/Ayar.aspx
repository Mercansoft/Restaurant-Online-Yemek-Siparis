<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Ayar.aspx.cs" Inherits="Yonetici_Ayar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="maincontent">
        	<div class="contentinner">
                                <h4 class="widgettitle nomargin shadowed">Genel Ayarlar</h4>
                <div class="widgetcontent bordered">
<%--            <h4 class="widgettitle">Genel Ayarlar</h4>
            <div class="widgetcontent">--%>
            <%--<form class="stdform" id="form1" runat=server>--%>
                    
                                                  <div class="par control-group info">
                         
                          <div class="controls">
                              <asp:Image ID="Image1" runat="server" />
                          </div>
                        </div><!--par-->

                              <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Logo</label>
                          <div class="controls">
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                          </div>
                        </div><!--par-->
                  <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Title</label>
                          <div class="controls">
                              <asp:TextBox ID="_txtTitle" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->

                         <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Footer</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtFooter" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Açıklama</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtAciklama" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Anahtar Kelimeler</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtAnahtarKelime" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Adresiniz</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtAdres" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Sabit Telefon</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtSabitTelefon" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
                                   <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Fax</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtFax" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Cep Telefon</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtCepTelefon" CssClass="span4" runat="server"></asp:TextBox>
                          </div>
                        </div><!--par-->
<%--                                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Eklentiler Görünsün</label>
                          <div class="controls">
                            <asp:CheckBox ID="_chkEklenti" runat="server" />
                          </div>
                        </div>--%>
                        <div class="par control-group info">
                          <label for="inputInfo" class="control-label"></label>
                          <div class="controls">
                                                           <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" 
                                    Text="Kaydet" onclick="Button1_Click" />
                          </div>
                        </div><!--par-->
                                                <div class="par control-group info">
                          <label for="inputInfo" class="control-label"></label>
                          <div class="controls">
                              <asp:Label ID="_lblDurumu" runat="server" Font-Bold="True" ForeColor="#009900"></asp:Label>
                          </div>
                        </div><!--par-->
            <%--</form>--%>
            </div>

            </div></div>
</asp:Content>

