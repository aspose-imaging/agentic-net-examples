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
        string outputPath = @"C:\Images\Converted\sample.psd";

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
            // Configure PSD saving options with balanced compression (RLE)
            var psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE
                // Additional options can be set here if needed, e.g., ColorMode, ChannelBitsCount, etc.
            };

            // Save as PSD using the configured options
            image.Save(outputPath, psdOptions);
        }
    }
}