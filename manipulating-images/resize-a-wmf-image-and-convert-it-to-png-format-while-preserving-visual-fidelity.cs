using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image, resize, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Example: double the dimensions while preserving visual fidelity
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Resize using Bilinear resampling for better quality
            image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}