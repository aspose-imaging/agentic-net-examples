// HOW-TO: Create Indexed PSD with Custom 256‑Color Palette from PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.psd";

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
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Configure PSD save options with a custom 256‑color palette
                PsdOptions psdOptions = new PsdOptions
                {
                    // 8 bits per channel (standard for PSD)
                    ChannelBitsCount = 8,
                    // Use RGB color mode; the palette will be applied on top of it
                    ColorMode = ColorModes.Rgb,
                    // Create a uniform 256‑color palette derived from the RGB space
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
 * 1. When a developer needs to convert a high‑resolution PNG into an indexed PSD with a 256‑color palette to meet size constraints for web‑based Photoshop previews.
 * 2. When building an automated asset pipeline that generates Photoshop‑compatible files from source images while ensuring consistent color mapping across all assets.
 * 3. When preparing graphics for a legacy printing workflow that only accepts PSD files in indexed color mode with a fixed palette.
 * 4. When creating game UI textures that must be stored as PSD files with a limited palette to simplify color‑matching and reduce memory usage.
 * 5. When a content management system must store uploaded images as PSDs with a uniform 256‑color palette for easy editing in Photoshop without losing the original color relationships.
 */
