using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path (hard‑coded)
        string outputPath = @"c:\temp\customlogo.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (400x300)
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Fill background with white
            graphics.Clear(Color.White);

            // Draw outer rectangle (black border)
            Pen blackPen = new Pen(Color.Black, 3);
            graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 200));

            // Draw inner ellipse (red border)
            Pen redPen = new Pen(Color.Red, 2);
            graphics.DrawEllipse(redPen, new Rectangle(100, 80, 200, 140));

            // Draw inner rectangle (blue border)
            Pen bluePen = new Pen(Color.Blue, 2);
            graphics.DrawRectangle(bluePen, new Rectangle(120, 100, 160, 100));

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}