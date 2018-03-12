<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Yonetici_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contentinner content-dashboard">
            	<div class="alert alert-info">
                	<button type="button" class="close" data-dismiss="alert">×</button>
                    <strong>Hoşgeldin Patron!</strong> Allah Bol Kazançlar versin. Bismillahirrahmanirrahim.
                </div><!--alert-->
                
                <div class="row-fluid">
                	<div class="span8">
                    	<ul class="widgeticons row-fluid">
                        	<li class="one_fifth"><a href="Yemek.aspx?Komut=Listele"><img src="img/gemicon/location.png" alt="" /><span>Yemekler</span></a></li>
                            <li class="one_fifth"><a href="Menu.aspx"><img src="img/gemicon/image.png" alt="" /><span>Menü</span></a></li>
                            <li class="one_fifth"><a href="Siparis.aspx?Komut=Yeni"><img src="img/gemicon/reports.png" alt="" /><span>Siparişler</span></a></li>
                            <li class="one_fifth"><a href="Sayfa.aspx"><img src="img/gemicon/edit.png" alt="" /><span>Hakkımızda</span></a></li>
                            <li class="one_fifth last"><a href="Mesaj.aspx"><img src="img/gemicon/mail.png" alt="" /><span>Mesajlar</span></a></li>
                        	<li class="one_fifth"><a href="Hatirlatma.aspx"><img src="img/gemicon/calendar.png" alt="" /><span>Hatırlatma</span></a></li>
                            <li class="one_fifth"><a href="Yonetici.aspx"><img src="img/gemicon/users.png" alt="" /><span>Yöneticiler</span></a></li>
                            <li class="one_fifth"><a href="Ayar.aspx"><img src="img/gemicon/settings.png" alt="" /><span>Ayarlar</span></a></li>
                            <li class="one_fifth"><a href="Hizmet.aspx"><img src="img/gemicon/archive.png" alt="" /><span>Hizmetlerimiz</span></a></li>
                            <li class="one_fifth last"><a href="Istatistik.aspx"><img src="img/gemicon/notify.png" alt="" /><span>Istatistikler</span></a></li>
                        </ul>
                        
                       <%-- <br />--%>
                        
<%--                        <h4 class="widgettitle">Report Summary</h4>
                        <div class="widgetcontent">
                        	<div id="chartplace1" style="height:300px;"></div>
                        </div><!--widgetcontent-->--%>
                        <h4 class="widgettitle">Son Olaylar</h4>
                        <div class="widgetcontent">
                            <div id="tabs">
                                <ul>
                                    <li><a href="#tabs-1"><span class="icon-forward"></span> Son Siparişler</a></li>
                                    <li><a href="#tabs-2"><span class="icon-eye-open"></span> Son Mesajlar</a></li>
                                    <li><a href="#tabs-3"><span class="icon-leaf"></span> Son Hatırlatmalar</a></li>
                                </ul>
                                <div id="tabs-1">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>#ID</th>
                                                <th>Yemek Adı</th>
                                                <th>Sipariş Veren</th>
                                                <th>Sipariş Tarihi</th>
                                                <th>Tutar</th>
                                                <th class="center">Durum</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="_lstSonSiparis" runat="server">
                                            <ItemTemplate>
                                             <tr>
                                                <td><a href="#"><strong><%#Eval("SiparisID") %></strong></a></td>
                                                <td><a href=""><%#Eval("YemekAdi") %></a></td>
                                                <td><a href=""><%#Eval("AdSoyad") %></a></td>
                                                <td><%#Eval("SiparisTarihi") %></td>
                                                <td><a href=""><%#String.Format("{0:C}",Eval("Toplam")) %></a></td>
                                                <td class="center"><a href="Siparis.aspx?Goruntule=<%#Eval("SiparisAppID") %>" class="btn"><span class="icon-edit"></span> Bak</a></td>
                                            </tr>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                                <div id="tabs-2">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Konu</th>
                                                <th>Gönderen</th>
                                                <th>Tarih</th>
                                                <th class="center">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="_lstSonMesajlar" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td><a href=""><strong><%#Eval("Konu") %></strong></a></td>
                                                <td><a href=""><%#Eval("Kimden") %></a></td>
                                                <td><%#Eval("Tarih") %></td>
                                                <td class="center"><a href="Mesaj.aspx?Oku=<%#Eval("MesajID") %>" class="btn"><span class="icon-edit"></span> Oku</a></td>
                                            </tr>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                                <div id="tabs-3">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Başlık</th>
                                                <th>Tarih</th>
                                                <th class="center">Admin</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="_lstHatirlat" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td><a href=""><strong><%#Eval("Baslik") %></strong></a></td>
                                                <td><%#Eval("Tarih") %></td>
                                                <td class="center"><a href="Default.aspx?Sil=<%#Eval("HatirlatID") %>" class="btn"><span class="icon-edit"></span> Sil</a></td>
                                            </tr>
                                             </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table> 
                                </div>
                            </div><!--#tabs-->
                        </div><!--widgetcontent-->
                        
                        
                    </div><!--span8-->
                    <div class="span4">
                    	<h4 class="widgettitle nomargin">Site İstatistikleri</h4>
                        <div class="widgetcontent bordered">
                        	<ul><span class="badge badge-success">
                            &nbsp;<asp:Label 
                                    ID="_lblYeniMesaj" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ></asp:Label></span>&nbsp; Yeni Mesajınız Var!<br />
                            &nbsp;<span class="badge badge-info"><asp:Label 
                                    ID="_lblYeniSiparis" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ></asp:Label></span>&nbsp; Yeni Siparişiniz Var!
                        </div><!--widgetcontent-->

                                            	<h4 class="widgettitle nomargin">Doviz Kurları</h4>
                        <div class="widgetcontent bordered">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Alış &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Satış
                        	<ul>Dolar : <span class="badge badge-success">
                            &nbsp;<asp:Label 
                                    ID="_lblDolarAlis" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ></asp:Label></span>&nbsp;
                                <span class="badge badge-success">
                            &nbsp;<asp:Label 
                                    ID="_lblDolarSatis" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ></asp:Label></span> <br />
                            &nbsp; Euro : <span class="badge badge-info"><asp:Label 
                                    ID="_lblEuroAlis" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ></asp:Label></span>&nbsp;  <span class="badge badge-info"><asp:Label 
                                    ID="_lblEuroSatis" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ></asp:Label></span>
                        </div><!--widgetcontent-->





<%--                        
                        <h4 class="widgettitle nomargin">Events this month</h4>
                        <div class="widgetcontent">
                        	<div id="calendar" class="widgetcalendar"></div>
                        </div><!--widgetcontent-->--%>
                        
<%--                        <h4 class="widgettitle">Site Impressions</h4>
                        <div class="widgetcontent">
                        	<div id="bargraph2" style="height:200px;"></div>
                        </div><!--widgetcontent-->--%>
                        
                        <h4 class="widgettitle">Hatırlatmalar</h4>
                        <div class="widgetcontent">
                        	<div id="accordion" class="accordion">
                                <asp:Repeater ID="_lstHatirlatma" runat="server">
                                    <ItemTemplate>
                                    <h3><a href="#"><%#Eval("Baslik")%> - <%#Eval("Tarih") %></a></h3>
                                    <div>
                                        <p>
                                        <%#Eval("Konu")%>
                                        </p><br /><a href="Default.aspx?Sil=<%#Eval("HatirlatID") %>" title="SİL">[X]</a>
                                    </div>
                                    </ItemTemplate>
                                </asp:Repeater>
<%--                                    <h3><a href="#">Mauris mauris ante, blandit et</a></h3>
                                    <div>
                                        <p>
                                        Mauris mauris ante, blandit et, ultrices a, suscipit eget, quam. Integer
                                        ut neque. Vivamus nisi metus, molestie vel, gravida in, condimentum sit
                                        amet, nunc. Nam a nibh. Donec suscipit eros. Nam mi. Proin viverra leo ut
                                        odio. Curabitur malesuada. Vestibulum a velit eu ante scelerisque vulputate.
                                        </p>
                                    </div>
                                    <h3><a href="#">Donec et ante phasellus eu ligula</a></h3>
                                    <div>
                                        <p>
                                        Sed non urna. Donec et ante. Phasellus eu ligula. Vestibulum sit amet
                                        purus. Vivamus hendrerit, dolor at aliquet laoreet, mauris turpis porttitor
                                        velit, faucibus interdum tellus libero ac justo. Vivamus non quam. In
                                        suscipit faucibus urna.
                                        </p>
                                    </div>
                                    <h3><a href="#">Quam ante aliquam nisi</a></h3>
                                    <div>
                                        <p>
                                        Nam enim risus, molestie et, porta ac, aliquam ac, risus. Quisque lobortis.
                                        Phasellus pellentesque purus in massa. Aenean in pede. Phasellus ac libero
                                        ac tellus pellentesque semper. Sed ac felis. Sed commodo, magna quis
                                        lacinia ornare, quam ante aliquam nisi, eu iaculis leo purus venenatis dui.
                                        </p>
                                        <ul class="margin1020">
                                            <li>List item one</li>
                                            <li>List item two</li>
                                            <li>List item three</li>
                                        </ul>
                                    </div>
                                    <h3><a href="#">Pellentesque habitant morbi</a></h3>
                                    <div>
                                        <p>
                                        Cras dictum. Pellentesque habitant morbi tristique senectus et netus
                                        et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in
                                        faucibus orci luctus et ultrices posuere cubilia Curae; Aenean lacinia
                                        mauris vel est.
                                        </p>
                                        <p>
                                        Suspendisse eu nisl. Nullam ut libero. Integer dignissim consequat lectus.
                                        Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
                                        inceptos himenaeos.
                                        </p>
                        	       </div>--%>
                        	</div><!--#accordion-->
                        </div><!--widgetcontent-->

                                               <%-- <h4 class="widgettitle">Modal Window <a href="widgetsource" class="showhide">View Source</a></h4>--%>
                        <div class="widgetcontent"><%--<form id="form1" runat="server">--%>
                            <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Hatırlatma Ekle" OnClick="Button2_Click" />
                        	<%--<a class="btn btn-primary" href="#myModal" data-toggle="modal">Hatırlatma Ekle</a>--%>
<%--                            <div class="widgetsource">
                            	<div class="divider15"></div>
                            	<pre class="prettyprint linenums">&lt;a href=&quot;#myModal&quot; data-toggle=&quot;modal&quot;&gt;Launch demo modal&lt;/a&gt;</pre>
                              <div class="divider15"></div>
                              <div role="presentation"></div>
                                <pre class="prettyprint linenums">&lt;div id=&quot;myModal&quot; class=&quot;modal&quot;&gt;
   &lt;div class=&quot;modal-header&quot;&gt;
      &lt;button aria-hidden=&quot;true&quot; data-dismiss=&quot;modal&quot; class=&quot;close&quot;&gt;×&lt;/button&gt;
      &lt;h3&gt;Modal header&lt;/h3&gt;
   &lt;/div&gt;
   &lt;div class=&quot;modal-body&quot;&gt;
      ...
   &lt;/div&gt;
   &lt;div class=&quot;modal-footer&quot;&gt;
      &lt;a class=&quot;btn&quot; href=&quot;#&quot;&gt;Close&lt;/a&gt;
      &lt;a class=&quot;btn btn-primary&quot; href=&quot;#&quot;&gt;Save changes&lt;/a&gt;
   &lt;/div&gt;
&lt;/div&gt;</pre>
                            </div><!--widgetsource-->--%>
                        </div><!--widgetcontent-->
 <asp:Panel ID="Panel1" runat="server">
                        
                        Başlık: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
                         Konu : <asp:TextBox ID="TextBox2" runat="server" Height="120px" TextMode="MultiLine" Width="200px"></asp:TextBox><br /><br />
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Kaydet" OnClick="Button1_Click" />
                            
                    </asp:Panel><%--</form>--%>
                    </div>
                   
                    
                    <!--span4-->
                </div><!--row-fluid-->
            </div><!--contentinner-->

            <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="myModal">
            <div class="modal-header">
              <button aria-hidden="true" data-dismiss="modal" class="close" type="button">×</button>
              <h3 id="myModalLabel">Modal Heading</h3>
            </div>
            <div class="modal-body">
              <h4>Text in a modal</h4>
              <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem.</p>
              <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p>
            </div>
            <div class="modal-footer">
              <button data-dismiss="modal" class="btn">Close</button>
              <button class="btn btn-primary">Save changes</button>
            </div>
    </div><!--#myModal-->
</asp:Content>

