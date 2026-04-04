using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"C:\temp\sharp_polygon.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 400x400 BMP image
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a pen with a high MiterLimit to preserve sharp angles
            Pen pen = new Pen(Color.Black, 5);
            pen.MiterLimit = 1000; // high value for sharp‑angled joins

            // Define points of a sharp‑angled polygon (star‑like shape)
            Point[] points = new Point[]
            {
                new Point(200, 50),
                new Point(210, 190),
                new Point(250, 200),
                new Point(210, 210),
                new Point(200, 350),
                new Point(190, 210),
                new Point(150, 200),
                new Point(190, 190)
            };

            // Draw the polygon
            graphics.DrawPolygon(pen, points);

            // Save the image (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}