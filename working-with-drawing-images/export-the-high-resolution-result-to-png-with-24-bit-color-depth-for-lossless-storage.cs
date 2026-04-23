using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

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
            // Configure PNG export options for 24‑bit truecolor (8 bits per channel)
            var pngOptions = new PngOptions
            {
                BitDepth = 8, // 8 bits per channel
                ColorType = PngColorType.Truecolor, // 24‑bit RGB
                CompressionLevel = 9 // maximum compression (still lossless)
            };

            // Save the image as PNG with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}