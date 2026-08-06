using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Configure TIFF options with 8 bits per sample (8‑bit per channel)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Photometric = TiffPhotometrics.Rgb;

                // Save as TIFF using the specified options
                cmx.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to integrate legacy CorelDRAW CMX drawings into a modern document workflow that only accepts TIFF images with an 8‑bit per channel color depth.
 * 2. When an automated batch‑processing service must convert uploaded CMX files to 8‑bit RGB TIFF files for archival in a document management system that requires lossless raster format.
 * 3. When a web application generates printable reports and must render CMX vector graphics as 8‑bit per sample TIFFs to ensure compatibility with printers that support only TIFF output.
 * 4. When a migration script moves assets from a design repository to a GIS platform that consumes TIFF rasters with 8‑bit color depth, requiring conversion from CMX.
 * 5. When a QA tool validates that CMX artwork can be displayed correctly on low‑color‑depth devices by converting it to an 8‑bit per channel TIFF for visual comparison.
 */