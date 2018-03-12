<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Slider.aspx.cs" Inherits="Yonetici_Slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincontent">
        	<div class="contentinner">
             	<h4 class="widgettitle">Slider Ayarları</h4>
                <div class="widgetcontent">
                	<%--<form id=form1 runat="server" class="stdform">--%>
                        <p>
                        	<label>Yemek Seçiniz</label>
                            <span class="field">
                            <table>
                            <tr>
                            <td><asp:ListBox ID="ListBox1" CssClass="span4" runat="server" AutoPostBack="False" 
                                Height="219px"></asp:ListBox></td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="Resmi Gör ->" 
                                        onclick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td><asp:Image ID="Image1" runat="server" Height="100" Width="100" /></td>
                            </tr>
                            </table>
                                
                                
                            </span> 
                        </p>
                        
                        
                                                
                        <p class="stdformbutton">
                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" 
                                Text="Kaydet" onclick="Button1_Click" />
                        </p>
                        
                    <asp:Label ID="_lblKayit" runat="server" Text=""></asp:Label>
                    <%--</form> --%> 
                </div><!--widgetcontent-->
               
               
                <asp:Panel ID="_pnlSliderYemek" runat="server">
    <h4 class="widgettitle">Slider Listesi</h4>
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
                            <th class="head0">Resim</th>
                            <th class="head0">Durum</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstSliderList" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                            <%#Eval("SliderID") %>
                          </span></td>
                            <td><%#Eval("YemekAdi") %></td>
                            <td class="center"><img src="../<%#Eval("Resim") %>" height="30" width="30" /></td>
                            <td>
                                                                    <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown"><i class="icon-th"></i> &nbsp; Admin <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                              <li><a href="#"><i class="iconsweets-pdf"></i> &nbsp;-</a></li>
                                              <li><a href="#"><i class="iconsweets-like"></i> &nbsp;-</a></li>
                                              <li class="divider"></li>
                                              <li><a href="Slider.aspx?Sil=<%#Eval("SliderID") %>"><i class="iconsweets-denied"></i> &nbsp;Sil</a></li>
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



            </div><!--contentinner-->
        </div>
</asp:Content>

