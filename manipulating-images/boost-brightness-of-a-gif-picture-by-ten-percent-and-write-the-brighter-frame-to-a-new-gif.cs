using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.gif";
        string outputPath = @"c:\temp\output_brighter.gif";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Increase brightness by ~10% (25 out of 255)
                gifImage.AdjustBrightness(25);

                // Save the modified GIF
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
 * 1. When a web developer wants to improve the visibility of an animated GIF banner on a dark website theme by increasing its brightness using C# and Aspose.Imaging before publishing it.
 * 2. When a mobile app backend needs to preprocess user‑uploaded GIF stickers, boosting their brightness by about ten percent with Aspose.Imaging’s AdjustBrightness method to ensure they appear vivid on all screen types.
 * 3. When an e‑learning platform automatically enhances the contrast of instructional GIF animations for better readability in presentations, using C# code that loads, brightens, and saves the GIF.
 * 4. When a digital marketing tool generates a series of promotional GIFs and must apply a uniform brightness increase to match brand guidelines, leveraging Aspose.Imaging’s GifImage class in .NET.
 * 5. When a desktop utility program batch‑processes GIF files to correct underexposed frames, applying a 10 % brightness boost and writing the result to a new GIF file with C#.
 */