using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Create a graphics object for drawing
            var graphics = new Graphics(image);

            // Create a Point at (100, 200) to position the overlay
            var overlayPoint = new Point(100, 200);

            // Define a small ellipse centered at the point
            var ellipseRect = new Rectangle(overlayPoint.X - 10, overlayPoint.Y - 10, 20, 20);

            // Draw the ellipse with a red pen
            graphics.DrawEllipse(new Pen(Color.Red, 2), ellipseRect);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}