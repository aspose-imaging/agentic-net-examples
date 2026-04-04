using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
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

        // Configure PNG export options for 24‑bit (Truecolor) lossless storage
        var pngOptions = new PngOptions
        {
            // 8 bits per channel → 24‑bit total (no alpha)
            BitDepth = 8,
            ColorType = PngColorType.Truecolor,
            // Optional: maximum compression while keeping it lossless
            CompressionLevel = 9,
            // Optional: enable progressive loading
            Progressive = true
        };

        // Load the source image and save it as PNG with the specified options
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, pngOptions);
        }
    }
}