<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sayfa.aspx.cs" Inherits="Sayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_holder" class="fixed">
    <div class="inner">
      <h2 class="heading-title"><span><asp:Label ID="_lblTitle" runat="server"></asp:Label></span></h2>
      
      <!-- LEFT COLUMN -->
      <div id="column-left">
        <div class="box">
          <h3 class="heading-title"><span>Restorantımız</span></h3>
          <div class="box-content box-category">
            <ul>
                <asp:Repeater ID="_lstSayfalar" runat="server">
                <ItemTemplate>
                <li><a href="Sayfa.aspx?myp=<%#Eval("SayfaID") %>"><%#Eval("SayfaAdi") %></a></li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
        </div>
        
      </div>
      <!-- END OF LEFT COLUMN -->
      
      <div id="content" class="content-column-left">
        <div class="content info-page">
          <p>
                                <asp:Image ID="_imgIcerikResim" Width="700" Height="400" runat="server" />

              <asp:Literal ID="_lblIcerik" runat="server"></asp:Literal></p>         
          <div class="clear"></div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>

