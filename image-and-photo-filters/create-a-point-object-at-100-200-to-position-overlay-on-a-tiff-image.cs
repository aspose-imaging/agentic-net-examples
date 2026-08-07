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
        try
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
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(tiffImage);

                // Create the overlay point at (100, 200)
                Point overlayPoint = new Point(100, 200);

                // Example overlay: draw a red ellipse centered at the point
                int ellipseRadius = 20;
                Rectangle ellipseBounds = new Rectangle(
                    overlayPoint.X - ellipseRadius,
                    overlayPoint.Y - ellipseRadius,
                    ellipseRadius * 2,
                    ellipseRadius * 2);

                Pen redPen = new Pen(Color.Red, 5);
                graphics.DrawEllipse(redPen, ellipseBounds);

                // Save the modified image with TIFF options
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When a developer uses Aspose.Imaging for .NET to add a watermark or logo at a specific (100,200) coordinate on a TIFF document before printing or archiving.
 * 2. When a GIS application built with C# and Aspose.Imaging for .NET must mark an exact location on a scanned map stored as a TIFF by drawing a red ellipse at point (100,200).
 * 3. When an e‑commerce platform needs to highlight a product defect area on a high‑resolution TIFF photograph by overlaying a red shape at the (100,200) pixel position using Aspose.Imaging.
 * 4. When a medical imaging system automates annotation of a radiology TIFF image with a visual cue at a calibrated point (100,200) via Aspose.Imaging's Graphics API.
 * 5. When a document management workflow programmatically places a signature stamp at a fixed offset (100,200) on scanned TIFF contracts using Aspose.Imaging for .NET before saving the final file.
 */