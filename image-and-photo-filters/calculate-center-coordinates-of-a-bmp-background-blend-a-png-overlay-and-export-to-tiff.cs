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
            string bmpPath = "background.bmp";
            string pngPath = "overlay.png";
            string outputPath = "output/result.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Validate input files
            if (!File.Exists(bmpPath))
            {
                Console.Error.WriteLine($"File not found: {bmpPath}");
                return;
            }
            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            // Load images
            using (RasterImage background = (RasterImage)Image.Load(bmpPath))
            using (RasterImage overlay = (RasterImage)Image.Load(pngPath))
            {
                // Calculate center position
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;

                // Blend overlay onto background with full opacity
                background.Blend(new Point(offsetX, offsetY), overlay, 255);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When a developer needs to place a PNG logo at the exact center of a BMP background and export the composite as a high‑resolution TIFF for printing.
 * 2. When an application must combine a scanned BMP document with a transparent PNG watermark, aligning it centrally before saving to a lossless TIFF file.
 * 3. When a GIS system requires overlaying a satellite PNG tile onto a BMP map canvas, centering it and storing the result as a TIFF for further spatial analysis.
 * 4. When a medical imaging workflow needs to merge a BMP scan background with a PNG annotation layer, positioning it in the middle and outputting a TIFF for archival compliance.
 * 5. When an e‑commerce platform wants to generate product catalog images by centering a PNG badge on a BMP product photo and saving the final image as a TIFF for high‑quality catalog printing.
 */