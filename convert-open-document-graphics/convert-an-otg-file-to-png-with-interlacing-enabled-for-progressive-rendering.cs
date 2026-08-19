// HOW-TO: Convert OTG to PNG with Progressive Interlacing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.otg";
        string outputPath = "sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with progressive (interlaced) encoding
                PngOptions pngOptions = new PngOptions
                {
                    Progressive = true
                };

                // Configure rasterization to match the source size
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save as PNG with the specified options
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
 * 1. When a web application needs to display vector OTG graphics as fast‑loading PNGs that render progressively in browsers.
 * 2. When a batch processing tool must convert a library of OTG files to PNG while preserving image quality and enabling interlaced encoding for smoother user experience.
 * 3. When a mobile app requires rasterizing OTG diagrams into PNG assets with progressive rendering to reduce perceived loading time on slow networks.
 * 4. When an e‑learning platform wants to transform OTG illustrations into PNGs with interlacing so that students see partial images while the rest loads.
 * 5. When a reporting service generates PNG thumbnails from OTG charts and needs the files to be interlaced for better compatibility with image viewers.
 */
