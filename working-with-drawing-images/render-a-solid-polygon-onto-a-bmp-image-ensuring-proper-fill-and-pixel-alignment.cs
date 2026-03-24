using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\polygon.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 400x400 BMP canvas
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define polygon vertices
            Point[] polygonPoints = new Point[]
            {
                new Point(100, 50),
                new Point(300, 50),
                new Point(350, 200),
                new Point(200, 350),
                new Point(50, 200)
            };

            // Fill the polygon with a solid blue brush
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                graphics.FillPolygon(brush, polygonPoints);
            }

            // Save the bound image (no need to specify path again)
            image.Save();
        }
    }
}