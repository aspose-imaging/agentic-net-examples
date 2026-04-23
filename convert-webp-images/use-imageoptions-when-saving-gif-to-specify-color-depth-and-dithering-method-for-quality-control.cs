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
        string inputPath = "C:\\temp\\input.gif";
        string outputPath = "C:\\temp\\output.gif";

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
            GifImage gif = (GifImage)image;

            // Apply Floyd‑Steinberg dithering with an 8‑bit palette (256 colors)
            gif.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

            // Configure GIF save options for color depth and palette handling
            GifOptions saveOptions = new GifOptions
            {
                // ColorResolution is (bits per primary color) - 1; 7 means 8 bits per channel
                ColorResolution = 7,
                DoPaletteCorrection = true,
                Interlaced = false
            };

            // Save the processed GIF using the specified options
            gif.Save(outputPath, saveOptions);
        }
    }
}