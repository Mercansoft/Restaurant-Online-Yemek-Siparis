<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Yemek.aspx.cs" Inherits="Yemek" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content_holder" class="fixed">
        <div class="inner">
            <h2 class="heading-title"><span>
                <asp:Label ID="_lblYemekAdi" runat="server" Text=""></asp:Label></span></h2>

            <!-- PRODUCT INFO -->

            <div class="product-info fixed">
                <div class="left">
                    <div class="image">
             <%--           <asp:HyperLink ID="zoom1" CssClass="cloud-zoom" rel="adjustX: 5, adjustY:0, zoomWidth:550, zoomHeight:400, showTitle: false" runat="server">--%>
                            <a class="cloud-zoom" id="zoom1" runat="server" rel="adjustX: 5, adjustY:0, zoomWidth:550, zoomHeight:400, showTitle: false">
                                <asp:Image ID="_imgYemek" Width="400" Height="400" alt='' runat="server" /></a>
                        <%--</asp:HyperLink>--%>
                        <span class="pricetag">
                            <asp:Label ID="_lblFiyat" runat="server"></asp:Label></span>
                    </div>
                </div>

                <div class="right">
                    <div class="description">
                        <span>Yemek Adı:</span>
                        <asp:HyperLink ID="HyperLink1" runat="server">
                            <asp:Label ID="_lblYemekAdi2" runat="server"></asp:Label>
                        </asp:HyperLink>
                        <br />
                        <span>Yemek Türü:</span>
                        <asp:Label ID="_lblYemekTuru" runat="server"></asp:Label><br />

                        <!-- AddThis Button BEGIN -->
                        <div class="addthis_toolbox addthis_default_style ">
                        </div>
                        <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4e7280075406aa87"></script>
                        <!-- AddThis Button END -->

                        <div class="reviews">
                            <img alt="3 reviews" src="image/stars-5.png" />
                            <p>En Çok Sipariş Verilen Yemek</p>
                        </div>
                    </div>
                    <asp:Panel ID="_pnlEklenti" runat="server">
                    <div class="options">
                        <div class="option" id="option-217">
                            <b><span class="required">*</span> Yemek Eklentileri:</b>
                            <asp:DropDownList ID="_drpEklenti" Width="200" Height="30" runat="server" Font-Bold="True"></asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="18px" ImageUrl="~/image/right-arrow.gif" Width="26px" OnClick="ImageButton2_Click"/>
                        </div> 
                        <div class="option" id="option-223">
                            <b>Seçilen Eklentileriniz:</b>
                            <asp:Repeater ID="_lstEklentiler" runat="server">
                                <ItemTemplate>
                                    <a href="Yemek.aspx?EklentiSil=<%#Eval("id") %>"><img src="image/sil.png" /></a> <%#Eval("isim") %> - (<%#Eval("adet") %>) -  <%#Eval("tutar") %> <img src="image/TL_simge.jpg" /><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                                            </asp:Panel>
                    <div class="cart">
                        <%--<span class="label">Miktar: &nbsp;&nbsp;</span>--%>
                        <asp:TextBox ID="_txtAdet" Width="40" Height="35" runat="server" Font-Bold="True" Font-Size="X-Large" Text="1"></asp:TextBox>
                    </div>

                    <%--          <form id="form1" runat="server">  <asp:Button ID="_btnSiparis" runat="server" Text="Sipariş ver" onclick="_btnSiparis_Click"/></form>--%>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/image/siparisver.png" AlternateText="SİPARİŞ" Width="100px" OnClick="ImageButton1_Click" />
<%--                    <asp:HyperLink ID="_hypSiparisVer" CssClass="button" runat="server"><span>Sipariş Ver</span></asp:HyperLink>--%>
                    <%--<a href="Siparis.aspx?myp=<%#Eval("YemekID") %>" class="button" id="button-cart" title="Sipariş Ver"><span>Sipariş Ver</span></a>--%>
                    <%--<input type="text" value="1" size="2" name="quantity" id="qty"/>--%>
                    <%--<a href="#" class="wish_button" title="Add to Wish List">Add to Wish List</a> <a href="#" class="compare_button" title="Add to Compare">Add to Compare</a>--%>
                </div>
                <div class="clear"></div>
            </div>
            <!-- END OF PRODUCT INFO -->

            <div id="content">
                <div class="box">
                    <h2 class="heading-title"><span>Yemek Hakkında Bilgi</span></h2>
                    <div class="box-content">
                        <p>
                            <asp:Literal ID="_lblAciklama" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>

                <div class="cat_list">
                    <h2 class="heading-title"><span>Önerilen Yemekler</span></h2>
                    <asp:Repeater ID="_lstOnerilenYemekler" runat="server">
                        <ItemTemplate>
                            <div class="prod_hold">
                                <a class="wrap_link" href="Yemek.aspx?myp=<%#Eval("YemekID") %>">
                                    <span class="image">
                                        <img src="<%#Eval("KucukResim") %>" alt="<%#Eval("YemekAdi") %>e" height="180" width="180" /></span>
                                </a>
                                <div class="pricetag_small"><span class="new_price"><%#String.Format("{0:C}",Eval("Fiyat")) %></span> </div>
                <div class="info"><br /><br />
                  <h3><%#Eval("YemekAdi") %></h3>
                 </div> 
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;
                </div>
            </div>
        </div>
    </div>
    </a>
</asp:Content>

