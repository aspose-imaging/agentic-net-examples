// HOW-TO: Create Indexed PSD with Custom Color Palette in C# (Aspose.Imaging for .NET)
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
            // Hardcoded output path
            string outputPath = "output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a custom palette (red, green, blue, white, black)
            var palette = new Aspose.Imaging.ColorPalette(new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue,
                Aspose.Imaging.Color.White,
                Aspose.Imaging.Color.Black
            });

            // Configure PSD options for indexed mode with the custom palette
            PsdOptions options = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                CompressionMethod = CompressionMethod.RLE,
                Version = 5,
                Palette = palette,
                ChannelBitsCount = 8,               // 8 bits per channel
                ChannelsCount = (short)1            // Indexed images use a single channel
            };

            // Create a new PSD image (200x200 pixels) with the specified options
            using (Aspose.Imaging.Image psdImage = Aspose.Imaging.Image.Create(options, 200, 200))
            {
                // Since the source is bound to a file, simply call Save()
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
 * 1. When you need to generate a small‑size PSD file for a web preview using a limited set of colors.
 * 2. When exporting programmatically created graphics to Photoshop with an indexed color mode to preserve a specific palette.
 * 3. When automating batch creation of PSD assets for a game UI where only a few colors are required.
 * 4. When integrating Aspose.Imaging into a C# service that must produce PSD files with RLE compression and a custom palette for consistent branding.
 * 5. When converting data visualizations into PSD format while controlling file size by using an 8‑bit indexed channel.
 */
