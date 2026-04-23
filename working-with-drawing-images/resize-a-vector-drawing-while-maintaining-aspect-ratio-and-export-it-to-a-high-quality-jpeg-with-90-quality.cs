using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Desired maximum dimensions for the resized image
            int maxWidth = 1024;
            int maxHeight = 768;

            // Compute scaling factor while preserving aspect ratio
            double widthRatio = (double)maxWidth / image.Width;
            double heightRatio = (double)maxHeight / image.Height;
            double scale = Math.Min(widthRatio, heightRatio);

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            // Resize using a high‑quality resampling method
            image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

            // Configure JPEG export options with 90 % quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the resized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}