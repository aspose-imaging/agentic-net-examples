using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.gif";

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
            // Cast to GifImage for GIF-specific operations
            GifImage gif = (GifImage)image;

            // Apply dithering (Floyd‑Steinberg, 4‑bit palette)
            gif.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

            // Configure GIF save options for quality control
            GifOptions saveOptions = new GifOptions
            {
                // Number of bits per primary color minus 1 (e.g., 7 => 8‑bit per channel)
                ColorResolution = 7,
                // Enable palette correction for better color matching
                DoPaletteCorrection = true,
                // Save as an interlaced GIF
                Interlaced = true
            };

            // Save the processed GIF with the specified options
            gif.Save(outputPath, saveOptions);
        }
    }
}