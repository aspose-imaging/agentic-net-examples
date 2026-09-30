// HOW-TO: Convert Multi‑Page CMX to Single‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page CMX image
            using (Image cmxImage = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    // Export all pages; MultiPageOptions defaults to all pages
                    MultiPageOptions = new MultiPageOptions()
                };

                // Save as a single TIFF file containing all pages
                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive multi‑page CorelDRAW CMX drawings as a single TIFF file for easy viewing or printing.
 * 2. When a document management system only accepts TIFF images and you must combine all CMX pages into one file before upload.
 * 3. When generating a PDF‑like preview of a CMX project and you want to merge its pages into a single raster image for downstream processing.
 * 4. When automating batch conversion of legacy CMX artwork to a format supported by Windows printers that require single‑page TIFFs.
 * 5. When integrating CMX files into a medical imaging workflow that expects a single multi‑frame TIFF for analysis.
 */
