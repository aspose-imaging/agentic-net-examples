// HOW-TO: Overlay PNG onto TIFF at Specific Coordinates Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputTiffPath = "input.tif";
        string overlayPath = "overlay.png";
        string outputPath = "output.tif";

        if (!File.Exists(inputTiffPath))
        {
            Console.Error.WriteLine($"File not found: {inputTiffPath}");
            return;
        }

        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage background = (RasterImage)Image.Load(inputTiffPath))
            {
                using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                {
                    Point position = new Point(100, 200);
                    background.Blend(position, overlay, overlay.Bounds, 127);
                }

                Source outSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = outSource };
                background.Save(outputPath, tiffOptions);
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
 * 1. When you need to add a logo or watermark at a fixed position on a multi‑page TIFF document.
 * 2. When you want to programmatically merge a transparent PNG overlay onto a scanned TIFF image for report generation.
 * 3. When you must place a signature image at exact X‑Y coordinates on a TIFF file before archiving.
 * 4. When you are creating composite images by blending a PNG graphic onto a TIFF background with custom opacity in a C# application.
 * 5. When you need to automate the placement of a template overlay on TIFF maps for GIS or printing workflows.
 */
