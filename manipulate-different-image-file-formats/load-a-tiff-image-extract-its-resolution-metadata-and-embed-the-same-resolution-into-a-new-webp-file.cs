using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access resolution properties
                TiffImage tiff = (TiffImage)image;
                double dpiX = tiff.HorizontalResolution;
                double dpiY = tiff.VerticalResolution;

                // Apply the same resolution (optional, ensures it is set)
                tiff.SetResolution(dpiX, dpiY);

                // Prepare WebP save options
                WebPOptions webpOptions = new WebPOptions();

                // Save as WebP preserving the resolution metadata
                image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert high‑resolution scanned TIFF documents to WebP for web delivery while preserving the original DPI settings, this code can be used.
 * 2. When a photo‑editing application must retain the physical size information of a TIFF image after exporting it as a WebP file, the snippet extracts and re‑applies the resolution metadata.
 * 3. When an e‑commerce platform wants to generate lightweight WebP thumbnails from product TIFF images without losing print‑ready resolution data, the example shows how to do it in C# with Aspose.Imaging.
 * 4. When a GIS or mapping tool processes georeferenced TIFF raster data and needs to keep the pixel‑per‑inch metadata intact in a WebP export, this code provides the necessary steps.
 * 5. When a digital asset management system automates batch conversion of archival TIFF files to WebP while ensuring the stored resolution values remain accurate for downstream workflows, the code demonstrates the required operations.
 */