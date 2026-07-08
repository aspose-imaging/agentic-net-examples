using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9 // maximum compression
                };

                // Configure rasterization for vector OTG content
                var otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

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
 * 1. When a web application needs to display vector OTG graphics as raster PNG images with the smallest possible file size for faster page loads.
 * 2. When an e‑commerce platform must generate product thumbnails from OTG design files while preserving lossless quality and minimizing storage costs.
 * 3. When a mobile app synchronizes user‑created OTG drawings to a server that only accepts PNG files, requiring maximum compression to reduce bandwidth usage.
 * 4. When a document management system archives engineering diagrams originally saved as OTG by converting them to PNG with lossless compression for long‑term preservation.
 * 5. When a batch processing script prepares OTG assets for printing workflows that require PNG input, ensuring the images are rasterized at the original size and compressed to the highest level.
 */