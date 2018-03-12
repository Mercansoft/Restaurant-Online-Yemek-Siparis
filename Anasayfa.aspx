<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Anasayfa.aspx.cs" Inherits="Anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BIG SLIDESHOW -->
  <div id="slideshow_big">
    <div class="inner"> 
      <!-- Slider Start -->
      <div id="big_slider" class="li-banner">
        <ul>
            <asp:Repeater ID="_lstManset" runat="server">
            <ItemTemplate>
            <li>
                <asp:Image ID="Image1" ImageUrl=<%#Eval("Resim") %> runat="server" /></li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
      </div>
      <!-- Slider End --> 
    </div>
  </div>
  <!-- END OF BIG SLIDESHOW --> 
        <div class="box">
          <h2 class="heading-title"><span>Yemek Çeşitlerimiz</span></h2>
          <div class="box-content">
            <div class="box-product fixed">
                <asp:Repeater ID="_lstYemekler" runat="server">
                <ItemTemplate>
                <div class="prod_hold"> <a class="wrap_link" href="Yemek.aspx?myp=<%#Eval("YemekID") %>">
                <span class="image"><img src="<%#Eval("KucukResim") %>" alt="<%#Eval("YemekAdi") %>" height="180" width="180" /></span>
                </a>
                <div class="pricetag_small"> <span class="price"><%#String.Format("{0:C}",Eval("Fiyat")) %></span> </div>
                <%--<div class="pricetag_small"><span class="new_price"><%#Eval("Fiyat") %></span> </div>--%>
                <div class="info"><br /><br />
                  <h3><%#Eval("YemekAdi") %></h3>
                 </div>  
                </div>
                </ItemTemplate>
                </asp:Repeater>

<%--              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic2.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 147,99</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>
              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic3.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 472,99</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>
              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic4.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 219,99</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>
              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic5.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 101,99</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>
              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic6.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 56,67</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>
              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic7.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 21,50</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>
              <div class="prod_hold"> <a class="wrap_link" href="product.html">
                <span class="image"><img src="image/prod_pic8.jpg" alt="Spicylicious store" /></span>
                </a>
                <div class="pricetag_small"> <span class="price">$ 176,99</span> </div>
                <div class="info">
                  <h3>Very long product name goes here</h3>
                  <p>Suspendisse eget nunc lorem. Sed convallis mattis est, quis dignissim magna varius et.</p>
                  <a class="add_to_cart_small" href="#">Add to cart</a> <a class="wishlist_small" href="#">Wishlist</a> <a class="compare_small" href="#">Compare</a> </div>
              </div>--%>
            </div>
            <div class="clear"></div>
          </div>
        </div>
</asp:Content>

