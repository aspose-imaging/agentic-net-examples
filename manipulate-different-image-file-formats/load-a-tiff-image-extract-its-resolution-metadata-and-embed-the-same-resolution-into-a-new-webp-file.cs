// HOW-TO: Preserve TIFF Resolution When Saving As WebP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\sample.tif";
            string outputPath = @"C:\temp\sample.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access resolution properties
                TiffImage tiffImage = (TiffImage)image;

                // Extract horizontal and vertical DPI
                double dpiX = tiffImage.HorizontalResolution;
                double dpiY = tiffImage.VerticalResolution;

                // Apply the same resolution to the image before saving
                tiffImage.SetResolution(dpiX, dpiY);

                // Prepare WebP save options (default settings)
                WebPOptions webpOptions = new WebPOptions();

                // Save as WebP with the embedded resolution
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
 * 1. When you need to convert scanned TIFF documents to WebP while keeping the original DPI for accurate print sizing.
 * 2. When a web application generates thumbnails from high‑resolution TIFF files and must retain resolution metadata in the WebP output for downstream processing.
 * 3. When migrating a digital asset library from TIFF to WebP and want to preserve image resolution for consistent display across devices.
 * 4. When creating responsive images for e‑commerce sites, ensuring the WebP version maintains the same DPI as the source TIFF to avoid scaling issues.
 * 5. When automating batch conversion of medical imaging TIFFs to WebP and need to embed the original resolution for compliance with imaging standards.
 */
