using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options for a 24‑bit image
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // The FileCreateSource tells Aspose.Imaging to create the file at the specified path
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Fill background with a light color
            graphics.Clear(Color.Wheat);

            // Define the vertices of the polygon
            PointF[] polygonPoints = new PointF[]
            {
                new PointF(50, 50),
                new PointF(450, 50),
                new PointF(450, 450),
                new PointF(50, 450)
            };

            // Create a pen with custom line join style (Bevel) and a width of 5 pixels
            Pen pen = new Pen(Color.Blue, 5)
            {
                LineJoin = LineJoin.Bevel
            };

            // Draw the connected polygon using the pen
            graphics.DrawPolygon(pen, polygonPoints);

            // Persist changes to the file
            image.Save();
        }
    }
}