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
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD save options
            PsdOptions psdOptions = new PsdOptions
            {
                // Use RAW compression (no compression) – closest to ZIP in this context
                CompressionMethod = CompressionMethod.Raw,
                // Set color mode to RGB
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
            };

            // Save as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}