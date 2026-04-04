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

            // Prepare GIF save options for lossy compression
            GifOptions saveOptions = new GifOptions
            {
                // Enable lossy compression by setting MaxDiff > 0 (recommended 80)
                MaxDiff = 80,
                // Optional: improve palette quality
                DoPaletteCorrection = true,
                // Optional: interlaced output
                Interlaced = true
            };

            // Save the brighter animation using lossy GIF algorithm
            gifImage.Save(outputPath, saveOptions);
        }
    }
}