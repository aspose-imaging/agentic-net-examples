using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_brighter.gif";

            // Verify that the input file exists
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

                // Increase brightness by roughly 10% of the full range (255 * 0.10 ≈ 26)
                gifImage.AdjustBrightness(26);

                // Save the brighter GIF
                gifImage.Save(outputPath);
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
 * 1. When a web developer wants to automatically enhance the visibility of animated promotional GIFs on an e‑commerce site by increasing their brightness by ten percent using C# and Aspose.Imaging before publishing them.
 * 2. When a desktop application needs to preprocess user‑uploaded GIF avatars, making them slightly brighter to improve contrast on dark backgrounds while preserving the original animation frames.
 * 3. When a marketing automation script must generate a brighter version of a seasonal GIF banner for email campaigns, loading the file with Image.Load, adjusting brightness, and saving the result as a new GIF.
 * 4. When a content management system integrates a batch job that scans a folder of GIF assets, boosts each image’s brightness by roughly 10 % with AdjustBrightness, and stores the updated files in a separate output directory.
 * 5. When a mobile app backend service processes GIF stickers, applying a modest brightness increase to ensure they appear vivid on devices with low screen brightness, then saving the modified GIF using Aspose.Imaging for .NET.
 */