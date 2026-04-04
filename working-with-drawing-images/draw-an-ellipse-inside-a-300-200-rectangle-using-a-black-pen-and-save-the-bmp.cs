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
        string outputPath = @"c:\temp\ellipse.bmp";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // Bind the output file to the image creation process
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image with dimensions at least the rectangle size
        using (Image image = Image.Create(bmpOptions, 300, 200))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Define a black pen (width 2)
            Pen pen = new Pen(Color.Black, 2);

            // Define the bounding rectangle (300 × 200)
            Rectangle rect = new Rectangle(0, 0, 300, 200);

            // Draw the ellipse inside the rectangle
            graphics.DrawEllipse(pen, rect);

            // Save the image (output path already set via FileCreateSource)
            image.Save();
        }
    }
}