using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\ellipse.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options (24 bits per pixel)
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new BMP image of size 300x300
        using (Image image = Image.Create(bmpOptions, 300, 300))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define the bounding rectangle for the ellipse
            Rectangle ellipseRect = new Rectangle(50, 50, 200, 200);

            // Create a solid red brush for filling
            SolidBrush fillBrush = new SolidBrush(Color.Red);
            fillBrush.Opacity = 100; // Fully opaque

            // Fill the ellipse
            graphics.FillEllipse(fillBrush, ellipseRect);

            // Create a black pen for the outline
            Pen outlinePen = new Pen(Color.Black, 2);

            // Draw the ellipse outline
            graphics.DrawEllipse(outlinePen, ellipseRect);

            // Save the image to the specified path
            image.Save();
        }
    }
}