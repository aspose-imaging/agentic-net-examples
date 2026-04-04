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
        // Define output path (hardcoded)
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with 32 bits per pixel to support alpha
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 32;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image with desired dimensions
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Draw a black rectangle
            graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 150));

            // Create a semi‑transparent red brush (opacity 0.5)
            using (SolidBrush ellipseBrush = new SolidBrush(Color.Red))
            {
                ellipseBrush.Opacity = 0.5f; // 0 = fully visible, 1 = fully opaque

                // Fill an ellipse over the rectangle
                graphics.FillEllipse(ellipseBrush, new Rectangle(100, 80, 200, 150));
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}