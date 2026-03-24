using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\resized.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image srcImage = Image.Load(inputPath))
        {
            // Desired width while preserving aspect ratio
            int targetWidth = 800;
            int newHeight = (int)((double)targetWidth / srcImage.Width * srcImage.Height);

            // Resize using a high‑quality resample method
            srcImage.Resize(targetWidth, newHeight, ResizeType.HighQualityResample);

            // Save the resized image as APNG
            var apngOptions = new ApngOptions();
            srcImage.Save(outputPath, apngOptions);
        }
    }
}