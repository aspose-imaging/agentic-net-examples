using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\ResizedResult.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new height to keep aspect ratio for width = 2000
            int newWidth = 2000;
            int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

            // Resize using a high‑quality interpolation method
            image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

            // Save as JPEG
            var jpegOptions = new JpegOptions();
            image.Save(outputPath, jpegOptions);
        }
    }
}