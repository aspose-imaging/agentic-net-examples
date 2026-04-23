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
            // Define output path
            string outputPath = @"C:\Temp\indexed_output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a custom palette (example with 5 colors)
            Color[] paletteColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Black,
                Color.White
            };
            IColorPalette palette = new ColorPalette(paletteColors);

            // Configure PSD options for indexed mode
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                Palette = palette,
                ChannelBitsCount = 8,               // 8 bits per channel
                ChannelsCount = (short)1,           // Indexed images have 1 channel
                CompressionMethod = CompressionMethod.RLE,
                Version = 6                         // PSD version 6
            };

            int width = 200;
            int height = 200;

            // Create the PSD image canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Draw a simple gradient using the custom palette colors
                Graphics graphics = new Graphics(image);
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(width, height),
                    paletteColors[0],
                    paletteColors[1]);

                graphics.FillRectangle(brush, image.Bounds);

                // Save the image (output path already bound via Source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}