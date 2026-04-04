using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\vector.svg";
        string outputPath = @"C:\Images\Resized\vector_resized.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Desired maximum dimensions while preserving aspect ratio
            const int maxWidth = 800;
            const int maxHeight = 800;

            // Calculate scaling factor
            double widthScale = (double)maxWidth / image.Width;
            double heightScale = (double)maxHeight / image.Height;
            double scale = Math.Min(widthScale, heightScale);
            if (scale > 1) scale = 1; // Do not upscale beyond original size

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            // Resize while maintaining aspect ratio
            image.Resize(newWidth, newHeight);

            // Prepare JPEG save options with 90% quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save as high‑quality JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}