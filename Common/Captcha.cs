using System;
using System.Text;


namespace DentalDDS_Api.Common
{
    public class Captcha
    {       
        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();
            string alphabets = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            Random r = new Random();
            for (int j = 0; j <= 5; j++)
            {
                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }
            return randomText.ToString();
        }
        //For Captcha to generate image from random text      
        //public FileResult GetCaptchaImage()
        //{
        //    //string text = Session["CAPTCHA"].ToString();

        //    //first, create a dummy bitmap just to get a graphics object
        //    Image img = new Bitmap(1, 1);
        //    Graphics drawing = Graphics.FromImage(img);

        //    Font font = new Font("Arial", 15);
        //    //measure the string to see how big the image needs to be
        //    SizeF textSize = drawing.MeasureString(text, font);

        //    //free up the dummy image and old graphics object
        //    img.Dispose();
        //    drawing.Dispose();

        //    //create a new image of the right size
        //    img = new Bitmap((int)textSize.Width + 40, (int)textSize.Height + 20);
        //    drawing = Graphics.FromImage(img);

        //    Color backColor = Color.Transparent;
        //    Color textColor = Color.SteelBlue;
        //    //paint the background
        //    drawing.Clear(backColor);

        //    //create a brush for the text
        //    Brush textBrush = new SolidBrush(textColor);

        //    drawing.DrawString(text, font, textBrush, 20, 10);

        //    drawing.Save();

        //    font.Dispose();
        //    textBrush.Dispose();
        //    drawing.Dispose();

        //    MemoryStream ms = new MemoryStream();
        //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    img.Dispose();

        //    return ms.ToArray(); ; //File(ms.ToArray(), "image/png");
        //}
    }
}