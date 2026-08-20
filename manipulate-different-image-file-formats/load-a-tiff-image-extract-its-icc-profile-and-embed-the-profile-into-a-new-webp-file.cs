// HOW-TO: Convert TIFF to WebP While Preserving ICC Profile in C# (Aspose.Imaging for .NET)
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
                // Extract ICC profile from the TIFF image if present
                MemoryStream iccProfile = null;
                if (tiffImage is TiffImage tiff)
                {
                    var originalOptions = tiff.GetOriginalOptions() as TiffOptions;
                    iccProfile = originalOptions?.IccProfile;
                }

                var webpOptions = new WebPOptions
                {
                    KeepMetadata = true
                };

                // Save the image as WebP; metadata (including ICC profile) is kept if supported
                tiffImage.Save(outputPath, webpOptions);
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
 * 1. When you need to serve high‑quality web images from legacy TIFF assets while keeping accurate color reproduction.
 * 2. When a photo‑editing application must export user‑edited TIFF files to WebP for faster page loads without losing embedded ICC data.
 * 3. When an e‑commerce platform converts product scans stored as TIFF into WebP thumbnails and wants the colors to match the original prints.
 * 4. When a digital asset management system migrates archival TIFF images to WebP format and must retain their color profiles for consistent viewing.
 * 5. When a mobile app downloads TIFF graphics, converts them to WebP to reduce bandwidth, and ensures the embedded ICC profile is preserved for correct display.
 */
