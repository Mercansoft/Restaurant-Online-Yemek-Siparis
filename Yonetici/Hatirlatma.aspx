<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Hatirlatma.aspx.cs" Inherits="Yonetici_Hatirlatma" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="maincontent">
        	<div class="contentinner">
                <asp:Panel ID="_pnlTumu" runat="server">
                
            	<h4 class="widgettitle">Hatırlatmalar</h4>
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
                            <th class="head0">Başlık</th>
                            <th class="head0">Konu</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstTumSiparis" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("HatirlatID") %>
                          </span></td>
                            <td><%#Eval("Baslik") %></td>
                            <td class="center"><%#Eval("Konu") %></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="#"><i class="iconsweets-pdf"></i> &nbsp;-</a></li>
                                              <li><a href="#"><i class="iconsweets-like"></i> &nbsp;-</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Hatirlatma.aspx?Sil=<%#Eval("HatirlatID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
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



