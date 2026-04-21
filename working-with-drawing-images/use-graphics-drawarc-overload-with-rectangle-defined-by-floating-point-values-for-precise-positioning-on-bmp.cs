using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\arc_output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options (24‑bit)
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24
        };

        // Create a new 500x500 image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background to white
            graphics.Clear(Color.White);

            // Pen with blue color and 2‑pixel width
            Pen pen = new Pen(Color.Blue, 2);

            // RectangleF with floating‑point coordinates for precise positioning
            RectangleF rect = new RectangleF(50.5f, 50.5f, 300.75f, 200.25f);

            // Draw an arc: start at 45°, sweep 270°
            graphics.DrawArc(pen, rect, 45f, 270f);

            // Save the resulting BMP image
            image.Save(outputPath);
        }
    }
}