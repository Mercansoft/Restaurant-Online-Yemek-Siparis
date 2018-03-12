<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Admin.master" AutoEventWireup="true" CodeFile="Manset.aspx.cs" Inherits="Yonetici_Manset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">        
        <div class="maincontent">
        	<div class="contentinner">
            	<h4 class="widgettitle">Manşet Ayarları</h4>
                <div class="widgetcontent">
                	<%--<form id=form1 runat="server" class="stdform">--%>
                    	
                        <div class="par control-group success">
                          <label for="inputSuccess" class="control-label">Manşet Resmi</label>
                          <div class="controls">
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                          </div>
                        </div><!--par-->        
                                               
                                                
                        <p class="stdformbutton">
                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" 
                                Text="Kaydet" onclick="Button1_Click" />
                        </p>
                    <asp:Label ID="_lblKayit" runat="server" Text=""></asp:Label>
                        
                    <%--</form> --%> 
                                    <h4 class="widgettitle nomargin shadowed">Manşetleriniz</h4>
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
                            <th class="head0">Manşet Resim</th>
                            <th class="head1">Sil</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_lstMansetler" runat="server">
                        <ItemTemplate>
                         <tr class="gradeA">
                          <td><span class="center">
                           <%#Eval("MansetID") %>
                          </span></td>
                            <td class="center"><img src="../<%#Eval("Resim") %>" height="75" width="525" /></td>
                            <td class="center"><a href="Manset.aspx?Sil=<%#Eval("MansetID") %>" title="Sil" class="btn btn-danger btn-circle"><i class="iconsweets-denied"></i></a></td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                                    </table>
                
                <div class="divider15"></div>
            </div><!--contentinner-->
        </div>
</asp:Content>

