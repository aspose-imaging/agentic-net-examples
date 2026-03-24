using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired maximum dimensions
        const int maxWidth = 800;
        const int maxHeight = 600;

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Compute new size while preserving aspect ratio
            double widthRatio = (double)maxWidth / image.Width;
            double heightRatio = (double)maxHeight / image.Height;
            double scale = Math.Min(widthRatio, heightRatio);

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            // Resize using a high‑quality resampling method
            image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save the resized vector image (preserves vector quality)
            image.Save(outputPath);
        }
    }
}