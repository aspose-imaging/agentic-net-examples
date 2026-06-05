using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to GifImage for GIF-specific operations
                Aspose.Imaging.FileFormats.Gif.GifImage gif = (Aspose.Imaging.FileFormats.Gif.GifImage)image;

                // Apply dithering (e.g., Floyd‑Steinberg with 8‑bit palette)
                gif.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);

                // Configure GIF save options for color depth and quality
                GifOptions saveOptions = new GifOptions
                {
                    // ColorResolution = bits per primary color minus 1 (7 => 8 bits)
                    ColorResolution = 7,
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Optional: set interlaced flag if desired
                    Interlaced = false
                };

                // Save the processed GIF with the specified options
                gif.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}