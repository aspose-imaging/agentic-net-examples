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
        string inputPath = "input.png";
        string outputPath = "output.png";

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
            // Configure PNG save options for lossless maximum compression
            var pngOptions = new PngOptions
            {
                CompressionLevel = 9,          // Maximal compression (0-9)
                Progressive = true,            // Enable progressive loading (optional)
                // You can keep the original color type or set a specific one if needed
                // ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save the image with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}