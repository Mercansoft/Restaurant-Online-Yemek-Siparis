<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Yonetici_Giris" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<title>Yönetici Giriş Paneli - MercanPanel v3.0</title>
<link rel="stylesheet" href="css/style.default.css" type="text/css" />
<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
</head>

<body class="loginbody">
<div class="loginwrapper">
	<div class="loginwrap zindex100 animate2 bounceInDown">
	<h1 class="logintitle">Yönetici Girişi<span class="subtitle">Giriş Paneline Hoşgeldiniz</span></h1>
        <div class="loginwrapperinner">
            <form id="loginform" runat=server>
                <p class="animate4 bounceIn">
                    <asp:TextBox ID="username" runat="server" placeholder="Kullanıcı Adınız"></asp:TextBox></p>
                <p class="animate5 bounceIn"><asp:TextBox ID="password" runat="server" placeholder="Şifreniz" TextMode="Password"></asp:TextBox></p>
                <p class="animate6 bounceIn">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-default btn-block" 
                        Text="Giriş" onclick="Button1_Click" /></p>
                        <p class="animate7 fadeIn"><a href=""><span class="icon-question-sign icon-white"></span> 
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></a></p>
            </form>
        </div><!--loginwrapperinner-->
    </div>
    <div class="loginshadow animate3 fadeInUp"></div>
</div><!--loginwrapper-->

<script type="text/javascript">
    jQuery.noConflict();

    jQuery(document).ready(function () {

        var anievent = (jQuery.browser.webkit) ? 'webkitAnimationEnd' : 'animationend';
        jQuery('.loginwrap').bind(anievent, function () {
            jQuery(this).removeClass('animate2 bounceInDown');
        });

        jQuery('#username,#password').focus(function () {
            if (jQuery(this).hasClass('error')) jQuery(this).removeClass('error');
        });

        jQuery('#loginform button').click(function () {
            if (!jQuery.browser.msie) {
                if (jQuery('#username').val() == '' || jQuery('#password').val() == '') {
                    if (jQuery('#username').val() == '') jQuery('#username').addClass('error'); else jQuery('#username').removeClass('error');
                    if (jQuery('#password').val() == '') jQuery('#password').addClass('error'); else jQuery('#password').removeClass('error');
                    jQuery('.loginwrap').addClass('animate0 wobble').bind(anievent, function () {
                        jQuery(this).removeClass('animate0 wobble');
                    });
                } else {
                    jQuery('.loginwrapper').addClass('animate0 fadeOutUp').bind(anievent, function () {
                        jQuery('#loginform').submit();
                    });
                }
                return false;
            }
        });
    });
</script>
</body>
</html>
