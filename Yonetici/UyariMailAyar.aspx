<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="UyariMailAyar.aspx.cs" Inherits="Yonetici_UyariMailAyar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincontent">
        	<div class="contentinner">
            <h4 class="widgettitle">Uyarı Mail Sistemi Ayarları</h4>
            <div class="widgetcontent">
            <%--<form class="stdform" id="form1" runat=server>--%>
                
                           <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Alıcı Mail Adresi</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtAliciMail" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp; ( Örn: alici@mail.com )</div>
                        </div><!--par-->
                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Gönderen Mail Adresi</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtGonderenMail" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp; ( Örn: gonderen@mail.com )</div>
                        </div><!--par-->
                                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Gönderen Mail Şifre</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtSifre" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp; </div>
                        </div><!--par-->
                                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Smtp Sunucu Adres</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtSmtpMail" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp; ( Örn: smtp.domainadicom  yada mail.domainadi.com)</div>
                        </div><!--par-->
                                                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Smtp Port No</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtPortNo" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp; ( Örn: 587 Standart 587'dir)</div>
                        </div><!--par-->
                                                                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Giden Uyarı Mail Konusu</label>
                          <div class="controls">
                            <asp:TextBox ID="_txtMailKonusu" CssClass="span4" runat="server"></asp:TextBox>
                          &nbsp;</div>
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

