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

        // Build custom output PSD file name: original name + "_converted.psd"
        string outputDirectory = @"C:\Images\Converted";
        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_converted.psd";
        string outputPath = Path.Combine(outputDirectory, outputFileName);

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options
            PsdOptions psdOptions = new PsdOptions
            {
                // Example settings – adjust as needed
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb,
                // Keep default version (6) and other defaults
            };

            // Save as PSD using the custom output path and options
            image.Save(outputPath, psdOptions);
        }

        Console.WriteLine($"Conversion completed: {outputPath}");
    }
}