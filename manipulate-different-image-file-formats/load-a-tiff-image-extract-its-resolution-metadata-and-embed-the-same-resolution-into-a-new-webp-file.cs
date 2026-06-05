using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)tiffImage;
                double dpiX = tiff.HorizontalResolution;
                double dpiY = tiff.VerticalResolution;

                WebPOptions options = new WebPOptions();
                options.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                tiffImage.Save(outputPath, options);
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
 * 1. When a developer needs to convert high‑resolution scanned TIFF documents to web‑friendly WebP images while preserving the original DPI for accurate print‑size rendering.
 * 2. When an e‑commerce platform must generate product thumbnails in WebP from supplier‑provided TIFF files and keep the original resolution metadata for consistent display across devices.
 * 3. When a GIS application converts georeferenced TIFF maps to lightweight WebP tiles and needs to retain the DPI information to maintain correct scale calculations.
 * 4. When a digital archiving system migrates archival TIFF scans to WebP for storage efficiency but must embed the original resolution so downstream workflows can still determine physical dimensions.
 * 5. When a mobile app processes user‑uploaded TIFF photos, converts them to WebP for faster upload, and ensures the embedded resolution matches the source to avoid distortion after resizing.
 */