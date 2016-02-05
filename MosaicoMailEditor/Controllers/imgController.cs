using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MosaicoMailEditor.Controllers
{
    public class imgController : Controller
    {
        // GET: img
        public void Index()
        {
            string method = Request.QueryString["method"];
            string Params = Request.QueryString["params"];
            string src = Request.QueryString["src"];
            if (method == "cover") {
                //string companyName = "Ågrenshuset";

                int targetWidth = Int32.Parse(Params.Split(',')[0]);
                int targetHeight = Int32.Parse(Params.Split(',')[1]);



                if (src == "") { return; }
                src = src.Replace("http://www.lillagula.se/api/", "").Replace("/newsletterimages/", "/");

                src = Request.RequestContext.HttpContext.Server.MapPath("~/images/newsletter-images/" + src);

                Image original = Image.FromFile(src);


                Bitmap temp = new Bitmap(targetWidth, targetHeight, original.PixelFormat);
                Graphics newImage = Graphics.FromImage(temp);
                newImage.DrawImage(original, 0, 0, targetWidth, targetHeight);

                temp.Save(HttpContext.Response.OutputStream, ImageFormat.Png);
                HttpContext.Response.ContentType = "image/png";
                HttpContext.Response.Flush();
                original.Dispose();
                temp.Dispose();
                newImage.Dispose();
            }
            if (method == "resize") {

                //Dim companyName As String = "Ågrenshuset"

                int resizeWidth = Int32.Parse(Params.Replace(",", "").Replace("null", ""));
                if (src == "") { return; }
                src = src.Replace("http://www.lillagula.se/api/", "").Replace("/newsletterimages/", "/");
                src = Request.RequestContext.HttpContext.Server.MapPath("~/images/newsletter-images/" + src);

                Image original = Image.FromFile(src);
                float aspect = original.Height / original.Width;

                int newHeight = (int)(resizeWidth * aspect);

                Bitmap temp = new Bitmap(resizeWidth, newHeight, original.PixelFormat);
                Graphics newImage = Graphics.FromImage(temp);
                newImage.DrawImage(original, 0, 0, resizeWidth, newHeight);


                temp.Save(HttpContext.Response.OutputStream, ImageFormat.Png);
                HttpContext.Response.ContentType = "image/png";
                HttpContext.Response.Flush();
                original.Dispose();
                temp.Dispose();
                newImage.Dispose();
            }



            if (method == "placeholder") { 
                int width= Int32.Parse( Params.Split(',')[0]);
                int height = Int32.Parse(Params.Split(',')[1]);

                using  (Bitmap _img = new Bitmap(width, height)){

                    using (Graphics g = Graphics.FromImage(_img)) {
                        string text = "Hello";
                        Font drawFont = new Font("Arial", 34, FontStyle.Bold);
                        SolidBrush drawBrush = new SolidBrush(Color.Silver);
                        SolidBrush textBrush = new SolidBrush(Color.Black);

                        g.FillRectangle(drawBrush, new Rectangle(0, 0, width, height));
                        //'g.DrawString(text, drawFont, textBrush, stringPoint)


                        Rectangle rect1 = new Rectangle(0, 0, width, height);

                        //' Create a StringFormat object with the each line of text, and the block
                        //' of text centered on the page.
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        //' Draw the text and the surrounding rectangle.
                        g.DrawString(width + " x " + height, drawFont, textBrush, rect1, stringFormat);
                        g.DrawRectangle(Pens.Black, rect1);

                    }
                    MemoryStream ms = new MemoryStream();
                    _img.Save(ms, ImageFormat.Png);


                    _img.Save(HttpContext.Response.OutputStream, ImageFormat.Png);
                    HttpContext.Response.ContentType = "image/png";
                    HttpContext.Response.Flush();


                }
            }
        }
    }
}