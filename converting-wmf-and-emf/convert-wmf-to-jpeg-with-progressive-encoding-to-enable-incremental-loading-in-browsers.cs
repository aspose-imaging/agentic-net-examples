// HOW-TO: Convert WMF to Progressive JPEG for Browser Loading in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.jpg";

            // Verify that the source WMF file exists
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
                // Set up rasterization options so the vector WMF is rendered correctly
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure JPEG options for progressive encoding
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90, // Adjust quality as needed (1‑100)
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as a progressive JPEG
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
 * 1. When you need to display legacy WMF vector graphics on a web page that requires progressive JPEGs for faster incremental rendering.
 * 2. When converting corporate diagram files (WMF) to JPEG format while preserving quality and enabling browsers to show a low‑resolution preview before the full image loads.
 * 3. When automating a batch process that transforms WMF icons into progressive JPEGs for use in responsive email newsletters.
 * 4. When integrating a .NET service that serves images to mobile devices and wants progressive JPEGs to reduce perceived load time for WMF source files.
 * 5. When migrating a document management system that stores WMF files and you must generate web‑friendly progressive JPEG thumbnails on the fly.
 */
