using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Increase brightness (value range: -255 to 255)
                gifImage.AdjustBrightness(50);

                // Configure lossy GIF saving options
                GifOptions saveOptions = new GifOptions
                {
                    DoPaletteCorrection = true, // improve palette quality
                    Interlaced = true,          // optional interlacing
                    MaxDiff = 80                // >0 enables lossy compression
                };

                // Save the brighter GIF using lossy compression
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When creating marketing email campaigns that include animated GIFs, a developer can brighten the animation to match brand colors and then apply lossy GIF compression to keep the email size under the provider’s limits.
 * 2. When processing user‑uploaded GIF stickers for a chat app, a developer may need to increase visibility in low‑light scenes and compress the result with Aspose.Imaging’s lossy GIF algorithm to reduce bandwidth usage.
 * 3. When generating thumbnail previews of GIF tutorials for a learning platform, a developer can boost the brightness for better readability and save the preview with lossy compression to speed up page loads.
 * 4. When preparing animated GIFs for social media posts, a developer can use the code to adjust brightness for a consistent look across feeds and employ lossy GIF saving options to stay within platform file‑size restrictions.
 * 5. When building a batch image‑processing pipeline that normalizes lighting in legacy GIF animations, a developer can apply the brightness adjustment and then use GifOptions with MaxDiff to compress the output for archival storage.
 */