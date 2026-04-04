using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = "Output\\example.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background
            graphics.Clear(Color.White);

            // Draw the first ellipse
            graphics.DrawEllipse(new Pen(Color.Blue, 3), new RectangleF(100, 100, 300, 200));

            // Apply a rotation transform (45 degrees)
            graphics.RotateTransform(45);

            // Draw a rectangle after rotation
            graphics.DrawRectangle(new Pen(Color.Red, 3), new RectangleF(150, 150, 200, 100));

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}