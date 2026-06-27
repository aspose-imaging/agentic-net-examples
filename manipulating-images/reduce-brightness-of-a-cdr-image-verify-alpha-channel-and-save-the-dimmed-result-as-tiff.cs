using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "dimmed_output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize CDR to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new StreamSource(ms),
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Verify alpha channel presence
                        bool hasAlpha = raster.HasAlpha;
                        Console.WriteLine($"Alpha channel present: {hasAlpha}");

                        // Reduce brightness (negative value dims the image)
                        raster.AdjustBrightness(-50);

                        // Save as TIFF
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) vector file to a high‑resolution TIFF for print production while confirming that the image contains an alpha channel, they can use this Aspose.Imaging C# code to rasterize, check transparency, dim the artwork, and save the result.
 * 2. When an e‑commerce platform wants to automatically generate darker preview images of product designs stored as CDR files and ensure the previews retain transparency before publishing them as TIFF assets, this code provides the necessary brightness adjustment and alpha verification.
 * 3. When a digital asset management system must ingest legacy CDR graphics, reduce their brightness to meet branding guidelines, and store them in a lossless TIFF format with confirmed alpha support, the sample demonstrates the complete workflow in C#.
 * 4. When a UI/UX team needs to programmatically dim vector icons saved in CDR, verify they still contain an alpha channel for overlay effects, and export them as TIFFs for inclusion in high‑DPI mockups, this snippet handles the rasterization and processing steps.
 * 5. When a batch‑processing script is required to prepare archival copies of CDR artwork by lowering brightness to protect sensitive details, checking for transparency, and converting the files to TIFF for long‑term storage, developers can reuse this Aspose.Imaging C# example.
 */