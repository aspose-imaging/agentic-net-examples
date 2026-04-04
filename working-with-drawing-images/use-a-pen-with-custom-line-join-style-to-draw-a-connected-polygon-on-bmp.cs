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
        string outputPath = @"C:\temp\polygon.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options and bind the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 400x400 image canvas
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a pen with custom line join style
            Pen pen = new Pen(Color.Blue, 3);
            pen.LineJoin = LineJoin.Bevel; // custom join (e.g., Bevel)

            // Define polygon vertices
            Point[] polygonPoints = new Point[]
            {
                new Point(50, 300),
                new Point(200, 50),
                new Point(350, 300),
                new Point(50, 200)
            };

            // Draw the connected polygon
            graphics.DrawPolygon(pen, polygonPoints);

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}