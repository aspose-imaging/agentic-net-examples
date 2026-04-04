using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path for the BMP image
        string outputPath = @"c:\temp\ellipse_dash.bmp";

        // Ensure the output directory exists (unconditional as required)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false) // false = not temporary
        };

        // Create a new image of size 500x500
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear background with a solid color (e.g., Wheat)
            graphics.Clear(Color.Wheat);

            // Create a pen with custom dash pattern
            Pen dashPen = new Pen(Color.Blue, 3);
            dashPen.DashPattern = new float[] { 10f, 5f, 2f, 5f }; // dash, space, dash, space

            // Define the bounding rectangle for the ellipse
            RectangleF ellipseRect = new RectangleF(100, 100, 300, 200);

            // Draw the ellipse using the custom dash pen
            graphics.DrawEllipse(dashPen, ellipseRect);

            // Save changes to the file
            image.Save();
        }
    }
}