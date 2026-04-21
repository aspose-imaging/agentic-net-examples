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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD save options: RLE compression and Grayscale color mode
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Grayscale
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}