using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(ms);

                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Green, 10);
                    graphics.DrawEllipse(pen, new Rectangle(50, 50, 400, 400));

                    image.Save();
                }

                byte[] imageBytes = ms.ToArray();
                Console.WriteLine($"Generated BMP byte array length: {imageBytes.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}