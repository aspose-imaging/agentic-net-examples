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
                    // Enable palette correction for better visual quality
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression (recommended 80)
                    MaxDiff = 80,
                    // Optional: keep interlacing off
                    Interlaced = false
                };

                // Save the brighter image using lossy compression
                gifImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}