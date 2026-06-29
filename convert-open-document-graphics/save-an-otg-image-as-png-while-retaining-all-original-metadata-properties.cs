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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Configure rasterization so the vector OTG content is rendered correctly
                var otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRaster;

                // Preserve metadata (metadata is kept by default; explicit assignment shown for clarity)
                // pngOptions.Metadata = image.Metadata; // Uncomment if explicit metadata transfer is required

                // Save the image as PNG
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
 * 1. When a developer needs to convert OpenDocument graphics (OTG) files to PNG for web display while preserving embedded metadata such as author and creation date.
 * 2. When an automated image processing pipeline must rasterize vector OTG diagrams into pixel‑perfect PNG thumbnails without losing the original size or metadata.
 * 3. When a document management system imports OTG illustrations and stores them as PNG assets for browser compatibility, ensuring all metadata is retained for audit trails.
 * 4. When a C# desktop application generates reports that include OTG charts and must export them as PNG images for inclusion in PDFs while keeping the original metadata intact.
 * 5. When a batch conversion tool processes a folder of OTG files, converting each to PNG with the same dimensions and preserving metadata for downstream indexing or search.
 */