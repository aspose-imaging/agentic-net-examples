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
        string inputPath = @"C:\Temp\input.gif";
        string outputPath = @"C:\Temp\output_dithered.gif";

        try
        {
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
                // Cast to GifImage to access GIF-specific members
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette (full color depth)
                // Using null for customPalette to let the library generate the palette automatically
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Save the processed animation back to a GIF file
                gifImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}