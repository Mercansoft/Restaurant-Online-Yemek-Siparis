using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RetCap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(120, 40);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.Lavender);
        string randstr = RandomString(7);
        Session["captcha"] = randstr;
        g.DrawString(randstr, new Font(FontFamily.Families[114], 15, FontStyle.Bold), new SolidBrush(Color.Black), 5, 10);
        g.DrawLine(new Pen(Color.Red,1), 10, 10, 100, 100);
        g.DrawLine(new Pen(Color.Red, 1), 100, 10, 50, 50);
        Random rdm = new Random();
        for (int i = 0; i < bmp.Width; i++)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                if (rdm.Next(4)==1)
                {
                    bmp.SetPixel(i, j, Color.Black);
                }
            }
        }
        bmp.Save(Response.OutputStream, ImageFormat.Png);

        //Font font = new Font(fonts, Punto);
        //Random r = new Random();
        //int sayi = r.Next(1000, 99999);
        //Session["captcha"] = sayi;
        //System.Drawing.Image img = System.Drawing.Image.FromFile(arkaplanResmi);
        //g.DrawImage(img, 1, 1);
        //g.DrawString(sayi.ToString(), font, Brushes.DarkRed, X, Y);
        //g.CompositingQuality = CompositingQuality.HighQuality;
        //bmp.Save(Server.MapPath("image/captcha.png"), ImageFormat.Png);
    }
    public string RandomString(int loop)
    {
        Random rdm = new Random();
        string deger = "";
        for (int i = 0; i < loop; i++)
        {
            deger += ((char)rdm.Next('A', 'Z')).ToString();
        }
        return deger;
    }
}