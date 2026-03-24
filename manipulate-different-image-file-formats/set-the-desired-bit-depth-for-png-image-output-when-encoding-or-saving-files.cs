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
        string inputPath = @"C:\Temp\input.png";
        string outputPath = @"C:\Temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        // Configure PNG save options with the desired bit depth
        PngOptions pngOptions = new PngOptions
        {
            // Set bit depth (allowed values: 1,2,4,8,16 depending on color type)
            BitDepth = 8,

            // Example: keep truecolor with alpha (compatible with 8‑bit depth)
            ColorType = PngColorType.TruecolorWithAlpha,

            // Optional: set compression level (0‑9)
            CompressionLevel = 9
        };

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Save the image using the configured PNG options
            image.Save(outputPath, pngOptions);
        }
    }
}