using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image with the specified dimensions
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the background
            graphics.Clear(Color.Wheat);

            // Draw the first ellipse
            graphics.DrawEllipse(new Pen(Color.Black, 2), new RectangleF(50, 50, 300, 300));

            // Apply a rotation transform (45 degrees)
            graphics.RotateTransform(45);

            // Draw a rectangle after rotation
            graphics.DrawRectangle(new Pen(Color.Red, 2), new RectangleF(150, 150, 200, 100));

            // Save the image (writes to the outputPath defined in FileCreateSource)
            image.Save();
        }
    }
}