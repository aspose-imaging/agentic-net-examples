using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hard‑coded)
        string outputPath = @"C:\temp\smooth_curve.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a bound file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Canvas dimensions
        int width = 800;
        int height = 600;

        // Create the image bound to the output file
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Pen with rounded line caps for smooth curves
            Pen pen = new Pen(Color.Blue, 4);
            pen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Flat);

            // Points defining the curve
            Point[] points = new Point[]
            {
                new Point(100, 500),
                new Point(200, 100),
                new Point(400, 300),
                new Point(600, 150),
                new Point(700, 450)
            };

            // Draw the smooth curve
            graphics.DrawCurve(pen, points);

            // Save the bound image
            image.Save();
        }
    }
}