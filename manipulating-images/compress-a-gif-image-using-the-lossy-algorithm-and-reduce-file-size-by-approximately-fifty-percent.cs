using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output.lossy.gif";

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
            // Configure lossy compression options
            GifOptions saveOptions = new GifOptions
            {
                // Recommended value for good lossy compression
                MaxDiff = 80,
                // Improves palette quality
                DoPaletteCorrection = true
            };

            // Save the image with lossy compression
            image.Save(outputPath, saveOptions);
        }

        Console.WriteLine("Compression completed.");
    }
}