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
        // Output file path (hardcoded)
        string outputPath = "output\\filled_polygon.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (400x400)
        using (Image image = Image.Create(pngOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White); // optional background clear

            // Define polygon vertices
            Point[] polygonPoints = new Point[]
            {
                new Point(50, 50),
                new Point(350, 50),
                new Point(300, 300),
                new Point(100, 300)
            };

            // Create a solid brush with the desired fill color
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Blue;
                brush.Opacity = 100; // fully opaque

                // Fill the polygon
                graphics.FillPolygon(brush, polygonPoints);
            }

            // Save the image (source is already bound to the output file)
            image.Save();
        }
    }
}