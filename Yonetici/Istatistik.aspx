<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Istatistik.aspx.cs" Inherits="Yonetici_Istatistik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="maincontent">
             <div class="contentinner content-editprofile">
            	<h4 class="widgettitle nomargin">Günlük Sipariş İstatistik Verileri - <%Response.Write(DateTime.Now); %></h4>
                <div class="widgetcontent bordered">
                	<div class="row-fluid">
                        <div class="row-fluid">
                	<div class="span4">
                    	<h4 class="widgettitle">Toplam Verilen Sipariş</h4>
                        <div class="widgetcontent">
                            <asp:Label ID="_lblToplamSiparisGunluk" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large" ForeColor="#009900"></asp:Label>
                        </div><!--widgetcontent-->
                    </div><!--span4-->
                    <div class="span4">
                    	<h4 class="widgettitle">Toplam Günlük Kazanç</h4>
                        <div class="widgetcontent">
                        	<asp:Label ID="Label2" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large" ForeColor="#009900" Text="0,00 TL"></asp:Label>
                        </div><!--widgetcontent-->
                    </div><!--span4-->
                    
                    <div class="span4">
                    	<h4 class="widgettitle">Onay Bekleyen Sipariş</h4>
                        <div class="widgetcontent">
                        	 <asp:Label ID="_lblOnayBekleyenSiparisGunluk" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large" ForeColor="#009900"></asp:Label>
                        </div>
                    </div>
                </div>
                        </div>
           </div></div>
                
                 <div class="contentinner content-editprofile">
            	<h4 class="widgettitle nomargin">Tüm Sipariş İstatistik Verileri</h4>
                <div class="widgetcontent bordered">
                	<div class="row-fluid">
                        <div class="row-fluid">
                	<div class="span4">
                    	<h4 class="widgettitle">Toplam Verilen Sipariş</h4>
                        <div class="widgetcontent">
                            <asp:Label ID="_lblToplamSiparis" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large" ForeColor="#009900"></asp:Label>
                        </div><!--widgetcontent-->
                    </div><!--span4-->
                    <div class="span4">
                    	<h4 class="widgettitle">Toplam Kazanç</h4>
                        <div class="widgetcontent">
                        	<asp:Label ID="_lblToplamUcret" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large" ForeColor="#009900" Text="0,00 TL"></asp:Label>
                        </div><!--widgetcontent-->
                    </div><!--span4-->
                    
                    <div class="span4">
                    	<h4 class="widgettitle">Onay Bekleyen Sipariş</h4>
                        <div class="widgetcontent">
                        	 <asp:Label ID="_lblOnayBekleyenSiparis" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large" ForeColor="#009900"></asp:Label>
                        </div><!--widgetcontent-->
                    </div><!--span4-->
                </div>

                       
                        </div>
           </div></div>
            
            

        	
        </div>
</asp:Content>

