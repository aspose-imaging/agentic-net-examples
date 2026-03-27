using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD options for 8‑bit indexed mode with a custom palette
            var psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Bitmap, // Indexed color mode
                ChannelBitsCount = 8,
                ChannelsCount = 1,
                Palette = ColorPaletteHelper.Create8BitGrayscale(false) // Custom 8‑bit grayscale palette
            };

            // Save as PSD
            image.Save(outputPath, psdOptions);
        }
    }
}