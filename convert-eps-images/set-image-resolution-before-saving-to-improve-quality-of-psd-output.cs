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
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.psd";

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
            // Configure PSD save options with higher resolution
            PsdOptions psdOptions = new PsdOptions
            {
                // Set desired horizontal and vertical DPI (e.g., 300 DPI)
                ResolutionSettings = new ResolutionSetting(300.0, 300.0)
            };

            // Save the image as PSD using the configured options
            image.Save(outputPath, psdOptions);
        }
    }
}