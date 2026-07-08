using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "thumbnail.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Save the image (or thumbnail) as WebP
                raster.Save(outputPath, new WebPOptions());
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
 * 1. When a C# developer needs to extract an embedded thumbnail from a high‑resolution TIFF file using Aspose.Imaging and save it as a lightweight WebP image for faster web page loading.
 * 2. When a document management system built in .NET must generate preview images from scanned TIFF documents and store the thumbnails in WebP format to reduce storage costs.
 * 3. When a photo‑archiving application requires converting the small preview embedded in a TIFF into a separate WebP file for display in mobile galleries using RasterImage and WebPOptions.
 * 4. When an e‑commerce platform wants to programmatically extract product thumbnails from supplier‑provided TIFF files and serve them as WebP images to improve SEO and page speed.
 * 5. When a batch‑processing script in C# validates the existence of a TIFF file, extracts its thumbnail with Aspose.Imaging, and saves it as a WebP file for downstream image‑analysis pipelines.
 */