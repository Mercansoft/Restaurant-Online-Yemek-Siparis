<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Yonetici.aspx.cs" Inherits="Yonetici_Yonetici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                    <div class="maincontent">
        	<div class="contentinner">
                    <asp:Panel ID="_pnlYoneticiTablosu" runat="server">
            	<h4 class="widgettitle">Yönetici Listesi</h4>
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
                            <th class="head0">Kullanıcı Adı</th>
                            <th class="head1">Ad Soyad</th>
                            <th class="head0">E-Mail</th>
                            <th class="head1">Şifre</th>
                            <th class="head1">Admin</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstYoneticilerListesi" runat="server">
                        <ItemTemplate>
                        <tr class="gradeX">
                          <td class="aligncenter"><span class="center">
                           <%#Eval("YoneticiID") %>
                          </span></td>
                            <td><%#Eval("KullaniciAdi") %></td>
                            <td><%#Eval("Isim") %> <%#Eval("Soyisim") %></td>
                            <td><%#Eval("Email") %></td>
                            <td class="center"><%#Eval("Sifre") %></td>
                            <td class="center"><a href="Yonetici.aspx?Sil=<%#Eval("YoneticiID") %>" class="btn"><span class="icon-edit"></span> Sil</a></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                
<%--                <div class="divider15"></div>
                
                
                <div class="divider15"></div>

   
   				<div class="divider15"></div>
   --%>
                
    </asp:Panel>
    <asp:Panel ID="_pnlYoneticiEkle" runat="server">
            	<h4 class="widgettitle nomargin">Yönetici Ekle</h4>
                <div class="widgetcontent bordered">
                	<div class="row-fluid">
<%--                    	<div class="span3 profile-left">
                        </div><!--span3-->--%>
                        <div class="span9">
                            
                            	<h4>Yönetici Bilgileri</h4>
                                <p>
                                	<label>Kullanıcı Adı:</label>
                                    <asp:TextBox ID="_txtKullaniciAdi" CssClass="input-xlarge" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                	<label>Email:</label>
                                    <asp:TextBox ID="_txtEmail" CssClass="input-xlarge" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                	<label style="padding:0">Password</label>
                                    <asp:TextBox ID="_txtSifre" CssClass="input-xlarge" runat="server"></asp:TextBox>
                                </p>                     
                                <p>
                                	<label>Adı:</label>
                                	<asp:TextBox ID="_txtAdi" CssClass="input-xlarge" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                	<label>Soyadı:</label>
                                    <asp:TextBox ID="_txtSoyadi" CssClass="input-xlarge" runat="server"></asp:TextBox>
                                </p>
                                
                                <br />
                                <p>
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" 
                                        Text=" Kaydet " onclick="Button1_Click" /> &nbsp; 
                                    <asp:Label ID="_lblDurum" runat="server" Text="" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="#009900"></asp:Label>
                                </p>
                            
                        </div>
                        
                    </div><!--row-fluid-->
                </div><!--widgetcontent-->

    </asp:Panel>
    </div></div>
</asp:Content>

