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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.psd";

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
                // Cast to RasterImage to access pixel data
                RasterImage raster = (RasterImage)image;

                // Generate a palette with exactly 64 colors from the source image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 64);

                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Assign the generated palette (inherited from ImageOptionsBase)
                    Palette = palette,

                    // Standard 8‑bit per channel
                    ChannelBitsCount = 8,

                    // Use RGB color mode; the palette will be applied for indexed data
                    ColorMode = ColorModes.Rgb,

                    // Use RLE compression (optional)
                    CompressionMethod = CompressionMethod.RLE
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
 * 1. When a developer needs to convert high‑resolution PNG assets into a compact PSD for legacy Photoshop workflows that only support indexed color with a limited palette.
 * 2. When generating web‑ready preview files where the PSD must be small in size, using a 64‑color palette to reduce file weight while preserving the original image’s visual essence.
 * 3. When preparing artwork for printing processes that require indexed PSD files with a fixed palette, such as screen‑printing plates that can handle only 64 colors.
 * 4. When building an automated asset pipeline that extracts color palettes from source images and stores them as indexed PSDs for use in game‑development texture atlases.
 * 5. When creating archival copies of digital illustrations where the PSD format is required but storage constraints demand a reduced 64‑color indexed representation.
 */