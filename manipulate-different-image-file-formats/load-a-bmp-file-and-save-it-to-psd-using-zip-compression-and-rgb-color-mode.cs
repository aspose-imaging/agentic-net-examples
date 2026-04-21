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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

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
                // Use RLE compression (ZIP‑like compression for PSD)
                CompressionMethod = CompressionMethod.RLE,
                // Set color mode to RGB
                ColorMode = ColorModes.Rgb
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}