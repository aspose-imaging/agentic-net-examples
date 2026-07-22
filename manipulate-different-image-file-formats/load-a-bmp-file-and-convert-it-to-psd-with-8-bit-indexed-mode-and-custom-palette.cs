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
            string inputPath = @"c:\temp\input.bmp";
            string outputPath = @"c:\temp\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Create a custom 8‑bit palette (example: red and green)
                Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green
                };
                IColorPalette customPalette = new Aspose.Imaging.ColorPalette(paletteColors);

                // Configure PSD save options for 8‑bit indexed mode
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use RLE compression (optional)
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    // Set the color mode to Indexed (palette‑based)
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed,
                    // 8 bits per channel
                    ChannelBitsCount = 8,
                    // Assign the custom palette
                    Palette = customPalette
                };

                // Save the image as PSD with the specified options
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
 * 1. When a developer needs to convert legacy BMP assets into Photoshop‑compatible PSD files while preserving a limited 8‑bit indexed color palette for use in game UI design.
 * 2. When an automated build pipeline must generate PSD mock‑ups from BMP screenshots and apply a custom two‑color palette for branding consistency.
 * 3. When a web service processes user‑uploaded BMP images and stores them as PSD files with RLE compression and indexed color mode to reduce file size for downstream editing.
 * 4. When a desktop application migrates a batch of BMP icons to PSD format with a specific palette to maintain visual fidelity in a design system that only supports 8‑bit indexed colors.
 * 5. When a C# utility needs to programmatically create PSD layers from BMP sources and enforce a custom palette for printing workflows that require indexed color separation.
 */