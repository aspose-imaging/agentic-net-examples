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
            // Hardcoded output path
            string outputPath = "output\\indexed_image.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a standard 256‑color RGB palette
            IColorPalette palette = ColorPaletteHelper.Create8Bit();

            // Configure PSD options for an indexed image
            var psdOptions = new PsdOptions
            {
                ColorMode = ColorModes.Indexed,          // Indexed color mode
                Palette = palette,                       // Assign the custom palette
                CompressionMethod = CompressionMethod.RLE,
                ChannelBitsCount = 8,                    // 8 bits per channel
                ChannelsCount = 1                        // Single channel for indexed data
            };

            // Create a new 256×256 image using the PSD options
            using (Image image = Image.Create(psdOptions, 256, 256))
            {
                // Fill the image with a solid color (first palette entry)
                var graphics = new Graphics(image);
                graphics.Clear(Color.Red);

                // Save the image as PSD with the indexed palette
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}