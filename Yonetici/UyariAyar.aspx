<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="UyariAyar.aspx.cs" Inherits="Yonetici_UyariAyar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="maincontent">
        	<div class="contentinner">
            <h4 class="widgettitle">Uayrı Sistemi Ayarları</h4>
            <div class="widgetcontent">
            <%--<form class="stdform" id="form1" runat=server>--%>

                                   <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Uyarı Sesleri</label>
                          <div class="controls">
                              <asp:ListBox ID="_lstSes" Height="200" runat="server" OnSelectedIndexChanged="_lstSes_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                              <asp:Button ID="Button2" runat="server" Text="Sil" OnClick="Button2_Click" />
                          </div>
                        </div><!--par-->
                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Uyarı Kontrol Sıklığı</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtSure" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp; ( Örn: 5 ) dakika</div>
                        </div><!--par-->
                                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Uyarı Sistemi Aç/Kapa</label>
                          <div class="controls">
                            <asp:CheckBox ID="_chkUyari" runat="server" />
                          </div>
                        </div><!--par-->
                        <div class="par control-group info">
                          <label for="inputInfo" class="control-label"></label>
                          <div class="controls">
                                                           <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" 
                                    Text="Kaydet" OnClick="Button1_Click" />
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

