// HOW-TO: Detect Animated WebP and Convert to GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.webp";
            string outputPath = "c:\\temp\\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Check if the WebP image is animated (has more than one frame)
                bool isAnimated = false;
                if (webPImage is IMultipageImage multipage && multipage.PageCount > 1)
                {
                    isAnimated = true;
                }

                if (isAnimated)
                {
                    // Save the animated WebP as a GIF
                    webPImage.Save(outputPath, new GifOptions());
                }
                else
                {
                    Console.WriteLine("The WebP image is not animated. No GIF will be created.");
                }
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
 * 1. When you need to generate an animated GIF from a WebP animation for browsers that only support GIF.
 * 2. When validating user‑uploaded WebP files to ensure they contain animation before further processing.
 * 3. When creating thumbnails for a gallery and want to skip non‑animated WebP files.
 * 4. When converting animated WebP assets to GIF for use in email newsletters that require GIF format.
 * 5. When building a batch conversion tool that processes only animated WebP images to reduce unnecessary work.
 */
