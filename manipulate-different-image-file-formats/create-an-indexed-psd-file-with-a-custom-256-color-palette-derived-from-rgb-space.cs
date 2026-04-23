using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\Temp\indexed_output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a custom 256‑color palette (simple RGB cube)
            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                // Distribute colors across the RGB space
                byte r = (byte)((i & 0xE0) >> 5); // 3 bits for red
                byte g = (byte)((i & 0x1C) >> 2); // 3 bits for green
                byte b = (byte)(i & 0x03);        // 2 bits for blue

                // Scale to full 0‑255 range
                r = (byte)(r * 255 / 7);
                g = (byte)(g * 255 / 7);
                b = (byte)(b * 255 / 3);

                paletteColors[i] = Aspose.Imaging.Color.FromArgb(255, r, g, b);
            }
            var customPalette = new Aspose.Imaging.ColorPalette(paletteColors);

            // Set up PSD creation options
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                CompressionMethod = CompressionMethod.RLE,
                ChannelBitsCount = 8,               // 8 bits per channel
                ChannelsCount = (short)1,           // Indexed images have a single channel
                Palette = customPalette
            };

            // Create a 256x256 indexed PSD image
            using (Aspose.Imaging.Image psdImage = Aspose.Imaging.Image.Create(psdOptions, 256, 256))
            {
                // Optional: fill the image with a simple pattern using the palette indices
                // Here we just leave it blank (all zeros) which maps to the first palette entry.

                // Save the image (source is already bound, so just call Save())
                psdImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}