using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Indexed,
                    CompressionMethod = CompressionMethod.RLE,
                    ChannelBitsCount = 8,
                    ChannelsCount = 1,
                    Palette = ColorPaletteHelper.Create8BitGrayscale(false)
                };

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
 * 1. When a developer needs to import legacy BMP assets into a Photoshop workflow by converting them to PSD files with an 8‑bit indexed color mode and a custom grayscale palette.
 * 2. When a C# application must generate PSD files for a web service that supplies printable designs, requiring the images to be compressed with RLE and limited to a single 8‑bit channel.
 * 3. When an automation script has to batch‑process scanned BMP images and store them as PSD files that preserve a reduced color depth for faster loading in Adobe Photoshop.
 * 4. When a game‑development pipeline needs to transform BMP textures into PSD layers with an indexed palette to maintain consistent color indexing across assets.
 * 5. When a digital‑archiving tool must convert BMP documentation scans into PSD format while ensuring the output uses an 8‑bit indexed mode and a predefined grayscale palette for archival standards.
 */