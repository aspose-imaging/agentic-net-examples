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
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD save options
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,               // Use RLE compression
                ColorMode = ColorModes.Rgb,                               // Set color mode to RGB
                ChannelBitsCount = 8,                                     // 8 bits per channel
                ChannelsCount = 4,                                        // RGBA
                Version = 6                                                // PSD version 6
            };

            // Save as PSD
            image.Save(outputPath, psdOptions);
        }

        // Validate that the saved PSD can be loaded (Photoshop compatibility check)
        if (!Image.CanLoad(outputPath))
        {
            Console.Error.WriteLine("Saved PSD cannot be loaded. It may be incompatible with Photoshop.");
            return;
        }

        // Additional load test to ensure no runtime exception occurs
        try
        {
            using (Image psdImage = Image.Load(outputPath))
            {
                Console.WriteLine("PSD file saved successfully and opened without errors.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error loading saved PSD: {ex.Message}");
        }
    }
}