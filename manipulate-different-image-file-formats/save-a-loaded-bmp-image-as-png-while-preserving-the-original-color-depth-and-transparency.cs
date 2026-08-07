using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.png";

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
                // Determine original bits per pixel (if available)
                int bitsPerPixel = 0;
                if (image is RasterImage raster)
                {
                    bitsPerPixel = raster.BitsPerPixel;
                }

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Preserve bit depth when possible (PNG supports 8 or 16 bits per channel)
                if (bitsPerPixel == 8 || bitsPerPixel == 16)
                {
                    pngOptions.BitDepth = (byte)bitsPerPixel;
                }
                else
                {
                    pngOptions.BitDepth = 8; // default fallback
                }

                // Save as PNG, preserving transparency automatically
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
 * 1. When a developer needs to convert legacy BMP assets from a Windows desktop application into web‑friendly PNG files while keeping the original 8‑ or 16‑bit color depth and any alpha channel intact.
 * 2. When a C# service processes user‑uploaded BMP screenshots and must store them as lossless PNGs for archival, preserving transparency for overlay graphics.
 * 3. When an automated build pipeline generates game UI textures from BMP source files and requires PNG output with the same bits‑per‑pixel to avoid visual quality loss.
 * 4. When a document‑management system migrates scanned BMP documents to PNG format for faster loading in browsers, ensuring the original grayscale or palette depth is retained.
 * 5. When a batch image‑processing tool uses Aspose.Imaging to read BMP icons and export them as PNG icons, preserving the original transparency for use in modern operating systems.
 */