// HOW-TO: Convert BMP to PNG Preserving Color Depth and Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Preserve original bit depth and transparency when possible
                if (image is RasterImage raster)
                {
                    // BitDepth property expects values 1,2,4,8,16; clamp to nearest supported value
                    int bits = raster.BitsPerPixel;
                    if (bits > 16) bits = 16;
                    else if (bits > 8) bits = 8;
                    else if (bits > 4) bits = 4;
                    else if (bits > 2) bits = 2;
                    else bits = 1;

                    pngOptions.BitDepth = (byte)bits;

                    // Choose color type based on presence of alpha channel
                    pngOptions.ColorType = raster.BitsPerPixel > 24
                        ? PngColorType.TruecolorWithAlpha
                        : PngColorType.Truecolor;
                }

                // Save as PNG preserving the determined options
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to convert legacy BMP assets to PNG for web delivery while keeping the original bit depth and any alpha channel intact.
 * 2. When a desktop application must batch‑process user‑uploaded BMP files and store them as lossless PNGs without losing color fidelity.
 * 3. When generating thumbnails from BMP screenshots for a reporting tool that requires PNG format with preserved transparency.
 * 4. When migrating a graphics library from BMP to PNG to reduce file size but still need to maintain the exact color palette for scientific visualization.
 * 5. When integrating Aspose.Imaging into a C# service that receives BMP images from IoT devices and must return PNGs that retain the original image’s bit depth and transparency.
 */
