using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

        try
        {
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
                // Determine if the WebP image is animated (has more than one frame)
                bool isAnimated = false;
                if (webPImage is IMultipageImage multipage && multipage.PageCount > 1)
                {
                    isAnimated = true;
                }

                if (isAnimated)
                {
                    // Save the animated WebP as an animated GIF
                    webPImage.Save(outputPath, new GifOptions());
                    Console.WriteLine("Animated WebP saved as GIF.");
                }
                else
                {
                    // Not animated – optionally handle differently or inform the user
                    Console.WriteLine("The WebP image is not animated. No GIF was created.");
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
 * 1. When building a web service that converts user‑uploaded WebP files to GIFs, you need to verify if the source WebP is animated to decide whether to generate an animated GIF or skip conversion.
 * 2. In a desktop photo‑organizer app that creates thumbnail previews, checking for animation in a WebP image ensures you only export animated previews as GIFs for compatible viewers.
 * 3. While developing a batch‑processing script for migrating legacy assets, you must detect animated WebP files so they can be saved as animated GIFs and preserve motion in the new format.
 * 4. For an e‑learning platform that embeds GIF animations in course material, the code helps confirm that uploaded WebP graphics contain multiple frames before converting them to GIFs.
 * 5. In a content‑moderation pipeline that flags animated media, detecting an animated WebP image allows the system to convert it to GIF for easier analysis and review.
 */