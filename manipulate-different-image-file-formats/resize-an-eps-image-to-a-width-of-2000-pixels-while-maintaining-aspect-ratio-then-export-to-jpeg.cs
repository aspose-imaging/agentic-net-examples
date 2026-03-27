using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\ResizedResult.jpg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new dimensions while preserving aspect ratio
            int targetWidth = 2000;
            double scaleFactor = (double)targetWidth / image.Width;
            int targetHeight = (int)Math.Round(image.Height * scaleFactor);

            // Resize using a high‑quality interpolation method
            image.Resize(targetWidth, targetHeight, ResizeType.Mitchell);

            // Prepare JPEG save options (default options are sufficient for this example)
            var jpegOptions = new JpegOptions();

            // Save the resized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}