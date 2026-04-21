using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

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

        // Load the TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Create a Point at (100, 200) for overlay positioning
            Point overlayPoint = new Point(100, 200);

            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(tiffImage);

            // Example overlay: draw a red circle centered at the point
            Pen pen = new Pen(Color.Red, 5);
            Rectangle circleBounds = new Rectangle(overlayPoint.X - 10, overlayPoint.Y - 10, 20, 20);
            graphics.DrawEllipse(pen, circleBounds);

            // Save the modified image
            tiffImage.Save(outputPath);
        }
    }
}