// HOW-TO: Deskew GIF and Apply Floyd Steinberg Dithering to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.png";

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

                // Deskew the image (normalize its angle)
                gifImage.NormalizeAngle();

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the processed image as PNG
                gifImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to correct the rotation of scanned animated GIF frames and convert them to a high‑contrast PNG for web display.
 * 2. When you want to reduce a GIF’s color depth to a 1‑bit palette using Floyd‑Steinberg dithering before saving as PNG for printing.
 * 3. When an application must automatically straighten misaligned GIF screenshots and output a lossless PNG for archival.
 * 4. When you are processing user‑uploaded GIFs, removing skew and applying dithering to meet a PNG‑only workflow in a C# service.
 * 5. When a batch job has to normalize the angle of GIF images and generate dithered PNG thumbnails for a mobile app.
 */
