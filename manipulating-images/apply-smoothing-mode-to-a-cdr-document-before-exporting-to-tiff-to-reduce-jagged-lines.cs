// HOW-TO: Apply Anti-Aliasing to CDR When Converting to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "sample_output.tiff";

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
            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for CDR
                var rasterOptions = new CdrRasterizationOptions
                {
                    // Apply anti‑aliasing to reduce jagged lines
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Preserve original size
                    PageSize = image.Size,
                    // Optional: set a white background
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Prepare TIFF save options and attach rasterization options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate high‑quality printable TIFF files from CorelDRAW (CDR) graphics without jagged edges.
 * 2. When a reporting system must embed vector‑based CDR logos into TIFF images for PDF export while preserving smooth lines.
 * 3. When an e‑commerce platform converts product illustrations stored as CDR into TIFF thumbnails and wants anti‑aliasing to improve visual appearance.
 * 4. When a document archiving workflow rasterizes CDR drawings to TIFF for long‑term storage and requires consistent smoothing across pages.
 * 5. When a desktop application batch‑processes CDR files to TIFF for OCR preprocessing and needs anti‑aliased output to enhance text recognition accuracy.
 */
