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
        string outputPath = @"C:\temp\output_dithered.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access Dither method
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette (you can change bitsCount as needed)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed animation as a new GIF file
                gifImage.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce the color depth of an animated GIF for faster web loading while preserving visual quality, they can use this code to apply Floyd‑Steinberg dithering and save a smaller file.
 * 2. When a mobile app must display legacy GIF animations on devices that only support 256 colors, the code can dither the frames to an 8‑bit palette and generate a compatible output.
 * 3. When an e‑commerce platform wants to create lightweight promotional GIFs from high‑resolution source files, this snippet automates the conversion and dithering process in C#.
 * 4. When a game developer needs to preprocess user‑uploaded GIF avatars to meet size constraints without losing detail, they can run this code to dither and re‑encode the animation.
 * 5. When a content management system must batch‑process GIF banners for email newsletters, the example provides a simple way to dither each file and save the optimized result.
 */