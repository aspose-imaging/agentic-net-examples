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
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\Converted\sample.psd";

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
                ChannelsCount = 4,                                        // RGBA channels
                Version = 6                                               // PSD version 6
            };

            // Save the image as PSD
            image.Save(outputPath, psdOptions);
        }

        // Validate that the saved PSD can be loaded (indicates Photoshop compatibility)
        bool canLoad = Image.CanLoad(outputPath);
        if (canLoad)
        {
            Console.WriteLine("PSD file saved successfully and can be opened by Photoshop.");
        }
        else
        {
            Console.Error.WriteLine("Saved PSD file could not be loaded. It may not open correctly in Photoshop.");
        }
    }
}