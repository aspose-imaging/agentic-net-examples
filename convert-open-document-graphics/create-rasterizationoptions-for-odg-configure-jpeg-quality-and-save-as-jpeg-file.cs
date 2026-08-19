// HOW-TO: Convert ODG to JPEG with Custom Quality and Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size // preserve original size
                };

                // Configure JPEG save options with desired quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 90, // quality between 1 and 100
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a high‑quality JPEG preview of an OpenDocument Graphic (ODG) file in a .NET application.
 * 2. When you must preserve the original page dimensions while converting vector ODG drawings to raster JPEG images.
 * 3. When you want to control JPEG compression level (e.g., set quality to 90) during batch conversion of ODG assets.
 * 4. When your software has to ensure the output folder exists and handle missing ODG files gracefully before saving as JPEG.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded ODG diagrams to web‑friendly JPEG thumbnails.
 */
