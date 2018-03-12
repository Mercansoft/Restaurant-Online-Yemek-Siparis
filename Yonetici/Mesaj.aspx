<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Mesaj.aspx.cs" Inherits="Yonetici_Mesaj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincontent">
        	<div class="contentinner">
                <asp:Panel ID="_pnlGelenMesajlar" runat="server">
            	<h4 class="widgettitle">Gelen Mesajlar</h4>
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
<%--                            <th class="head0 nosort">
                                <asp:CheckBox ID="_chkTumu" runat="server" /></th>--%>
                          	<th class="head0 nosort">#ID</th>
                            <th class="head0">Gönderen</th>
                            <th class="head0">Konu</th>
                            <th class="head1">E-mail</th>
                            <th class="head0">Telefon</th>
                            <th class="head1">Tarih</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstSiparisler" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
<%--                            <td>
                                <asp:CheckBox ID="_chk" runat="server" /></td>--%>
                          <td class="aligncenter"><span class="center">
                            <%#Eval("MesajID") %>
                          </span></td>
                            <td><%#Eval("Kimden") %></td>
                            <td class="center"><%#Eval("Konu") %></td>
                            <td><%#Eval("Email") %></td>
                            <td><%#Eval("Telefon") %></td>
                            <td class="center"><%#Eval("Tarih") %></td>
                            <td>
                             <div class="btn-group">
                              <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="Mesaj.aspx?Oku=<%#Eval("MesajID") %>"><i class="iconsweets-pdf"></i> &nbsp;Görüntüle</a></li>
                                              <li><a href="Mesaj.aspx?Sil=<%#Eval("MesajID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                                <li><a href="Mesaj.aspx?TumunuSil=OK"><i class="iconsweets-denied"></i> Tüm Mesajları Sil</a></li>
                                </ul>
                            </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                 </asp:Panel>
                <div class="divider15"></div>
                
                
                <asp:Panel ID="_pnlOkunmusMesajlar" runat="server">
            	<h4 class="widgettitle">Okunmuş Mesajlar</h4>
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
                          	<th class="head0 nosort" style="height: 36px">#ID</th>
                            <th class="head0" style="height: 36px">Gönderen</th>
                            <th class="head0" style="height: 36px">Konu</th>
                            <th class="head1" style="height: 36px">E-mail</th>
                            <th class="head0" style="height: 36px">Telefon</th>
                            <th class="head1" style="height: 36px">Tarih</th>
                            <th class="head0" style="height: 36px">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstOkunmusMesaj" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("MesajID") %>
                          </span></td>
                            <td><%#Eval("Kimden") %></td>
                            <td class="center"><%#Eval("Konu") %></td>
                            <td><%#Eval("Email") %></td>
                            <td><%#Eval("Telefon") %></td>
                            <td class="center"><%#Eval("Tarih") %></td>
                            <td>
                             <div class="btn-group">
                              <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="Mesaj.aspx?Oku=<%#Eval("MesajID") %>"><i class="iconsweets-pdf"></i> &nbsp;Görüntüle</a></li>
                                              <li><a href="Mesaj.aspx?Sil=<%#Eval("MesajID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
                                                <li><a href="Mesaj.aspx?TumunuSil=OK"><i class="iconsweets-denied"></i> Tüm Mesajları Sil</a></li>
                                </ul>
                            </div>
                            </td>
                        </tr>
                       </ItemTemplate>
                        </asp:Repeater>
                      </tbody>
                </table>
                 </asp:Panel>
                <div class="divider15"></div>
                <asp:Panel ID="_pnlMesajOku" runat="server">
                    <asp:DataList ID="_lstMesaj" runat="server">
                    <ItemTemplate>
                <div class="row-fluid">
                
                <div class="span6">
                                 
                  <table class="table table-bordered table-invoice">
                      <tr>
                          <td >Kimden :</td>
                          <td ><strong><%#Eval("Kimden") %></strong></td>
                      </tr>
                      <tr>
                        <td>E-Mail :</td>
                        <td><%#Eval("Email") %></td>
                    </tr>
                        <tr>
                          <td>Telefon :</td>
                          <td><%#Eval("Telefon") %></td>
                      </tr>
                        <tr>
                          <td>Tarih  :</td>
                          <td><%#Eval("Tarih")%></td>
                      </tr>
                      <tr>
                          <td>Konu :</td>
                          <td><%#Eval("Konu")%>n</td>
                      </tr>
                  </table>
                </div><!--span6-->                
            </div>

                            <table class="table table-bordered table-invoice">
<%--                	<colgroup>
                    	<col class="con0 width60" />
                        <col class="con0 width20" />
                        <col class="con1 width20" />
               		</colgroup>--%>
                    <tbody>
                        <tr>
                        	<td class="msg-invoice">
          						<h4>Mesaj İçeriği:</h4>
          						<p><%#Eval("Mesaj")%></p>
                            </td>
<%--                            <td class="right">
                            	&nbsp;</td>
                            <td class="right">&nbsp;</td>--%>
                        </tr>
                    </tbody>
          </table>
          
                    </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
                </div></div>
</asp:Content>

