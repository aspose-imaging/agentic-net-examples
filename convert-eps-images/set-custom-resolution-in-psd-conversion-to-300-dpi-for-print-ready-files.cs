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
        string outputPath = @"C:\temp\output_300dpi.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD save options with a 300 DPI resolution
            PsdOptions psdOptions = new PsdOptions
            {
                // Set horizontal and vertical resolution to 300 DPI
                ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300.0, 300.0),

                // Example: use RLE compression (optional)
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE
            };

            // Save the image as a PSD file with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}