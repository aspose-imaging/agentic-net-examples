// HOW-TO: Resize Animated WebP to Half Size and Save as APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load animated WebP
            using (WebPImage webp = new WebPImage(inputPath))
            {
                // Calculate half dimensions
                int newWidth = webp.Width / 2;
                int newHeight = webp.Height / 2;

                if (newWidth > 0 && newHeight > 0)
                {
                    // Resize all frames
                    webp.Resize(newWidth, newHeight);
                }

                // Save as APNG with default options
                webp.Save(outputPath, new ApngOptions());
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
 * 1. When you need to shrink an animated WebP banner for faster loading on mobile and deliver it as an APNG for broader browser compatibility.
 * 2. When converting user‑uploaded animated WebP stickers to a smaller APNG size for use in a chat application that only supports APNG.
 * 3. When preparing animated WebP assets for an email newsletter by reducing their dimensions and changing the format to APNG to meet email client restrictions.
 * 4. When optimizing animated WebP icons for a game UI, resizing them to half their original size and saving as APNG to match the engine’s texture requirements.
 * 5. When batch‑processing a library of animated WebP files to create lightweight APNG versions for a documentation site that prefers PNG sequences.
 */
