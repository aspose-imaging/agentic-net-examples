using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

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
                // Configure GIF compression using MaxDiff (higher value = more lossy compression)
                var gifOptions = new GifOptions
                {
                    MaxDiff = 80 // recommended value for optimal lossy compression
                };

                // Save the image as a GIF with the specified compression options
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert high‑resolution WebP graphics to static or animated GIFs for legacy browsers while minimizing the resulting file size by adjusting the MaxDiff compression level.
 * 2. When an e‑commerce platform must generate lightweight product GIF previews from WebP assets to improve page load speed on mobile devices.
 * 3. When a marketing automation tool creates email‑friendly GIF banners from WebP images and must keep the attachment size under a specific limit.
 * 4. When a content management system processes user‑uploaded WebP photos and stores them as compressed GIFs for compatibility with older image viewers.
 * 5. When a game developer exports sprite sheets originally saved as WebP into GIF format for use in legacy game engines that only support GIF, requiring lossy compression to fit within memory constraints.
 */