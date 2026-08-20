// HOW-TO: Convert WebP to GIF with Adjustable Lossy Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.webp";
        string outputPath = @"C:\Images\output.gif";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF compression (lossy) to reduce file size
                GifOptions gifOptions = new GifOptions
                {
                    // MaxDiff > 0 enables lossy compression; 80 is a recommended value
                    MaxDiff = 80
                };

                // Save the image as GIF using the configured options
                image.Save(outputPath, gifOptions);
            }

            Console.WriteLine($"Conversion completed successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            // Report any error that occurs during processing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink animated GIFs generated from WebP assets for faster web page loading.
 * 2. When you must create low‑size GIF thumbnails from high‑resolution WebP images for email newsletters.
 * 3. When an application converts user‑uploaded WebP pictures to GIFs and must stay within a strict file‑size limit.
 * 4. When you want to batch‑process WebP graphics into GIFs with lossy compression to meet mobile bandwidth constraints.
 * 5. When integrating Aspose.Imaging in a C# service that delivers GIFs with reduced size for social‑media sharing.
 */
