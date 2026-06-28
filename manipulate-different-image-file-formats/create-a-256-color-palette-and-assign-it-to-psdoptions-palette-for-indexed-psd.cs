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
            string outputPath = "output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 256‑color grayscale palette
            Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                colors[i] = Aspose.Imaging.Color.FromArgb(i, i, i);
            }
            var palette = new Aspose.Imaging.ColorPalette(colors);

            // Configure PSD options for indexed color mode
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.ChannelBitsCount = 8;          // 8 bits per channel
            psdOptions.ChannelsCount = 1;            // Indexed uses a single channel
            psdOptions.Palette = palette;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.Version = 6;                  // PSD version 6

            // Create a canvas and draw (optional)
            using (var image = Image.Create(psdOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                // Save the bound image
                image.Save();
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
 * 1. When a developer needs to generate a small‑size PSD file for web thumbnails that uses an 8‑bit indexed color mode to reduce file size while preserving grayscale tones.
 * 2. When converting legacy 8‑bit grayscale images into Photoshop PSD format for batch processing in a C# application that requires a custom palette.
 * 3. When creating a PSD asset for a game UI where only 256 shades of gray are needed, enabling fast loading and memory‑efficient textures.
 * 4. When exporting scientific visualizations such as microscopy slides as indexed PSD files to maintain precise intensity levels while keeping the file compatible with Photoshop.
 * 5. When building an automated reporting tool that saves chart screenshots as indexed PSDs with a predefined 256‑color palette to ensure consistent color mapping across all generated documents.
 */