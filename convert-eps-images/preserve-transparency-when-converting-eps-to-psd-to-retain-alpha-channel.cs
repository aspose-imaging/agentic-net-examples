using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD options to preserve transparency (alpha channel)
            var psdOptions = new PsdOptions
            {
                // 8 bits per channel
                ChannelBitsCount = 8,
                // 4 channels: R, G, B, A
                ChannelsCount = 4,
                // RGB color mode supports alpha
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                // Use RAW (no compression) to keep data intact
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                // Keep original metadata if any
                KeepMetadata = true
            };

            // Save as PSD preserving alpha channel
            image.Save(outputPath, psdOptions);
        }
    }
}