using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PSD file path (hard‑coded)
            string outputPath = "output/output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a custom 256‑color palette derived from RGB space
            Color[] paletteColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                // Simple variation across RGB channels
                int r = (i * 5) % 256;
                int g = (i * 3) % 256;
                int b = (i * 7) % 256;
                paletteColors[i] = Color.FromArgb(255, r, g, b);
            }
            var customPalette = new ColorPalette(paletteColors);

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                Palette = customPalette,
                ChannelBitsCount = 8,               // 8 bits per channel
                ChannelsCount = (short)1,           // Indexed images use a single channel
                CompressionMethod = CompressionMethod.RLE,
                Version = 6                         // Default PSD version
            };

            // Create a 256×256 indexed PSD image bound to the output file
            using (Image psdImage = Image.Create(psdOptions, 256, 256))
            {
                // No additional drawing is required; the palette is stored with the file
                psdImage.Save(); // Save to the bound FileCreateSource
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}