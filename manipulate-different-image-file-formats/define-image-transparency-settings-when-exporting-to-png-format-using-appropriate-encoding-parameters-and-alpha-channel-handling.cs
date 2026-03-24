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
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

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
            // Configure PNG export options with transparency (alpha channel)
            PngOptions pngOptions = new PngOptions
            {
                // Use Truecolor with Alpha to preserve transparency
                ColorType = PngColorType.TruecolorWithAlpha,
                // 8 bits per channel (standard)
                BitDepth = 8,
                // Maximum compression (0-9)
                CompressionLevel = 9,
                // Use adaptive filtering for better compression
                FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                // Enable progressive loading (optional)
                Progressive = true
            };

            // Save the image as PNG with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}