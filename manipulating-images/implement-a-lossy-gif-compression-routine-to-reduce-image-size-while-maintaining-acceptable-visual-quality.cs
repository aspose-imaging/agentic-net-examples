using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output_lossy.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF options for lossy compression
            GifOptions gifOptions = new GifOptions
            {
                // Recommended value for good visual quality
                MaxDiff = 80,
                // Improve palette selection
                DoPaletteCorrection = true,
                // Set color resolution (bits per primary color minus 1)
                ColorResolution = 7,
                // Optional: interlaced GIF
                Interlaced = true
            };

            // Save the image as a lossy GIF
            image.Save(outputPath, gifOptions);
        }

        Console.WriteLine("Lossy GIF compression completed.");
    }
}