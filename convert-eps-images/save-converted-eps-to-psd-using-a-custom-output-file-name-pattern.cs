using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS file path
        string inputPath = @"C:\Images\sample.eps";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Build output PSD file path using custom pattern: <original name>_converted.psd
        string outputDirectory = @"C:\Images\Converted";
        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_converted.psd";
        string outputPath = Path.Combine(outputDirectory, outputFileName);

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,          // Use RLE compression
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale, // Grayscale color mode
                Version = 6                                          // PSD version 6
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }

        Console.WriteLine($"Conversion completed: {outputPath}");
    }
}