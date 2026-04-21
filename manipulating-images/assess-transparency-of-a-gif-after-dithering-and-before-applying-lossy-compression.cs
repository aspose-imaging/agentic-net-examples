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
        string inputPath = @"c:\temp\sample.gif";
        string outputPath = @"c:\temp\sample.dithered.gif";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific members
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette (full color depth)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Assess transparency after dithering
                bool hasTransparency = gifImage.HasTransparentColor;
                Console.WriteLine($"Has transparent color after dithering: {hasTransparency}");

                // Save the dithered image as a lossless GIF
                using (FileStream stream = File.OpenWrite(outputPath))
                {
                    GifOptions saveOptions = new GifOptions
                    {
                        // Enable palette correction for best visual result
                        DoPaletteCorrection = true,
                        // No lossy compression (MaxDiff = 0)
                        MaxDiff = 0
                    };
                    gifImage.Save(stream, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}