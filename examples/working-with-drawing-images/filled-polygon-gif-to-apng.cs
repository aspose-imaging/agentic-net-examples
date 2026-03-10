using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for intermediate GIF and final APNG
        string gifPath = "polygon.gif";
        string apngPath = "polygon.apng";

        // Create a GIF image, draw a filled polygon on it
        GifOptions gifOptions = new GifOptions();
        gifOptions.Source = new FileCreateSource(gifPath, false);

        using (Image gifImage = Image.Create(gifOptions, 400, 300))
        {
            // Draw on the GIF canvas
            Graphics graphics = new Graphics(gifImage);
            graphics.Clear(Color.White);

            // Define polygon vertices
            Point[] polygonPoints = new Point[]
            {
                new Point(50, 250),
                new Point(200, 50),
                new Point(350, 250)
            };

            // Fill the polygon with a solid brush
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                graphics.FillPolygon(brush, polygonPoints);
            }

            // Save the GIF image
            gifImage.Save();
        }

        // Load the created GIF and save it as an APNG
        using (Image loadedGif = Image.Load(gifPath))
        {
            loadedGif.Save(apngPath, new ApngOptions());
        }
    }
}