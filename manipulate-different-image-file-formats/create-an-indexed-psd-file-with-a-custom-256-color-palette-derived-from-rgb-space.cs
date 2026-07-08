using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PSD file path (hardcoded)
            string outputPath = @"C:\Temp\indexed_output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int width = 256;
            int height = 256;

            // Create a custom 256‑color palette derived from RGB space
            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                // Simple RGB generation using modulo arithmetic
                byte r = (byte)((i * 5) % 256);
                byte g = (byte)((i * 7) % 256);
                byte b = (byte)((i * 11) % 256);
                paletteColors[i] = Aspose.Imaging.Color.FromArgb(r, g, b);
            }
            var customPalette = new ColorPalette(paletteColors);

            // Configure PSD options for indexed color mode
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                CompressionMethod = CompressionMethod.RLE,
                ChannelBitsCount = (short)8,
                ChannelsCount = (short)1,
                Palette = customPalette,
                Version = 6
            };

            // Create the PSD image with the specified options
            using (Image psdImage = Image.Create(psdOptions, width, height))
            {
                // Fill the image with a solid color (white) – the palette will be used for indexing
                Graphics graphics = new Graphics(psdImage);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Save the image (already bound to the output file via FileCreateSource)
                psdImage.Save();
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
 * 1. When creating a PSD file for a web‑based color picker that requires an indexed 256‑color palette derived from the RGB space.
 * 2. When exporting a thumbnail sprite sheet from a game asset pipeline where the PSD must use a custom palette to reduce file size.
 * 3. When generating a sample PSD for testing Photoshop plug‑ins that need to handle indexed color mode with RLE compression.
 * 4. When preparing a print‑ready PSD mock‑up that must conform to legacy Photoshop version 6 specifications using an 8‑bit indexed palette.
 * 5. When building an automated batch process that converts raw image data into indexed PSD files for archival storage with a deterministic color palette.
 */