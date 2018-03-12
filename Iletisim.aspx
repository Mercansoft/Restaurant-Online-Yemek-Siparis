<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Iletisim.aspx.cs" Inherits="Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content_holder" class="fixed">
    <div class="inner">
      <div class="breadcrumb"> <a href="index.html">Home</a> » Contact Us </div>
      <h2 class="heading-title"><span>Bize Yazın</span></h2>
      
      <!-- LEFT COLUMN -->
      <div id="column-left">
        <div class="box">
          <h4 class="heading-title"><span>İletişim Bilgilerimiz</span></h4>
          <div class="box-content box-contact-details">
            <ul>
              <li class="address"><asp:Label ID="_lblAdres" runat="server" Text=""></asp:Label></li>
                <li class="phone"><asp:Label ID="_lblCepTelefon" runat="server" Text=""></asp:Label></li>
              <li class="phone"><asp:Label ID="_lblSabitTelefon" runat="server" Text=""></asp:Label></li>
              <li class="fax"><asp:Label ID="_lblFax" runat="server" Text=""></asp:Label></li>
            </ul>
          </div>
        </div>
      </div>
      <!-- END OF LEFT COLUMN -->
<%--      <form id="form1" runat="server">--%>
      <div id="content" class="content-column-left">
        <div class="content contacts-page">
          <div class="box-contacts fixed">
            <div class="box-content">
              <div class="stitched"></div>
              <div class="form"> <span class="label">İsminiz:</span>
               <asp:TextBox ID="_txtisim" runat="server" Width="250px"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtisim" ErrorMessage="Lütfen Adınız Soyadınızı Boş Geçmeyiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                <br/>
                <br/>
                <span class="label">E-mail Adresiniz:</span>
                <asp:TextBox ID="_txtEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_txtEmail" ErrorMessage="Lütfen E-mail Adresinizi Boş Geçmeyiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                <br/>
                <br/>
                 <span class="label">Telefon Numaranız:</span>
                <asp:TextBox ID="_txtTelefon" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_txtTelefon" ErrorMessage="Lütfen Telefon Numarasını Boş Geçmeyiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                <br/>
                <br/>
                 <span class="label">Konu:</span>
                <asp:TextBox ID="_txtKonu" runat="server" Width="250px"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_txtKonu" ErrorMessage="Lütfen Konuyu Boş Geçmeyiniz" ForeColor="Red"></asp:RequiredFieldValidator>
                <br/>
                <br/>
                <span class="label">Mesajınız:</span>
                 <asp:TextBox ID="_txtMesaj" style="width: 98%;" runat="server" rows="10" cols="40" TextMode="MultiLine"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_txtMesaj" ErrorMessage="Lütfen Mesajınızı Yazınız" ForeColor="Red"></asp:RequiredFieldValidator><br /><br />
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <br/>
                <br/>
              </div>
              <div class="stitched">
              </div>
            </div>
          </div>
          <div class="clear"></div>

                      <div class="buttons">
            <div class="left">
               <%--<img src="images/captcha.png" alt="sayi" title="sayi" />--%>
                <asp:Image ID="Image1" runat="server" ImageUrl="RetCap.aspx" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server"
                ErrorMessage="Doğrulama Kodu Yanlış" ControlToValidate="TextBox1"></asp:CustomValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
            ControlToValidate="TextBox1" ErrorMessage="Doğrulama Kodunu Girin"></asp:RequiredFieldValidator>
            </div> 
          </div>

          <div class="buttons">
            <div class="left">
               <asp:Button ID="_btnGonder" runat="server" CssClass="button" 
                    Text="Mesajımı Gönder" onclick="_btnGonder_Click" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Label ID="_lblDurum" runat="server" Text="" Font-Bold="True" 
                    ForeColor="#009933"></asp:Label>
            <%--<a class="button" id="button-contact"><span>Submit</span></a>--%></div> 
          </div>
        </div>
      </div>
<%--      </form>--%>
      <div class="clear"></div>
    </div>
  </div>
</asp:Content>

