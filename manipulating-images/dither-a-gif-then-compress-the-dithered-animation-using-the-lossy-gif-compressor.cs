// HOW-TO: How To Dither A GIF And Save With Lossy Compression In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.lossy.gif";

            // Verify input file exists
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
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Configure lossy GIF compression options
                GifOptions options = new GifOptions
                {
                    MaxDiff = 80,               // Enable lossy compression
                    DoPaletteCorrection = true,
                    Interlaced = false
                };

                // Save the dithered image using lossy compression
                gifImage.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of an animated GIF while preserving visual quality by applying Floyd‑Steinberg dithering before lossy compression in a C# application.
 * 2. When you want to convert a high‑color GIF into an 8‑bit palette animation for web delivery and then compress it with a configurable MaxDiff setting using Aspose.Imaging for .NET.
 * 3. When you are building an image‑processing pipeline that must generate smaller GIF assets for mobile apps by dither‑reducing colors and applying Aspose’s lossy GIF encoder.
 * 4. When you have legacy GIF animations that require palette correction and interlacing control before saving them as optimized, bandwidth‑friendly files in a .NET service.
 * 5. When you need to automate batch processing of GIFs to apply dithering and lossily compress them for email newsletters or social media posts using C# code.
 */
