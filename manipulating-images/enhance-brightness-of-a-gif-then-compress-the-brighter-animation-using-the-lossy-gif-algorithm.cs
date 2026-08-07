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
            string outputPath = @"C:\temp\output_bright_lossy.gif";

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

                // Increase brightness (value range: -255 to 255)
                gifImage.AdjustBrightness(50);

                // Configure lossy GIF compression options
                GifOptions saveOptions = new GifOptions
                {
                    // Enable lossy compression by setting a positive MaxDiff
                    MaxDiff = 80,
                    // Optional: improve palette quality
                    DoPaletteCorrection = true,
                    // Optional: interlaced output
                    Interlaced = false
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
 * 1. When a developer needs to brighten a user‑uploaded animated GIF before reducing its file size for faster web page loading, they can use this code to adjust brightness and apply lossy GIF compression.
 * 2. When an e‑commerce platform wants to enhance product demo animations by increasing visibility in low‑light scenes while keeping bandwidth low, the snippet shows how to boost brightness and save the result with a lossy palette.
 * 3. When a social‑media app must generate a brighter preview thumbnail from an animated GIF and store it in a size‑constrained cache, the code demonstrates the C# AdjustBrightness call followed by GifOptions with MaxDiff.
 * 4. When a digital marketing team needs to prepare a series of animated GIF banners with consistent brightness and optimized file size for email campaigns, this example illustrates using Aspose.Imaging to modify brightness and compress with lossy GIF settings.
 * 5. When a mobile game developer wants to improve the visual clarity of in‑game animated GIF assets on dark backgrounds while minimizing download size, the provided C# routine shows how to increase brightness and save using lossy GIF compression options.
 */