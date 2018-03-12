<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Odeme.aspx.cs" Inherits="Odeme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="_lblSiparisTamamlandi" runat="server" Font-Bold="True" Font-Size="Large" 
        ForeColor="#00CC00"></asp:Label>
    <!-- CONTENT -->
  <div id="content_holder" class="fixed">
    <div class="inner">
<%--      <div class="breadcrumb"> <a href="index.html">Home</a> » <a href="cart.html">Cart</a> » Checkout </div>
      <h2 class="heading-title"><span>Sipariş </span></h2>--%>
      <div id="content"> 
        
        <!-- ACCORDION -->
        <div id="accordion" class="checkout">
          <h2><a href="#">Sipariş Bilgileriniz</a></h2>
          <div>
          <%--<form id="form1" runat=server>--%>
            <table class="form">
              <tbody>
                <tr>
                  <td><span class="required">*</span> Adınız Soyadınız:</td>
                  <td>
                      <asp:TextBox ID="_txtAdSoyad" CssClass="large-field" runat="server" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtAdSoyad" ErrorMessage="Lütfen Adınız Soyadınızı Boş Geçmeyiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                  <td><span class="required">*</span>Telefon Numaranız:</td>
                  <td><asp:TextBox ID="_txtTelefon" CssClass="large-field" runat="server" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_txtTelefon" ErrorMessage="Lütfen Telefon Numaranızı Yazınız" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                  <td><span class="required">*</span> Teslimat Adresi:</td>
                  <td><asp:TextBox ID="_txtAdres" CssClass="large-field" runat="server" Height="100px" 
                          TextMode="MultiLine" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_txtAdres" ErrorMessage="Lütfen Adresinizi Giriniz" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                <td><span class="required">*</span> Ödeme Türünüz:</td>
                <td>
                    <asp:ListBox ID="_lstOdeme" runat="server" Width="189px" Height="40px"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_lstOdeme" ErrorMessage="Lütfen Ödeme Türünüzü Seçiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                </tr>
                <tr>
                  <td><span class="required">*</span> Açıklama:</td>
                  <td>
                      <asp:TextBox ID="_txtAciklama" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_txtAciklama" ErrorMessage="Lütfen Adresinizi Boş Geçmeyiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                  <tr>
                      <td></td><td> <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                      </td>
                  </tr>
              </tbody>
            </table>
          </div>             
          <h2><a href="#">Yemek Sepetiniz</a></h2>
          <div class="checkout-product">
            <table>
              <thead>
                <tr>
                  <td class="name">Siparişin Adı</td>
                  <td class="quantity">Miktar</td>
                  <td class="quantity">Miktar</td>
                  <td class="price">Fiyat</td>
                  <td class="total">Toplam</td>
                </tr>
              </thead>
              <tbody>
                  <asp:Repeater ID="_lstSepet" runat="server">
                  <ItemTemplate>
                 <tr>
                  <td class="name"><a href="Yemek.aspx?myp=<%#Eval("id") %>"><%#Eval("isim")%></a></td>
                  <td class="quantity"><%#Eval("adet") %></td>
                  <td class="quantity">Miktar</td>
                  <td class="price"><%#Eval("fiyat") %> TL</td>
                  <td class="total"><%#Eval("tutar")%> TL</td>
                </tr>
                  </ItemTemplate>
                  </asp:Repeater>

              </tbody>
              <tfoot>
                <tr>
                  <td class="price" colspan="4"><b>Toplam:</b></td>
                  <td class="total">
                      <asp:Label ID="_lblToplam" runat="server" Text=""></asp:Label></td>
                </tr>
              </tfoot>
            </table>
               <h2><a href="#">Ekstra Eklenti Sepetiniz</a></h2>
              <table>
              <thead>
                <tr>
                  <td class="name">Siparişin Adı</td>
                  <td class="quantity">Miktar</td>
                  <td class="quantity">Miktar</td>
                  <td class="price">Fiyat</td>
                  <td class="total">Toplam</td>
                </tr>
              </thead>
              <tbody>
                  <asp:Repeater ID="_lstEklenti" runat="server">
                  <ItemTemplate>
                 <tr>
                  <td class="name"><%#Eval("isim")%></td>
                  <td class="quantity"><%#Eval("adet") %></td>
                  <td class="quantity">Miktar</td>
                  <td class="price"><%#Eval("fiyat") %> TL</td>
                  <td class="total"><%#Eval("tutar")%> TL</td>
                </tr>
                  </ItemTemplate>
                  </asp:Repeater>

              </tbody>
              <tfoot>
                <tr>
                  <td class="price" colspan="4"><b>Toplam:</b></td>
                  <td class="total">
                      <asp:Label ID="_lblEklentiToplam" runat="server" Text=""></asp:Label></td>
                </tr>
                  <tr>
                  <td class="price" colspan="4"><b>Genel Toplam:</b></td>
                  <td class="total">
                      <asp:Label ID="_lblGenelToplam" runat="server" Text=""></asp:Label></td>
                </tr>
              </tfoot>
            </table>


            <div class="buttons">
              <div class="right">
                  <asp:Button ID="Button1" runat="server" Text="Siparişi Gönder" 
                      onclick="Button1_Click" /></div>
                      <%--</form>--%>
            </div>
          </div>
                  
        </div>
        <!-- END OF ACCORDION --> 

      </div>
    </div>
  </div>
  <!-- END OF CONTENT --> 
</asp:Content>

