// HOW-TO: Create Indexed PSD with 64‑Color Palette from PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.psd";

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
                // Cast to RasterImage to access pixel data
                RasterImage rasterImage = (RasterImage)image;

                // Create PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use 8 bits per channel (standard)
                    ChannelBitsCount = 8,
                    // Set color mode to RGB (indexed palette works with RGB mode)
                    ColorMode = ColorModes.Rgb,
                    // Generate a palette with 64 colors derived from the image
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(rasterImage, 64)
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
 * 1. When you need to reduce file size of a Photoshop document by converting a PNG to an indexed PSD with a limited 64‑color palette for web delivery.
 * 2. When preparing assets for a game engine that only supports indexed PSD files with a specific number of colors.
 * 3. When generating printable mock‑ups that require a consistent color palette across multiple images to ensure color matching.
 * 4. When automating batch conversion of high‑resolution PNGs to smaller PSD files for archival while preserving visual fidelity using Aspose.Imaging in C#.
 * 5. When creating thumbnails or preview images in PSD format that must use a reduced palette to meet legacy software constraints.
 */
