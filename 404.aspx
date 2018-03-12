<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- CONTENT -->
  <div id="content_holder">
    <div class="inner">
      <div class="breadcrumb"> <a href="index.html">Home</a> » 404 - page not found</div>
      <h2 class="heading-title"><span>Aradığnız Sayfa Bulunamıyor..!</span></h2>
      
      <div id="content">
        <div class="content not-found">
          <h1 class="oops">HATA!</h1>
          <p>Ulaşmak istediğiniz sayfa yayından kaldırılmış olabilir. Lütfen daha sonra tekrar deneyiniz <a href="Default.aspx">Anasayfa</a>ya geri dönün</p>
<%--          <div class="search">
          <input type="text" onkeydown="this.style.color = '#000000';" onclick="this.value = '';" value="Search" name="filter_name"/>
          <a href="#" class="button-search"></a> </div>--%>
        </div>
      </div>
      <div class="clear"></div>
    </div>
  </div>
  <!-- END OF CONTENT --> 
</asp:Content>

