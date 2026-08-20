// HOW-TO: How To Rasterize WMF To JPEG At 300 DPI In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample_300dpi.jpg";

            // Verify that the input WMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for WMF
                var rasterOptions = new WmfRasterizationOptions
                {
                    // Use the original image size as the page size
                    PageSize = image.Size
                };

                // Set JPEG save options with 300 DPI resolution
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // 300 DPI for both horizontal and vertical axes
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert vector WMF graphics into high‑resolution JPEG files for printing brochures, you can set the DPI to 300 using Aspose.Imaging.
 * 2. When a desktop publishing workflow requires embedding WMF logos into PDF or Word documents as JPEG images with print‑ready resolution, this code ensures the correct DPI.
 * 3. When an automated batch process must generate web‑ready thumbnails from WMF files while preserving detail for large‑format displays, the 300 DPI setting provides sharper results.
 * 4. When a legacy engineering application stores schematics as WMF and you must export them to JPEG for archival on a high‑resolution scanner, the code guarantees proper scaling.
 * 5. When a C# service creates product catalogs and needs to rasterize WMF icons to JPEG at 300 DPI to meet printer specifications, this approach handles the conversion reliably.
 */
