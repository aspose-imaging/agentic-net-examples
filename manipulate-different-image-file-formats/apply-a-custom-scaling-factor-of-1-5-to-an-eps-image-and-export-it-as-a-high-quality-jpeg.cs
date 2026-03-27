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
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample_scaled.jpg";

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
            // Cast to EpsImage for EPS-specific functionality (optional)
            EpsImage epsImage = image as EpsImage;
            if (epsImage == null)
            {
                Console.Error.WriteLine("Loaded image is not an EPS image.");
                return;
            }

            // Calculate new dimensions with scaling factor 1.5
            int newWidth = (int)(epsImage.Width * 1.5);
            int newHeight = (int)(epsImage.Height * 1.5);

            // Resize using a high‑quality resampling method
            epsImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Prepare JPEG save options with high quality
            var jpegOptions = new JpegOptions
            {
                Quality = 100 // maximum quality
            };

            // Save as JPEG
            epsImage.Save(outputPath, jpegOptions);
        }
    }
}