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
        string inputPath = @"c:\temp\input.bmp";
        string outputPath = @"c:\temp\output.psd";

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
                // Cast to RasterImage for palette generation
                RasterImage raster = (RasterImage)image;

                // Create PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use RGB color mode
                    ColorMode = ColorModes.Rgb,

                    // Generate a uniform 256‑color palette from the RGB space
                    Palette = ColorPaletteHelper.GetUniformColorPalette(raster),

                    // Set channel bits count to 8 (standard for 8‑bit per channel)
                    ChannelBitsCount = 8
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
 * 1. When a developer needs to convert high‑resolution BMP assets into a compact indexed PSD for use in legacy Photoshop workflows that require an 8‑bit per channel palette.
 * 2. When a graphics pipeline must generate web‑ready PSD files with a uniform 256‑color palette to reduce file size while preserving the original RGB color distribution.
 * 3. When an automation script has to batch‑process scanned documents, converting them from BMP to indexed PSD to enable faster layer‑based editing in Photoshop.
 * 4. When a game‑development toolchain requires exporting sprite sheets as indexed PSD files with a custom 256‑color palette for efficient texture memory usage.
 * 5. When a digital‑printing application needs to create PSD files with a fixed 256‑color palette to ensure consistent color output across different printers and RIP software.
 */