// HOW-TO: Convert ODG to PNG with Metadata Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options to keep original metadata
                PngOptions pngOptions = new PngOptions
                {
                    KeepMetadata = true,
                    // Rasterization options required for vector ODG conversion
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    }
                };

                // Save the image as PNG while preserving metadata
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
 * 1. When you need to generate raster PNG previews of OpenDocument graphics for web display while keeping the original author and creation metadata.
 * 2. When a document management system must archive ODG drawings as PNG files without losing embedded metadata for compliance audits.
 * 3. When an automated batch process converts user‑uploaded ODG diagrams to PNG thumbnails and must retain metadata for later search indexing.
 * 4. When a reporting tool exports vector ODG charts to PNG images for inclusion in PDF reports while preserving source metadata.
 * 5. When a migration script moves legacy ODG assets to a PNG‑based asset pipeline and requires metadata to remain intact for asset tracking.
 */
