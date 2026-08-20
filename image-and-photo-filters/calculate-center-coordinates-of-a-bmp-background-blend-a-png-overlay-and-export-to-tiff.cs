// HOW-TO: Center PNG Overlay on BMP Background and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string backgroundPath = @"C:\Images\background.bmp";
            string overlayPath = @"C:\Images\overlay.png";
            string outputPath = @"C:\Images\result.tif";

            // Validate input files
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background BMP and overlay PNG as raster images
            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Calculate top‑left point to center the overlay on the background
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;

                // Blend overlay onto background with full opacity
                background.Blend(new Point(offsetX, offsetY), overlay, 255);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the blended image as TIFF
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
 * 1. When you need to place a logo PNG at the exact center of a BMP template and output the result as a high‑resolution TIFF for printing.
 * 2. When generating composite images for a document workflow that requires blending a transparent PNG watermark onto a BMP background before archiving in TIFF format.
 * 3. When creating product mock‑ups where a PNG design must be centered on a BMP background and saved as a lossless TIFF for quality‑controlled catalogs.
 * 4. When automating the preparation of scanned BMP images with overlaid PNG annotations, ensuring the overlay is centered and the final file is stored as a TIFF.
 * 5. When developing a C# utility that merges a PNG overlay with a BMP canvas, calculates the correct offset, and exports the combined image to TIFF for downstream GIS or imaging applications.
 */
