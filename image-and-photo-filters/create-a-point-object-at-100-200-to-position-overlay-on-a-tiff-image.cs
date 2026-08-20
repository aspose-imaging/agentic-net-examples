// HOW-TO: Add Red Circle Overlay to TIFF at Specific Coordinates in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create a Point at (100, 200) for overlay positioning
                Point overlayPoint = new Point(100, 200);

                // Draw a simple overlay (red circle) at the specified point
                Graphics graphics = new Graphics(tiffImage);
                Pen pen = new Pen(Color.Red, 5);
                int radius = 20;
                Rectangle ellipseRect = new Rectangle(overlayPoint.X - radius, overlayPoint.Y - radius, radius * 2, radius * 2);
                graphics.DrawEllipse(pen, ellipseRect);

                // Save the modified TIFF image
                tiffImage.Save();
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
 * 1. When you need to mark a precise location on a scanned document by drawing a colored circle on a TIFF file using C#.
 * 2. When you want to programmatically add a visual indicator at (100,200) to highlight a defect in a high‑resolution TIFF image.
 * 3. When you are building a .NET service that annotates medical or engineering TIFF images with overlay graphics at known pixel coordinates.
 * 4. When you must generate watermarked TIFF files that include a red circle at a fixed point for quality‑control tracking.
 * 5. When you require a simple way to overlay shapes on multi‑page TIFFs for automated report generation in C#.
 */
