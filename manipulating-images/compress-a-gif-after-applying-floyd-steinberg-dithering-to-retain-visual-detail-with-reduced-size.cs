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
        string outputPath = @"C:\temp\output.gif";

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
            // Cast to GifImage to access GIF‑specific methods
            GifImage gifImage = (GifImage)image;

            // Apply Floyd‑Steinberg dithering with a 4‑bit palette (16 colors)
            gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

            // Configure GIF saving options for lossy compression
            GifOptions saveOptions = new GifOptions
            {
                // Recommended value for good visual quality with size reduction
                MaxDiff = 80
            };

            // Save the processed image
            gifImage.Save(outputPath, saveOptions);
        }
    }
}