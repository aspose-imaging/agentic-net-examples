using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\output.psd";

        // Ensure any runtime exception is reported without crashing
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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to work with palettes
                RasterImage rasterImage = (RasterImage)image;

                // Generate a 64‑color palette that best represents the source image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 64);

                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use 8 bits per channel (standard for PSD)
                    ChannelBitsCount = 8,
                    // Set the color mode to RGB
                    ColorMode = ColorModes.Rgb,
                    // Assign the generated palette for indexed saving
                    Palette = palette,
                    // No compression (RAW) – can be changed to RLE if desired
                    CompressionMethod = CompressionMethod.Raw
                };

                // Save the image as an indexed PSD using the specified options
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
 * 1. When a developer needs to convert high‑resolution PNG assets into a lightweight PSD for a web‑based design tool that only supports indexed color images with a limited 64‑color palette.
 * 2. When preparing graphics for a legacy Photoshop workflow that requires PSD files with 8‑bit RGB channels and a custom palette to ensure consistent color reproduction across older versions of the software.
 * 3. When optimizing game UI sprites for a mobile game engine that loads PSD files but imposes a maximum of 64 colors per layer to reduce memory usage and improve rendering speed.
 * 4. When automating batch processing of product catalog images to generate PSD mock‑ups with a reduced palette, enabling faster printing previews and lower file sizes for client review.
 * 5. When creating color‑controlled marketing materials where the design team wants to lock the color scheme to exactly 64 shades, and the developer uses the code to enforce that palette during PSD export.
 */