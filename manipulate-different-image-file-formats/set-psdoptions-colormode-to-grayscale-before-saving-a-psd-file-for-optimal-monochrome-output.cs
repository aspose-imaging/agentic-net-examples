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
            // Configure PSD saving options
            PsdOptions psdOptions = new PsdOptions
            {
                // Set color mode to Grayscale for monochrome output
                ColorMode = ColorModes.Grayscale
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}