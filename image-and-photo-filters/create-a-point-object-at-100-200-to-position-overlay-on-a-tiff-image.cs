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

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Create a Point at (100, 200) for overlay positioning
                Point overlayPoint = new Point(100, 200);

                // Example overlay: draw a red rectangle at the point
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Red, 3);
                Rectangle rect = new Rectangle(overlayPoint.X, overlayPoint.Y, 50, 50);
                graphics.DrawRectangle(pen, rect);

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to place a branding watermark or logo at the fixed coordinates (100,200) on a TIFF image using Aspose.Imaging for .NET.
 * 2. When generating printable forms that require a red rectangle to highlight a specific field on a scanned TIFF document at pixel position (100,200).
 * 3. When adding a GIS marker or annotation to a raster TIFF map by creating a Point overlay at (100,200) with C# graphics drawing.
 * 4. When building a document management workflow that stamps a verification box onto each TIFF page at the exact location (100,200).
 * 5. When automating quality‑control reports that draw a red bounding box around a defect region on a TIFF scan positioned at (100,200).
 */