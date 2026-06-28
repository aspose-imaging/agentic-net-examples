using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.webp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 800x600 using nearest‑neighbour resampling
                image.Resize(800, 600, ResizeType.NearestNeighbourResample);

                // Prepare lossless WebP options
                var webpOptions = new WebPOptions { Lossless = true };

                // Save as WebP
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer uses the Aspose.Imaging library to generate optimized, lossless WebP thumbnails from user‑uploaded PNG graphics at 800 × 600 pixels for faster page loads.
 * 2. When an e‑commerce platform employs Aspose.Imaging for .NET to convert product PNG images to a standard 800 × 600 size and save them as lossless WebP to reduce bandwidth while preserving quality.
 * 3. When a mobile‑app backend processes PNG assets with Aspose.Imaging, resizing them to 800 × 600 and exporting lossless WebP files for consistent display on all devices.
 * 4. When a content‑management system automates batch conversion of PNG banners using Aspose.Imaging, resizing each to 800 × 600 and storing them as lossless WebP to meet design guidelines.
 * 5. When a digital‑marketing tool leverages Aspose.Imaging to resize PNG logos to 800 × 600 and save them as lossless WebP for email campaigns that support the WebP format.
 */