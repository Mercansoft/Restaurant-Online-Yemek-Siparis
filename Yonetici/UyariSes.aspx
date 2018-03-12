<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="UyariSes.aspx.cs" Inherits="Yonetici_UyariSes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincontent">
        	<div class="contentinner">
            <h4 class="widgettitle">Uyarı Sistemi Sesleri</h4>
            <div class="widgetcontent">
            <%--<form class="stdform" id="form1" runat=server>--%>

                                   <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Uyarı Sesleri</label>
                          <div class="controls">
                              <asp:ListBox ID="_lstSes" Height="200" runat="server" OnSelectedIndexChanged="_lstSes_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                          </div>
                        </div><!--par-->
                          <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Ses Yükleyin</label>
                          <div class="controls">
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                          &nbsp; (.Wav)</div>
                        </div><!--par-->
                                                                 <div class="par control-group info">
                          <label for="inputInfo" class="control-label">Ses Adı</label>
                          <div class="controls">
                              <asp:TextBox ID="_txtSesAdi" runat="server"></asp:TextBox>
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

