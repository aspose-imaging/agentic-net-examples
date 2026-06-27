using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all TIFF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in files)
            {
                // Process only TIFF files
                string extension = Path.GetExtension(inputPath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                {
                    continue;
                }

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for watermark removal
                    RasterImage raster = (RasterImage)image;

                    // Create a mask covering the whole image (adjust as needed)
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
                    mask.AddFigure(figure);

                    // Configure Content Aware Fill options
                    var options = new ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };

                    // Remove watermark
                    using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                    {
                        // Save the processed image as TIFF
                        var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                        result.Save(outputPath, saveOptions);
                    }
                }
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
 * 1. When a scanning service needs to clean up scanned TIFF documents that contain printer watermarks before archiving them in a document management system.
 * 2. When a medical imaging workflow must remove hospital logo overlays from batches of TIFF X‑ray images to prepare them for AI analysis.
 * 3. When a publishing house wants to strip promotional watermarks from TIFF artwork files before sending them to print vendors.
 * 4. When a GIS department needs to eliminate map publisher watermarks from large collections of TIFF satellite tiles prior to spatial analysis.
 * 5. When a legal firm must batch‑process TIFF evidence files to erase confidential watermarks while preserving image quality for court submissions.
 */