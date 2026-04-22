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
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD options for 16‑bit per channel
                PsdOptions psdOptions = new PsdOptions
                {
                    ChannelBitsCount = 16,                     // 16 bits per channel
                    ChannelsCount = 4,                         // RGBA channels
                    ColorMode = ColorModes.Rgb,                // RGB color mode
                    CompressionMethod = CompressionMethod.Raw // No compression
                };

                // Save as PSD with the specified options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}