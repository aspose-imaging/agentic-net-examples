using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "sample_grayscale.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG options for grayscale output
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.Grayscale
            };

            // Save as PNG with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}