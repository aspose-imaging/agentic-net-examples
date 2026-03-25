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
        string inputPath = @"C:\Temp\input.cdr";
        string outputPath = @"C:\Temp\output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD options for 16‑bit per channel output
            var psdOptions = new PsdOptions
            {
                // 16 bits per color channel
                ChannelBitsCount = 16,
                // Number of channels (e.g., RGBA)
                ChannelsCount = 4,
                // Use RGB color mode
                ColorMode = ColorModes.Rgb,
                // No compression (RAW) for lossless output
                CompressionMethod = CompressionMethod.Raw
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}