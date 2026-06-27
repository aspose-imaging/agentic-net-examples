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
        try
        {
            // Hardcoded input and output paths
            string inputBmpPath = @"C:\Images\background.bmp";
            string inputPngPath = @"C:\Images\overlay.png";
            string outputTiffPath = @"C:\Images\result.tif";

            // Validate input files
            if (!File.Exists(inputBmpPath))
            {
                Console.Error.WriteLine($"File not found: {inputBmpPath}");
                return;
            }
            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Load background BMP and overlay PNG
            using (RasterImage background = (RasterImage)Image.Load(inputBmpPath))
            using (RasterImage overlay = (RasterImage)Image.Load(inputPngPath))
            {
                // Calculate center position
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;

                // Blend overlay onto background at center
                background.Blend(new Point(offsetX, offsetY), overlay, 255);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputTiffPath, false)
                };

                // Save the blended image as TIFF
                background.Save(outputTiffPath, tiffOptions);
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
 * 1. When a developer needs to place a company logo (PNG) at the exact center of a high‑resolution BMP background and deliver the final composite as a lossless TIFF for printing.
 * 2. When an application must combine a scanned BMP document with a transparent PNG watermark, calculate the center offset, blend them, and export the result to a TIFF archive.
 * 3. When a GIS tool requires overlaying a PNG map layer onto a BMP terrain image, centering it automatically before saving the output in TIFF format for further analysis.
 * 4. When an e‑commerce platform generates product mock‑ups by centering a PNG design over a BMP template and needs the final image in TIFF to meet catalog specifications.
 * 5. When a medical imaging system merges a PNG annotation onto a BMP radiograph, aligns it to the center, and stores the blended image as a TIFF for compliance with DICOM workflows.
 */