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
        // Hard‑coded output path
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options (24‑bit)
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new BMP image of size 300x200 pixels
        using (Image image = Image.Create(bmpOptions, 300, 200))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background to a visible colour
            graphics.Clear(Color.Wheat);

            // Create a pen with black colour and 10‑pixel width
            Pen pen = new Pen(Color.Black, 10);

            // Set pen alignment to Inset to draw the border inside the rectangle bounds
            pen.Alignment = PenAlignment.Inset;

            // Draw a rectangle at (20,20) with width 260 and height 160
            graphics.DrawRectangle(pen, 20, 20, 260, 160);

            // Save the image (the file was already created by FileCreateSource)
            image.Save();
        }
    }
}