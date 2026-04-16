using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF compression (lossy) via MaxDiff
            GifOptions gifOptions = new GifOptions
            {
                // Recommended value for optimal lossy compression
                MaxDiff = 80,
                // Optional: enable interlacing for progressive display
                Interlaced = true,
                // Optional: improve palette quality
                DoPaletteCorrection = true
            };

            // Save as GIF with the specified options
            image.Save(outputPath, gifOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}