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
            // Hardcoded input and output paths
            string inputPath = "sample.eps";
            string outputPath = "sample.psd";

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
                // Configure PSD options to keep alpha channel
                var psdOptions = new PsdOptions
                {
                    ChannelBitsCount = 8,                     // 8 bits per channel
                    ChannelsCount = 4,                        // R, G, B, A
                    ColorMode = ColorModes.Rgb,               // RGB color mode (supports alpha)
                    CompressionMethod = CompressionMethod.Raw, // No compression
                    Version = 6                               // PSD version 6
                };

                // Save as PSD preserving transparency
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}