using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Desired maximum dimensions (maintain aspect ratio)
        int maxWidth = 800;
        int maxHeight = 600;

        // Load the WebP image using the provided load pattern
        using (WebPImage image = (WebPImage)Image.Load(inputPath))
        {
            // Calculate scaling factor to preserve aspect ratio
            double widthScale = (double)maxWidth / image.Width;
            double heightScale = (double)maxHeight / image.Height;
            double scale = Math.Min(widthScale, heightScale);

            // If the image is already smaller than the target, keep original size
            int newWidth = scale < 1.0 ? (int)(image.Width * scale) : image.Width;
            int newHeight = scale < 1.0 ? (int)(image.Height * scale) : image.Height;

            // Resize using Bilinear resampling for good quality
            image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the resized image as PNG using the provided save pattern
            image.Save(outputPath, new PngOptions());
        }
    }
}