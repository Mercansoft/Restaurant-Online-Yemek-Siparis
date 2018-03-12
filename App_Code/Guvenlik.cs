using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Guvenlik
/// </summary>
public class Guvenlik
{
    const string letters = "23456789abcdefghijkmnpqrstuvwxwz";
    public static string captcha;
   
    public Guvenlik()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string _SqlBugKontrol(string Str)
    {
        Str = Str.Replace("'", "`");
        Str = Str.Replace("--", " ");
        Str = Str.Replace(";", " ");
        Str = Str.Replace("(", "[");
        Str = Str.Replace(")", "]");
        Str = Str.Replace("WAITFOR", " ");
        Str = Str.Replace("DELAY", " ");
        Str = Str.Replace("waitfor", " ");
        Str = Str.Replace("delay", " ");
        Str = Str.Replace("and", " ");
        Str = Str.Replace("union", " ");
        Str = Str.Replace("from", " ");
        Str = Str.Replace("where", " ");
        Str = Str.Replace("select", " ");
        Str = Str.Replace("=", ":");
        return Str;
    }
    public static char randLetter(Random rnd)
    {
        return letters[rnd.Next(letters.Length)];
    }
    public static string SifreUretici()
    {
        Random rnd = new System.Random(unchecked((int)DateTime.Now.Ticks));
        string ret = "";
        for (int i = 0; i < 6; i++)
        {
            ret += randLetter(rnd);
        }
        return ret;
    }
    public static string ToUrl(string text)
    {
        if (text == "" || text == null) { return ""; }
        text = text.Replace("ş", "s");
        text = text.Replace("Ş", "S");
        text = text.Replace(".", "");
        text = text.Replace(":", "");
        text = text.Replace(";", "");
        text = text.Replace(",", "");
        text = text.Replace(" ", "-");
        text = text.Replace("!", "");
        text = text.Replace("(", "");
        text = text.Replace(")", "");
        text = text.Replace("'", "");
        text = text.Replace("ğ", "g");
        text = text.Replace("Ğ", "G");
        text = text.Replace("ı", "i");
        text = text.Replace("I", "i");
        text = text.Replace("ç", "c");
        text = text.Replace("ç", "C");
        text = text.Replace("ö", "o");
        text = text.Replace("Ö", "O");
        text = text.Replace("ü", "u");
        text = text.Replace("Ü", "U");
        text = text.Replace("`", "");
        text = text.Replace("=", "");
        text = text.Replace("&", "");
        text = text.Replace("%", "");
        text = text.Replace("#", "");
        text = text.Replace("<", "");
        text = text.Replace(">", "");
        text = text.Replace("*", "");
        text = text.Replace("?", "");
        text = text.Replace("+", "-");
        text = text.Replace("\"", "-");
        text = text.Replace("»", "-");
        text = text.Replace("|", "-");
        text = text.Replace("^", "");
        return text;
    }
    //private void Guvenlik(int H, int W, string fonts, int Punto, int X, int Y, string arkaplanResmi)
    //{
    //    Bitmap bmp = new Bitmap(H, W);
    //    Graphics g = Graphics.FromImage(bmp);
    //    Font font = new Font(fonts, Punto);
    //    Random r = new Random();
    //    int sayi = r.Next(1000, 99999);
    //    captcha = sayi.ToString();
    //    System.Drawing.Image img = System.Drawing.Image.FromFile(arkaplanResmi);
    //    g.DrawImage(img, 1, 1);
    //    g.DrawString(sayi.ToString(), font, Brushes.DarkRed, X, Y);
    //    g.CompositingQuality = CompositingQuality.HighQuality;
    //    bmp.Save(Server.MapPath("images/captcha.png"), ImageFormat.Png);
    //}


}