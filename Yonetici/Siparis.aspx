<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Siparis.aspx.cs" Inherits="Yonetici_Siparis" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="maincontent">
        	<div class="contentinner">
                <asp:Panel ID="_pnlGoruntule" runat="server">

                           <div class="row-fluid">
                
                <div class="span6">
                
                 <%-- <div class="invoice_logo"><img src="../image/MY.png" alt="" class="img-polaroid" /></div>--%>
                     <div class="invoice_logo">
                         <asp:Image ID="Image1" CssClass="img-polaroid" runat="server" /></div>
                  
                  <table class="table table-bordered table-invoice">
                      <tr>
                          <td class="width30">Sipariş Veren :</td>
                          <td class="width70"><strong>
                              <asp:Label ID="_lblAdSoyad" runat="server" Text=""></asp:Label></strong></td>
                      </tr>
                      <tr>
                        <td>Ödeme Türü :</td>
                        <td><asp:Label ID="_lblOdemeTuru" runat="server" Text=""></asp:Label></td>
                    </tr>
                        <tr>
                          <td>Telefon Numarası :</td>
                          <td><asp:Label ID="_lblTelefon" runat="server" Text=""></asp:Label></td>
                      </tr>
                  </table>
                </div><!--span6-->
            
				<div class="span6">
                <table class="table table-bordered table-invoice">
                      <tr>
                          <td class="width30">Adres:</td>
                          <td class="width70">
                            <asp:Label ID="_lblAdres" runat="server" Text=""></asp:Label>
                          </td>
                      </tr>
                  </table>
               	  <br /><br />
                  <table class="table table-bordered table-invoice">
                      <tr>
                          <td class="width30">Sipariş Tarihi :</td>
                          <td class="width70"><strong><asp:Label ID="_lblSiparisTarih" runat="server" Text=""></asp:Label></strong></td>
                      </tr>
                      <tr>
                        <td>IP Adres :</td>
                        <td><strong><asp:Label ID="_lblIPAdres" runat="server" Text=""></asp:Label></strong></td>
                    </tr>
                        <tr>
                          <td>- :</td>
                          <td><strong>-</strong></td>
                      </tr>
                  </table>
                </div><!--span6-->
                
            </div>    

            <div class="clearfix"><br /></div>

            <table class="table table-bordered table-invoice-full">
                    <colgroup>
                        <col class="con0 width15" />
                        <col class="con1 width45" />
                        <col class="con0 width5" />
                        <col class="con1 width15" />
                        <col class="con0 width20" />
                    </colgroup>
                    <thead>
                        <tr>
<%--                            <th class="head0"># ID</th>--%>
                            <th class="head0">Sipariş Tarihi</th>
                            <th class="head1">Yemek Adı</th>
                            <th class="head0">Miktar</th>
                            <th class="head1">Tutar</th>
                            <th class="head1">Toplam</th>
                            <%--<th class="head0 right"></th>--%>
                            <%--<th class="head0 right">Toplam</th>--%>
                        </tr>
                    </thead>
                <tbody>
                    <asp:Repeater ID="_lstKisiSiparisler" runat="server" OnItemDataBound="_lstKisiSiparisler_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                           <%-- <td><%#Eval("SiparisID") %></td>--%>
                            <td><%#Eval("SiparisTarihi")%></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="right"><%#Eval("Miktar")%></td>
                            <td class="right"><%#String.Format("{0:C}",Eval("Fiyat"))%></td>
                            <td class="right"><%#String.Format("{0:C}",Eval("Toplam")) %></td>
                           <%-- <td class="right"><strong><asp:Label ID="_lblToplam" runat="server" Text="Label"></asp:Label></strong></td>--%>
<%--                            <td></td>--%>
                        </tr>
                         </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>

                    <table class="table table-bordered table-invoice-full">
                    <colgroup>
                        <col class="con0 width15" />
                        <col class="con1 width45" />
                        <col class="con0 width5" />
                        <col class="con1 width15" />
                        <col class="con0 width20" />
                    </colgroup>
                    <thead>
                        <tr>
<%--                            <th class="head0"># ID</th>--%>
                            <th class="head0">Sipariş Tarihi</th>
                            <th class="head1">Eklenti Adı</th>
                            <th class="head0">Miktar</th>
                            <th class="head1">Tutar</th>
                            <th class="head1">Toplam</th>
                            <%--<th class="head0 right"></th>--%>
                            <%--<th class="head0 right">Toplam</th>--%>
                        </tr>
                    </thead>
                <tbody>
                    <asp:Repeater ID="_lstEklenti" runat="server" >
                    <ItemTemplate>
                        <tr>
                           <%-- <td><%#Eval("SiparisID") %></td>--%>
                            <td><%#Eval("Tarih")%></td>
                            <td><%#Eval("EklentiAdi") %></td>
                            <td class="right"><%#Eval("Adet")%></td>
                            <td class="right"><%#String.Format("{0:C}",Eval("Fiyat"))%></td>
                            <td class="right"><%#String.Format("{0:C}",Eval("Toplam")) %></td>
                           <%-- <td class="right"><strong><asp:Label ID="_lblToplam" runat="server" Text="Label"></asp:Label></strong></td>--%>
<%--                            <td></td>--%>
                        </tr>
                         </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>

                <table class="table invoice-table">
                	<colgroup>
                    	<col class="con0 width60" />
                        <col class="con0 width20" />
                        <col class="con1 width20" />
               		</colgroup>
                    <tbody>
                        <tr>
                        	<td class="msg-invoice">
          						<h4>Açıklama:</h4>
          						<p>
                                      <asp:Label ID="_lblAciklama" runat="server"></asp:Label></p>
                            </td>
<%--                            <td class="right">
                            	<strong>Subtotal</strong> <br />
                                <strong>Tax (5%)</strong> <br />
                                <strong>Discount</strong>
                            </td>
                            <td class="right"><strong>$6,000 <br />$600 <br />$50</strong></td>--%>
                        </tr>
                    </tbody>
          </table>

                    <div class="amountdue">
          	<h1><span>Genel Toplam</span> <asp:Label ID="_lblGenelToplam" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label></h1> <br />
                                   <p class="stdformbutton">
                                       <%--<asp:HyperLink ID="HyperLink1" runat="server"><span class="btn btn-primary">Siparişi Onayla</span></asp:HyperLink>--%>
                                       <asp:Panel ID="_pnlOnaylaButonu" runat="server">
                         <asp:HyperLink ID="HyperLink1" runat="server"><span class="btn btn-primary">Siparişi Onayla</span></asp:HyperLink>
                        <%--<a href="Siparis.aspx?Onay=<%#Eval("SiparisAppID")%>"></a>--%>
                                       </asp:Panel>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                                       <p>
                                       </p>
                        </p>
          </div>




               <%-- <h4 class="widgettitle">Sipariş Görüntüleme</h4>
                <asp:DataList ID="_lstSiparisGorunrule" runat="server">
                    <ItemTemplate>
                    <div class="widgetcontent">
                    <b>Yemek Adı :</b> <b><font size="2" color="red"><%#Eval("YemekAdi") %></font></b><br /><br />
                   <b> Yemek Miktarı :</b> <b><font size="2" color="red"> <%#Eval("Miktar") %></font></b><br /><br />
                    <b>Ödeme Türü :</b> <b><font size="2" color="red"> <%#Eval("OdemeAdi") %></font></b><br /><br />
                    <b>Sipariş Tutarı : </b> <b><font size="2" color="red"><%#String.Format("{0:C}",Eval("Toplam")) %></font></b><br /><br />
                    <b>Sipariş Veren :</b> <b><font size="2" color="red"> <%#Eval("AdSoyad")%></font></b><br /><br />
                    <b>Sipariş Veren Telefon :</b> <b><font size="2" color="red"> <%#Eval("Telefon")%></font></b><br /><br />
                    <b>Sipariş Verdiği Tarih : </b> <b><font size="2" color="red"><%#Eval("SiparisTarihi")%></font></b><br /><br />
                    <b>Gönderilecek Adres : </b> <b><font size="2" color="red"> <%#Eval("Adres")%></font></b><br /><br />
                    <b>Açıklama : </b> <b><font size="2" color="red"> <%#Eval("Aciklama")%></font></b><br /><br />
                                                               
                        <p class="stdformbutton">
                        <a href="Siparis.aspx?Onay=<%#Eval("SiparisID")%>"><span class="btn btn-primary">Siparişi Onayla</span></a>
                        </p>
                </div>

                    </ItemTemplate>
                    </asp:DataList>--%>
                </asp:Panel>
                <asp:Panel ID="_pnlYeni" runat="server">

            	<h4 class="widgettitle">Yeni Gelen Siparişler</h4>
            	<table class="table table-bordered" id="dyntable">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                          	<th class="head0 nosort">#ID</th>
                            <th class="head0">Yemek Adı</th>
                            <th class="head0">Miktar/Adet</th>
                            <th class="head1">Sipariş Veren</th>
                            <th class="head0">Telefon</th>
                            <th class="head1">Sipariş Tarihi</th>
                            <th class="head1">Ödeme Türü</th>
                            <th class="head0">Toplam Tutar</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstSiparisler" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("SiparisID") %>
                          </span></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="center"><%#Eval("Miktar") %></td>
                            <td><%#Eval("AdSoyad") %></td>
                            <td><%#Eval("Telefon") %></td>
                            <td class="center"><%#Eval("SiparisTarihi") %></td>
                            <td class="center"><%#Eval("OdemeAdi")%></td>
                            <td class="center"><%#String.Format("{0:C}",Eval("Toplam")) %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="Siparis.aspx?Goruntule=<%#Eval("SiparisAppID") %>"><i class="iconsweets-pdf"></i> &nbsp;Görüntüle</a></li>
                                              <li><a href="Siparis.aspx?Onay=<%#Eval("SiparisAppID") %>"><i class="iconsweets-like"></i> &nbsp;Onayla</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Siparis.aspx?Sil=<%#Eval("SiparisAppID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                            </ul>
                                        </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                
                <div class="divider15"></div>
                                </asp:Panel>
                <asp:Panel ID="_pnlGonderilecek" runat="server">

            	<h4 class="widgettitle">Gönderilecek Siparişler</h4>
            	<table class="table table-bordered" id="Table2">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                          	<th class="head0 nosort">#ID</th>
                            <th class="head0">Yemek Adı</th>
                            <th class="head0">Miktar/Adet</th>
                            <th class="head1">Sipariş Veren</th>
                            <th class="head0">Telefon</th>
                            <th class="head1">Sipariş Tarihi</th>
                            <th class="head1">Ödeme Türü</th>
                            <th class="head0">Toplam Tutar</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstGonderilecek" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("SiparisID") %>
                          </span></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="center"><%#Eval("Miktar") %></td>
                            <td><%#Eval("AdSoyad") %></td>
                            <td><%#Eval("Telefon") %></td>
                            <td class="center"><%#Eval("SiparisTarihi") %></td>
                            <td class="center"><%#Eval("OdemeAdi")%></td>
                            <td class="center"><%#String.Format("{0:C}",Eval("Toplam")) %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="Siparis.aspx?Goruntule=<%#Eval("SiparisAppID") %>"><i class="iconsweets-pdf"></i> &nbsp;Görüntüle</a></li>
                                              <li><a href="Siparis.aspx?Gonderildi=<%#Eval("SiparisAppID") %>"><i class="iconsweets-like"></i> &nbsp;Gönderildi</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Siparis.aspx?Sil=<%#Eval("SiparisAppID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                            </ul>
                                        </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                
                <div class="divider15"></div>
                                </asp:Panel>
                <asp:Panel ID="_pnlGonderilen" runat="server">
                
            	<h4 class="widgettitle">Gönderilen Siparişler - <asp:Button ID="Button1" runat="server" Text="Siparişleri Temizle" OnClick="Button1_Click" /></h4> 
            	<table class="table table-bordered" id="Table3">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                          	<th class="head0 nosort">#ID</th>
                            <th class="head0">Yemek Adı</th>
                            <th class="head0">Miktar/Adet</th>
                            <th class="head1">Sipariş Veren</th>
                            <th class="head0">Telefon</th>
                            <th class="head1">Sipariş Tarihi</th>
                            <th class="head1">Ödeme Türü</th>
                            <th class="head0">Toplam Tutar</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstGonderilen" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("SiparisID") %>
                          </span></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="center"><%#Eval("Miktar") %></td>
                            <td><%#Eval("AdSoyad") %></td>
                            <td><%#Eval("Telefon") %></td>
                            <td class="center"><%#Eval("SiparisTarihi") %></td>
                            <td class="center"><%#Eval("OdemeAdi")%></td>
                            <td class="center"><%#String.Format("{0:C}",Eval("Toplam")) %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="Siparis.aspx?Goruntule=<%#Eval("SiparisAppID") %>"><i class="iconsweets-pdf"></i> &nbsp;Görüntüle</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Siparis.aspx?Sil=<%#Eval("SiparisAppID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                            </ul>
                                        </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                
                <div class="divider15">
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Önceki" FirstText="İlk" LabelText="Sayfa :" LastText="Son" NextText ="Sonraki »" PageNumbersDisplay="Numbers" PageSize="10" SectionPadding="10" QueryStringKey="myp" ResultsLocation="None" ShowFirstLast="False" ShowLabel="True" ShowPageNumbers="True" BackNextLinkSeparator="">
</cc1:CollectionPager> 
                </div>

                </asp:Panel>
                <asp:Panel ID="_pnlTumu" runat="server">
                
            	<h4 class="widgettitle">Tüm Siparişler</h4>
            	<table class="table table-bordered" id="Table1">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                          	<th class="head0 nosort">#ID</th>
                            <th class="head0">Yemek Adı</th>
                            <th class="head0">Miktar/Adet</th>
                            <th class="head1">Sipariş Veren</th>
                            <th class="head0">Telefon</th>
                            <th class="head1">Sipariş Tarihi</th>
                            <th class="head1">Ödeme Türü</th>
                            <th class="head0">Toplam Tutar</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstTumSiparis" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("SiparisID") %>
                          </span></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="center"><%#Eval("Miktar") %></td>
                            <td><%#Eval("AdSoyad") %></td>
                            <td><%#Eval("Telefon") %></td>
                            <td class="center"><%#Eval("SiparisTarihi") %></td>
                            <td class="center"><%#Eval("OdemeAdi")%></td>
                            <td class="center"><%#String.Format("{0:C}",Eval("Toplam")) %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="Siparis.aspx?Goruntule=<%#Eval("SiparisAppID") %>"><i class="iconsweets-pdf"></i> &nbsp;Görüntüle</a></li>
                                              <li><a href="Siparis.aspx?Onay=<%#Eval("SiparisAppID") %>"><i class="iconsweets-like"></i> &nbsp;Onayla</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Siparis.aspx?Sil=<%#Eval("SiparisAppID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                            </ul>
                                        </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                
                <div class="divider15">
                <cc1:CollectionPager ID="cpSayfala" runat="server" BackText="« Önceki" FirstText="İlk" LabelText="Sayfa :" LastText="Son" NextText ="Sonraki »" PageNumbersDisplay="Numbers" PageSize="10" SectionPadding="10" QueryStringKey="myp" ResultsLocation="None" ShowFirstLast="False" ShowLabel="True" ShowPageNumbers="True" BackNextLinkSeparator="">
</cc1:CollectionPager> 
                </div>

                </asp:Panel>
                </div></div>
</asp:Content>

