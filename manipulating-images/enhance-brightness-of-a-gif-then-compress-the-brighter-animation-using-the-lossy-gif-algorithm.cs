// HOW-TO: Increase GIF Brightness and Save with Lossy Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.lossy.gif";

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

                // Enhance brightness (value range: -255 to 255)
                gifImage.AdjustBrightness(50);

                // Configure lossy GIF saving options
                GifOptions saveOptions = new GifOptions
                {
                    DoPaletteCorrection = true, // improve palette quality
                    MaxDiff = 80                 // enable lossy compression (recommended value)
                };

                // Save the brighter image with lossy compression
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
 * 1. When you need to brighten a low‑light animated GIF before embedding it on a website while keeping file size small.
 * 2. When you want to preprocess user‑uploaded GIFs by increasing visibility and then apply lossy compression to meet email attachment limits.
 * 3. When you are generating marketing banners that require a brighter animation and must be optimized for fast mobile loading.
 * 4. When you automate a batch job that enhances the contrast of GIF assets and stores them using Aspose.Imaging’s lossy GIF encoder to reduce storage costs.
 * 5. When you create a social‑media sharing tool that adjusts GIF brightness for better display and compresses the result to stay within platform size restrictions.
 */
