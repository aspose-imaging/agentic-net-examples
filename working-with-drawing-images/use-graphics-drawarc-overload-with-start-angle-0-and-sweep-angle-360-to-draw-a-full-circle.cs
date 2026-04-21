using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\circle.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as the source
            PngOptions pngOptions = new PngOptions
            {
                Source = new StreamSource(stream)
            };

            // Create a new 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background with white color
                graphics.Clear(Color.White);

                // Create a black pen with width 2
                Pen pen = new Pen(Color.Black, 2);

                // Draw a full circle using DrawArc (startAngle = 0, sweepAngle = 360)
                // The rectangle defines the bounding box of the circle
                graphics.DrawArc(pen, new Rectangle(100, 100, 300, 300), 0, 360);

                // Save changes to the image (writes to the stream)
                image.Save();
            }
        }
    }
}