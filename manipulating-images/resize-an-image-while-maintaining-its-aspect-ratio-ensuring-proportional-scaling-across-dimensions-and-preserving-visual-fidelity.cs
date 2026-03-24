using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            // Desired maximum width (you can adjust as needed)
            int targetWidth = 800;

            // Compute proportional height to maintain aspect ratio
            double scaleFactor = (double)targetWidth / image.Width;
            int targetHeight = (int)Math.Round(image.Height * scaleFactor);

            // Perform high‑quality proportional resize
            image.Resize(targetWidth, targetHeight, ResizeType.HighQualityResample);

            // Save the resized image (format inferred from file extension)
            image.Save(outputPath);
        }
    }
}