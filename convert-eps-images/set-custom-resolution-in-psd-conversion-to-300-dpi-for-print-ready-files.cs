using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/sample.psd";

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
            // Configure PSD save options with 300 DPI resolution
            PsdOptions psdOptions = new PsdOptions
            {
                ResolutionSettings = new ResolutionSetting(300.0, 300.0)
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}