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
            string inputPath = @"c:\temp\input.gif";
            string outputPath = @"c:\temp\output.lossy.gif";

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

                // Prepare GIF save options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Enable palette correction for better color quality
                    DoPaletteCorrection = true,
                    // Optional: make the GIF interlaced
                    Interlaced = true,
                    // Set maximum pixel difference to trigger lossy compression
                    MaxDiff = 80,
                    // Optional: set color resolution (bits per color - 1)
                    ColorResolution = 7
                };

                // Save the brighter GIF using lossy compression
                gifImage.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}