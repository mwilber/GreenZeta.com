using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GreenZeta.com.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public string Index(string p, int w)
        {
            string imgFile = Request.QueryString["p"];
            string imgSize = Request.QueryString["w"];

            try
            {
                if (imgSize != null) WriteThumbnail(imgFile, imgSize);
                else WriteFullsize(imgFile);
            }
            catch (Exception) { }

            return "";
        }

        private void WriteThumbnail(string imgFile, string imgSize)
        {
            System.Drawing.Image img = GetImage(imgFile);

            int thumbWidth = Convert.ToInt32(imgSize);
            int thumbHeight = Convert.ToInt32(imgSize);

            System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

            System.Drawing.Image thumbNailImg;
            System.Drawing.Image croppedImg;

            // Set by width only
            if (img.Width < img.Height)
            {
                thumbWidth = Convert.ToInt32(imgSize);
                thumbHeight = (int)Math.Floor(Convert.ToInt32(imgSize) * ((float)img.Height / (float)img.Width));
            }
            else
            {
                thumbWidth = (int)Math.Floor((Convert.ToInt32(imgSize) * ((float)img.Width / (float)img.Height)));
                thumbHeight = Convert.ToInt32(imgSize);
            }

            //thumbNailImg = img.GetThumbnailImage(thumbWidth, thumbHeight, dummyCallBack, IntPtr.Zero);
            thumbNailImg = resizeImage(img, new Size(thumbWidth, thumbHeight));

            try
            {
                croppedImg = cropImage(thumbNailImg, new Rectangle(0, 0, thumbNailImg.Width, thumbNailImg.Width));
                Response.ContentType = "image/jpeg";
                croppedImg.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                croppedImg.Dispose();
            }
            catch (Exception) {
                Response.ContentType = "image/jpeg";
                thumbNailImg.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                thumbNailImg.Dispose();
            }
            

            
        }


        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            destWidth++;
            destHeight++;

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        private void WriteFullsize(string imgFile)
        {
            System.Drawing.Image img = GetImage(imgFile);
            Response.ContentType = "image/jpeg";
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            img.Dispose();
        }

        private System.Drawing.Image GetImage(string imgFile)
        {
            System.Drawing.Image img;
            string imgPath = "http://" + ConfigurationManager.AppSettings["domain"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/" + ConfigurationManager.AppSettings["site_root"] + imgFile;

            //Trace.Write("imgPath", imgPath);

            //if (imgFile.Contains("http"))
            if (true)
            {
                HttpWebRequest request = WebRequest.Create(imgPath) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                MemoryStream ms = new MemoryStream();
                BinaryWriter bw = new BinaryWriter(ms);
                BinaryReader br = new BinaryReader(stream);
                bw.Write(br.ReadBytes((int)response.ContentLength));
                ms.Position = 0;
                img = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                img = System.Drawing.Image.FromFile(Server.MapPath(imgFile));
            }

            return img;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

    }
}
