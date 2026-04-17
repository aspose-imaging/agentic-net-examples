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
        string inputPath = @"C:\Images\sample.jpg";
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
            // Configure PNG save options with a balanced compression level
            var pngOptions = new PngOptions
            {
                Progressive = true,                         // Enable progressive loading (optional)
                ColorType = PngColorType.TruecolorWithAlpha, // Preserve full color depth and alpha
                CompressionLevel = 6                         // Compression level 0‑9; 6 offers a good size/quality trade‑off
            };

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}