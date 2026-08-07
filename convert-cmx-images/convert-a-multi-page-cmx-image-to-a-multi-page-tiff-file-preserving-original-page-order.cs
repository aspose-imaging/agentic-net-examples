using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Load the multi‑page CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Configure vector rasterization to render each CMX page
                tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                // Save all pages as a multi‑page TIFF preserving order
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
 * 1. When a developer needs to archive legacy multi‑page CMX drawings into a widely supported multi‑page TIFF for long‑term storage or compliance.
 * 2. When a printing workflow requires converting CMX vector pages to raster TIFF pages while preserving the original page order for accurate pagination.
 * 3. When a document management system must ingest CMX files and store them as TIFFs to enable thumbnail generation and preview in web browsers.
 * 4. When a batch processing tool automates the migration of engineering schematics from CMX to TIFF to integrate with OCR or image analysis pipelines.
 * 5. When a C# application needs to export multi‑page CMX artwork to a single TIFF file for easy sharing with clients who only have TIFF viewers.
 */