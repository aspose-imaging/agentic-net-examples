using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.lossy.gif";

        // Verify that the input file exists
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
            // Cast to GifImage to access GIF‑specific methods
            GifImage gifImage = (GifImage)image;

            // Increase contrast (range: -100 to 100)
            gifImage.AdjustContrast(50f);

            // Configure lossy GIF compression options
            GifOptions saveOptions = new GifOptions
            {
                MaxDiff = 80,               // Recommended lossy level
                DoPaletteCorrection = true,
                Interlaced = true
            };

            // Save the high‑contrast GIF with lossy compression
            gifImage.Save(outputPath, saveOptions);
        }
    }
}