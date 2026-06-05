using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
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

        try
        {
            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Create a Point at (100, 200) for overlay positioning
                Point overlayPosition = new Point(100, 200);

                // Example overlay: draw a red circle centered at the point
                Graphics graphics = new Graphics(image);
                int radius = 20;
                Rectangle ellipseRect = new Rectangle(
                    overlayPosition.X - radius,
                    overlayPosition.Y - radius,
                    radius * 2,
                    radius * 2);
                graphics.DrawEllipse(new Pen(Color.Red, 3), ellipseRect);

                // Save the modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}