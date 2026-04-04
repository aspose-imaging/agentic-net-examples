using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\arc_output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP creation options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Define a blue pen with 2-pixel width
            Pen pen = new Pen(Color.Blue, 2);

            // Define the rectangle that bounds the ellipse
            Rectangle rect = new Rectangle(50, 50, 200, 200);

            // Draw a 90-degree arc starting at 0 degrees
            graphics.DrawArc(pen, rect, 0, 90);

            // Save the image to the specified file
            image.Save();
        }
    }
}