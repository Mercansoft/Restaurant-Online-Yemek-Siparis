<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box featured-box">
          <%--<h2 class="heading-title"><span>Featured Products</span></h2>--%>
          <div class="box-content">
            <ul id="myRoundabout">
                <asp:Repeater ID="_lstSlider" runat="server">
                <ItemTemplate>
              <li>
                <div class="prod_holder"> <a href="Yemek.aspx?myp=<%#Eval("YemekID") %>"> <img src="<%#Eval("Resim") %>" alt="<%#Eval("YemekAdi") %>" /> </a>
                  <h3><%#Eval("YemekAdi") %></h3>
                </div>
                <span class="pricetag"><%#String.Format("{0:C}",Eval("Fiyat")) %></span> </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
            <a href="#" class="previous_round">Previous</a> <a href="#" class="next_round">Next</a> </div>
        </div>
        <div class="inner">
<!--      <div class="breadcrumb"> <a href="index.html">Home</a> » Desktops </div>
      <div class="box">
        <h2 class="heading-title"><span>Antipasti</span></h2>
        <div class="box-content">
          <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
        </div>
      </div>-->
<!--      <div class="box">
        <h2 class="heading-title"><span>Refine Search</span></h2>
        <div class="box-content">
          <ul class="sub_cats">
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
            <li class="cat_hold"><a href="category.html"> <img src="image/not_found.jpg" alt="Spicylicious store" /> <span class="info">Long Category name goes here (0)</span> </a> </li>
          </ul>
        </div>
        <div class="clear"></div>
      </div>-->
      <!--<div class="product-filter">
        <div class="product-compare"><a href="#" id="compare_total">Product Compare (0)</a></div>
<!--        <div class="limit"><b>Show:</b>
          <select>
            <option value="" selected="selected">8</option>
            <option value="">25</option>
            <option value="">50</option>
            <option value="">75</option>
            <option value="">100</option>
          </select>
        </div>-->
<!--        <div class="sort"><b>Sort By:</b>
          <select>
            <option value="" selected="selected">Default</option>
            <option value="">Name (A - Z)</option>
            <option value="">Name (Z - A)</option>
            <option value="">Price (Low &gt; High)</option>
            <option value="">Price (High &gt; Low)</option>
            <option value="">Rating (Highest)</option>
            <option value="">Rating (Lowest)</option>
            <option value="">Model (A - Z)</option>
            <option value="">Model (Z - A)</option>
          </select>
        </div>
      </div>-->
      
      <!-- LEFT COLUMN -->
      <div id="column-left">
<%--        <div class="box">
          <h3 class="heading-title"><span>Categories</span></h3>
          <div class="box-content box-category">
            <div class="product_unit"> <br /><br /><a class="image" href="product.html"><img src="image/left_module_pic.jpg" alt="Spicylicious store" /></a> <span class="name">Spaghetti Bolognese</span> <span class="price">$19.97</span> </div>
            <div class="product_unit"> <a class="image" href="product.html"><img src="image/left_module_pic.jpg" alt="Spicylicious store" /></a> <span class="name">Spaghetti Milanese</span> <span class="price">$19.97</span> </div>
            <div class="product_unit"> <a class="image" href="product.html"><img src="image/left_module_pic.jpg" alt="Spicylicious store" /></a> <span class="name">Spaghetti Monte</span> <span class="price-old">$19.97</span> <span class="price">$17.97</span> </div>
             <div class="product_unit"> <a class="image" href="product.html"><img src="image/left_module_pic.jpg" alt="Spicylicious store" /></a> <span class="name">Spaghetti Bolognese</span> <span class="price">$19.97</span> </div>
            <div class="product_unit"> <a class="image" href="product.html"><img src="image/left_module_pic.jpg" alt="Spicylicious store" /></a> <span class="name">Spaghetti Milanese</span> <span class="price">$19.97</span> </div>
            <div class="product_unit"> <a class="image" href="product.html"><img src="image/left_module_pic.jpg" alt="Spicylicious store" /></a> <span class="name">Spaghetti Monte</span> <span class="price-old">$19.97</span> <span class="price">$17.97</span> </div>
          </div>
        </div>--%>
        <div class="box">
          <h4 class="heading-title"><span>En Popüler Yemekler</span></h4>
          <div class="box-content">
              <asp:Repeater ID="_lstPopulerYemekler" runat="server">
              <ItemTemplate>
              <div class="product_unit"> <a class="image" href="Yemek.aspx?myp=<%#Eval("YemekID") %>"><img src="<%#Eval("KucukResim") %>" height="60" width="60" alt="<%#Eval("YemekAdi") %>" /></a> <span class="name"><%#Eval("YemekAdi") %>e</span> <span class="price"><%#String.Format("{0:C}",Eval("Fiyat")) %></span> </div>
              </ItemTemplate>
              </asp:Repeater>
            <div class="clear"></div>
          </div>
        </div>
      </div>
      <!-- END OF LEFT COLUMN -->
      
      <div id="content" class="content-column-left">
      <div class="box">
        <div class="cat_list fixed">
            <asp:Repeater ID="_lstKatYemekler" runat="server">
            <ItemTemplate>
                <div class="prod_hold"> <a class="wrap_link" href="Yemek.aspx?myp=<%#Eval("YemekID") %>">
                <span class="image"><img src="<%#Eval("Resim") %>" alt="<%#Eval("YemekAdi") %>" height="180" width="180"/></span>
                </a>
                <div class="pricetag_small"> <span class="price"><%#String.Format("{0:C}",Eval("Fiyat")) %></span> </div>
                <div class="info">
                  <h3><%#Eval("YemekAdi") %></h3>
                  <a class="add_to_cart_small" href="Siparis.aspx?myp=<%#Eval("YemekID") %>">Sipariş Ver</a></div>
              </div>
            </ItemTemplate>
            </asp:Repeater>
          <div class="clear"></div>
        </div></div>
        <div class="pagination">
<cc1:CollectionPager ID="cpSayfala" runat="server" BackText="« Önceki" FirstText="İlk" LabelText="Sayfa :" LastText="Son" NextText ="Sonraki »" PageNumbersDisplay="Numbers" PageSize="9" SectionPadding="9" QueryStringKey="myp" ResultsLocation="None" ShowFirstLast="False" ShowLabel="True" ShowPageNumbers="True" BackNextLinkSeparator="">
</cc1:CollectionPager> 
        </div>
      </div>
    </div>
</asp:Content>



