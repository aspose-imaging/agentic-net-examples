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
        string outputPath = @"C:\Images\sample_converted.psd";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options for 16‑bit per channel depth
            PsdOptions psdOptions = new PsdOptions
            {
                ChannelBitsCount = 16,                     // 16 bits per channel
                ChannelsCount = 4,                         // RGBA channels
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                Version = 6                                 // Default PSD version
            };

            // Save the image as PSD using the configured options
            image.Save(outputPath, psdOptions);
        }

        Console.WriteLine("EPS to PSD conversion completed successfully.");
    }
}