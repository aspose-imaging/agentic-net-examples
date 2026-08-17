// HOW-TO: Increase GIF Contrast and Apply Lossy Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.gif";
            string outputPath = "C:\\temp\\output.lossy.gif";

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
                // Cast to GifImage to access GIF-specific functionality
                GifImage gifImage = (GifImage)image;

                // Increase contrast (value range: -100 to 100)
                gifImage.AdjustContrast(50f);

                // Configure lossy GIF compression options
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80,               // Enable lossy compression
                    DoPaletteCorrection = true, // Improve palette quality
                    ColorResolution = 7         // Bits per color minus 1
                };

                // Save the enhanced GIF with lossy compression
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
 * 1. When you need to make an animated GIF more vivid for a web banner while reducing its file size for faster loading.
 * 2. When you want to preprocess user‑uploaded GIFs by boosting contrast before storing them in a content‑delivery network.
 * 3. When you are building a C# tool that automatically optimizes GIF animations for email newsletters with lossy compression.
 * 4. When you need to improve the visual quality of low‑contrast GIFs and shrink them for mobile app assets using Aspose.Imaging.
 * 5. When you are creating a batch script that adjusts GIF contrast and applies palette correction to meet strict bandwidth limits.
 */
