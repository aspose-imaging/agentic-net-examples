using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Create output file stream
        using (FileStream stream = new FileStream("filled_polygon.png", FileMode.Create))
        {
            // Set PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with specified dimensions
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define brush for filling the polygon
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    // Define polygon vertices
                    Aspose.Imaging.Point[] points = new Aspose.Imaging.Point[]
                    {
                        new Aspose.Imaging.Point(100, 100),
                        new Aspose.Imaging.Point(400, 100),
                        new Aspose.Imaging.Point(250, 400)
                    };

                    // Fill the polygon with the brush
                    graphics.FillPolygon(brush, points);
                }

                // Save the image
                image.Save();
            }
        }
    }
}