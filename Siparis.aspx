<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Siparis.aspx.cs" Inherits="Siparis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content_holder" class="fixed">
    <div class="inner">
      <div class="breadcrumb"> <a href="index.html">Home</a> » <a href="account.html">Account</a> » Shopping Cart</div>
      <h2 class="heading-title"><span>Yemek Siparişleriniz</span></h2>
      <div id="content">
        <div class="cart-info">
          <table>
            <thead>
              <tr>
                <td class="remove">Sil</td>
                <td class="image">Resim</td>
                <td class="name">Siparişinizin Adı</td>
                <td class="quantity">Miktar</td>
                <td class="price">Fiyat</td>
                <td class="total">Toplam</td>
              </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="_lstSepet" runat="server" 
                    onitemdatabound="_lstSepet_ItemDataBound">
                <ItemTemplate>
                <tr>
                <td class="remove"><a href="Siparis.aspx?SiparisSil=<%# Eval("id") %>"><img src="image/sil.png" /></a></td>
                <td class="image"><a href="Yemek.aspx?myp=<%# Eval("id") %>"><img src="<%# Eval("resim") %>" height="50" width="50" alt="<%# Eval("isim") %>" /></a></td>
                <td class="name"><a href="Yemek.aspx?myp=<%# Eval("id") %>"><%# Eval("isim") %></a>
                  <div> </div></td>
                <%--<td class="quantity"><h2><%# Eval("adet") %></h2></td>--%>
                <td class="quantity"><h2>
                    <asp:TextBox ID="Text1" name="adet1" runat="server" Text='<%# Eval("adet") %>'></asp:TextBox>
                    <%--<input name="adet1" id="Text1" type="text" value="<%# Eval("adet") %>" />--%>
                    <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%></h2>
                   <%-- <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='Siparis.aspx?Guncelle=<%# Eval("id") %>'>Güncelle</asp:HyperLink>--%>
                    <%--<a href="Siparis.aspx?Guncelle=<%# Eval("id") %>">Güncelle</a>--%>
                    <%--<asp:HyperLink ID="HyperLink1" CommandName=<%# Eval("id") %> runat="server">Güncelle</asp:HyperLink>--%>
                    </td>
                <td class="price"><h3><%# Eval("fiyat") %> TL</h3></td>
                <td class="total"><h3><%# Eval("tutar") %> TL</h3></td>
              </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
        </div>
          <asp:Panel ID="_pnlEklentiSiparisleri" runat="server">
        <h2 class="heading-title"><span>Ekstra Eklenti Siparişleriniz</span></h2>
              <div class="cart-info">
                      <table>
            <thead>
              <tr>
                <td class="remove">Sil</td>
                <td class="image">Resim</td>
                <td class="name">Eklenti Adı</td>
                <td class="quantity">Miktar</td>
                <td class="price">Fiyat</td>
                <td class="total">Toplam</td>
              </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="_lstEklenti" runat="server">
                <ItemTemplate>
                <tr>
                <td class="remove"><a href="Siparis.aspx?EklentiSiparisSil=<%# Eval("id") %>"><img src="image/sil.png" /></a></td>
                <td class="image"><a href="Yemek.aspx?myp=<%# Eval("id") %>"><img src="<%# Eval("resim") %>" height="50" width="50" alt="<%# Eval("isim") %>" /></a></td>
                <td class="name"><a href="Yemek.aspx?myp=<%# Eval("id") %>"><%# Eval("isim") %></a>
                  <div> </div></td>
                <%--<td class="quantity"><h2><%# Eval("adet") %></h2></td>--%>
                <td class="quantity"><h2>
                    <asp:TextBox ID="Text1" name="adet1" runat="server" Text='<%# Eval("adet") %>'></asp:TextBox>
                    <%--<input name="adet1" id="Text1" type="text" value="<%# Eval("adet") %>" />--%>
                    <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%></h2>
                   <%-- <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='Siparis.aspx?Guncelle=<%# Eval("id") %>'>Güncelle</asp:HyperLink>--%>
                    <%--<a href="Siparis.aspx?Guncelle=<%# Eval("id") %>">Güncelle</a>--%>
                    <%--<asp:HyperLink ID="HyperLink1" CommandName=<%# Eval("id") %> runat="server">Güncelle</asp:HyperLink>--%>
                    </td>
                <td class="price"><h3><%# Eval("fiyat") %> TL</h3></td>
                <td class="total"><h3><%# Eval("tutar") %> TL</h3></td>
              </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
            </div>
        </asp:Panel>
        <div class="cart-total">
          <table>
            <tbody>
<%--              <tr>
                <td colspan="5"></td>
                <td class="right"><b>Ara Toplam</b></td>
                <td class="right numbers">$701.00</td>
              </tr>--%>
              <tr>
                <td colspan="5"></td>
<%--                <td class="right"><b>KDV%:</b></td>
                <td class="right numbers">$122.68</td>--%>
              </tr>
              <tr>
                <td colspan="5"></td>
                <td class="right numbers_total"><b>Toplam:</b></td>
                <td class="right numbers_total">
                    <asp:Label ID="lblToplam" runat="server" Text=""></asp:Label></td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="buttons">
          <div class="left"><a class="button" href="Siparis.aspx?Sepet=null"><span>Sepeti Boşalt</span></a></div>
          <div class="right"><a class="button" href="Odeme.aspx"><span>Siparişi Tamamla</span></a></div>
          <div class="center"><a class="button" href="Anasayfa.aspx"><span>Alışverişe Devam</span></a></div>

        </div>
      </div>
    </div>
  </div>
</asp:Content>

