using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP creation options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new BMP image with the specified size
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Define a pen for the rectangle outline
            Pen outlinePen = new Pen(Color.Blue, 2);
            // Draw rectangle outline at (50,50) with width 300 and height 200
            graphics.DrawRectangle(outlinePen, 50, 50, 300, 200);

            // Define a solid brush for filling
            SolidBrush fillBrush = new SolidBrush(Color.LightGreen);
            // Fill the same rectangle area
            graphics.FillRectangle(fillBrush, new Rectangle(50, 50, 300, 200));

            // Save the image to the hardcoded path
            image.Save(outputPath);
        }
    }
}