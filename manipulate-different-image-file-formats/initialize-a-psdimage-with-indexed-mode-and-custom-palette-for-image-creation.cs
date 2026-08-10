// HOW-TO: Create Indexed PSD Image With Custom Palette In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            // Output path (hard‑coded)
            string outputPath = "output/output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom palette (example with 5 colors)
            Color[] paletteColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Black,
                Color.White
            };
            // Create the palette object
            ColorPalette customPalette = new ColorPalette(paletteColors);

            // Configure PSD creation options for indexed mode
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                Palette = customPalette,
                ChannelBitsCount = 8,          // 8 bits per channel
                ChannelsCount = 1,            // Indexed images use a single channel
                CompressionMethod = CompressionMethod.RLE,
                Version = 6                    // Typical PSD version
            };

            // Create a 200x200 pixel PSD image with the specified options
            using (Image psdImage = Image.Create(psdOptions, 200, 200))
            {
                // Optional: fill the canvas with the first palette color
                Graphics graphics = new Graphics(psdImage);
                graphics.FillRectangle(
                    new Aspose.Imaging.Brushes.SolidBrush(paletteColors[0]),
                    psdImage.Bounds);

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
 * 1. When you need to generate a small‑size PSD file that uses a limited set of colors for web graphics or game assets.
 * 2. When you want to programmatically create a PSD with an indexed color mode to ensure compatibility with older Photoshop versions.
 * 3. When you have to embed a predefined palette (e.g., corporate brand colors) into a PSD for consistent branding across designs.
 * 4. When you are automating batch creation of thumbnail PSDs where each image must use only a few colors to reduce file size.
 * 5. When you need to export a diagram or UI mockup as a PSD with RLE compression and a custom palette for efficient storage.
 */
