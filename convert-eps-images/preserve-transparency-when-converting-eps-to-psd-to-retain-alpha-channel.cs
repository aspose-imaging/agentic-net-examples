using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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
            // Configure PSD options to preserve transparency (RGBA)
            PsdOptions psdOptions = new PsdOptions
            {
                // 8 bits per channel
                ChannelBitsCount = 8,
                // 4 channels: Red, Green, Blue, Alpha
                ChannelsCount = 4,
                // RGB color mode supports alpha channel
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                // No compression (optional)
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                // Use default PSD version (6)
                Version = 6
            };

            // Save as PSD preserving alpha channel
            image.Save(outputPath, psdOptions);
        }
    }
}