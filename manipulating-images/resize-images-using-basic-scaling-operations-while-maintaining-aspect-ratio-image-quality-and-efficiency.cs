using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_resized.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Desired maximum width (maintain aspect ratio)
            const int maxWidth = 800;

            // Calculate new dimensions while preserving aspect ratio
            int newWidth = image.Width;
            int newHeight = image.Height;

            if (image.Width > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = (int)Math.Round((double)image.Height * maxWidth / image.Width);
            }

            // Resize using a high‑quality resampling method (Mitchell)
            image.Resize(newWidth, newHeight, ResizeType.Mitchell);

            // Save the resized image (format inferred from file extension)
            image.Save(outputPath);
        }
    }
}