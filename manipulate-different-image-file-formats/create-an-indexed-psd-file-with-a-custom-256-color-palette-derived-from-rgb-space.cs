using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to work with palettes
                RasterImage raster = (RasterImage)image;

                // Create PSD options with a custom 256‑color palette derived from RGB space
                PsdOptions psdOptions = new PsdOptions
                {
                    // Standard 8‑bit per channel
                    ChannelBitsCount = 8,
                    // Use RGB color mode; the palette will define the indexed colors
                    ColorMode = ColorModes.Rgb,
                    // Uniform 256‑color palette covering the RGB space
                    Palette = ColorPaletteHelper.GetUniformColorPalette(raster)
                };

                // Save the image as an indexed PSD file
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert a high‑resolution BMP into an indexed PSD with a uniform 256‑color palette for compatibility with legacy Photoshop workflows.
 * 2. When a graphics pipeline requires reducing file size by saving images as 8‑bit indexed PSDs while preserving the original RGB color space for web‑ready assets.
 * 3. When an automated batch process must generate PSD files from scanned bitmap documents and enforce a consistent 256‑color palette to ensure predictable color mapping across all pages.
 * 4. When a game‑development toolchain needs to import BMP textures and export them as indexed PSDs so that artists can edit layers in Photoshop without exceeding the 256‑color limit.
 * 5. When a digital archiving system has to store legacy bitmap images as PSD files with a custom palette derived from the full RGB spectrum to maintain visual fidelity while supporting Photoshop’s native format.
 */