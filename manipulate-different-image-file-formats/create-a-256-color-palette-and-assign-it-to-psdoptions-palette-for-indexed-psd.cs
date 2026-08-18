// HOW-TO: Create 256 Color Palette for Indexed PSD in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Temp\input.png";
        string outputPath = @"C:\Temp\output.psd";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to be able to generate a palette
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Generate a 256‑color palette based on the source image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Prepare PSD save options and assign the palette
                PsdOptions psdOptions = new PsdOptions
                {
                    Palette = palette,
                    // Use indexed (bitmap) color mode for an indexed PSD
                    ColorMode = ColorModes.Bitmap,
                    // Optional: set bits per channel and channels count for typical 8‑bit indexed PSD
                    ChannelBitsCount = 8,
                    ChannelsCount = 1
                };

                // Save the image as an indexed PSD
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
 * 1. When you need to convert a PNG to an indexed‑color PSD with a custom 256‑color palette for compatibility with older Photoshop versions.
 * 2. When you want to reduce file size by saving a raster image as an 8‑bit indexed PSD while preserving the most representative colors.
 * 3. When you are building a batch‑processing tool that generates PSD files with a limited palette for printing or web‑delivery constraints.
 * 4. When you need to programmatically create a Photoshop document that uses bitmap color mode and a specific palette for game asset pipelines.
 * 5. When you must ensure that a source image is transformed into a PSD with a defined palette to maintain consistent colors across multiple design tools.
 */
