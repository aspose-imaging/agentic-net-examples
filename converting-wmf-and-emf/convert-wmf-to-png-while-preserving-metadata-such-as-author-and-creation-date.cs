using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for WMF
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Configure PNG save options, preserving metadata
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    KeepMetadata = true
                };

                // Save as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) graphics to web‑friendly PNG images while keeping author and creation date metadata for archival purposes.
 * 2. When a C# application must batch‑process vector drawings from a design system and output high‑resolution PNG thumbnails that retain original metadata for downstream indexing.
 * 3. When an enterprise document management solution requires transforming embedded WMF diagrams into PNG format for preview in browsers, ensuring the original metadata is preserved for compliance audits.
 * 4. When a reporting tool generates charts as WMF files and then needs to embed them in PDF or HTML reports as PNG images without losing the source file’s metadata.
 * 5. When a migration script moves assets from an old Windows‑based graphics library to a modern .NET platform, converting each WMF to PNG while preserving metadata to maintain continuity in asset catalogs.
 */