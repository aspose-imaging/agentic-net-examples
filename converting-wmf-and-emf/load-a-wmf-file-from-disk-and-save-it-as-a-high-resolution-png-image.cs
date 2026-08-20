// HOW-TO: Convert WMF to High Resolution PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to WmfImage to access size
                WmfImage wmfImage = (WmfImage)image;

                // Set up PNG save options with vector rasterization for high resolution
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        // Use the original WMF size; you can adjust DPI or page size here for higher resolution
                        PageSize = wmfImage.Size,
                        // Example of increasing resolution (optional)
                        // DpiX = 300,
                        // DpiY = 300
                    }
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
 * 1. When you need to display legacy WMF vector graphics on web pages that only support raster formats like PNG.
 * 2. When you must generate printable PNG assets from WMF files at a specific DPI for high‑quality print output.
 * 3. When a batch conversion tool has to preserve the original dimensions of WMF drawings while converting them to PNG for archival.
 * 4. When an application imports WMF icons and needs to render them as PNG thumbnails for UI galleries.
 * 5. When a reporting system extracts WMF charts from old documents and converts them to PNG to embed in PDF reports.
 */
