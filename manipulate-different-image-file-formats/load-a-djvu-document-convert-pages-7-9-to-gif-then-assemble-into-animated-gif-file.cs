// HOW-TO: Create Animated GIF from Specific DjVu Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output paths (relative)
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\animated.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (var stream = File.OpenRead(inputPath))
            using (var djvu = new DjvuImage(stream))
            {
                // Configure GIF options to export pages 7‑9 (zero‑based indexes 6,7,8)
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 6, 7, 8 })
                };

                // Save as animated GIF
                djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a subset of pages from a DjVu document and present them as a looping animated GIF for web previews.
 * 2. When generating animated thumbnails of selected DjVu pages for a document management system using C# and Aspose.Imaging.
 * 3. When creating a lightweight, cross‑platform animation from scanned book pages stored in DjVu format for mobile apps.
 * 4. When automating the conversion of specific DjVu pages (e.g., pages 7‑9) into a single GIF file to embed in email newsletters.
 * 5. When building a batch process that converts multiple DjVu files into animated GIFs showing only the most relevant pages for user tutorials.
 */
