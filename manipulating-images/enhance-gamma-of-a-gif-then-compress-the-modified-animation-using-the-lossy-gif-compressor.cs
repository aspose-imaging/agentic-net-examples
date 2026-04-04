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

            // Enhance gamma (example value 2.0f)
            gifImage.AdjustGamma(2.0f);

            // Prepare GIF save options for lossy compression
            GifOptions saveOptions = new GifOptions
            {
                // Set MaxDiff > 0 to enable lossy compression (recommended 80)
                MaxDiff = 80,
                // Optional: improve palette quality
                DoPaletteCorrection = true
            };

            // Save the modified GIF with lossy compression
            gifImage.Save(outputPath, saveOptions);
        }

        Console.WriteLine("Gamma enhanced and lossy GIF saved successfully.");
    }
}