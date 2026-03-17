using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input and output JPEG file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Cache data for optimal performance
            if (!image.IsCached)
                image.CacheData();

            // Adjust image properties
            image.AdjustBrightness(20);          // Increase brightness
            image.AdjustContrast(0.2f);          // Increase contrast
            image.AdjustGamma(1.1f);             // Slight gamma correction

            // Rotate 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Resize to half the original size using high‑quality Lanczos resampling
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Crop 10 pixels from each edge
            var cropRect = new Rectangle(10, 10, image.Width - 20, image.Height - 20);
            image.Crop(cropRect);

            // Configure JPEG save options
            var jpegOptions = new JpegOptions
            {
                Quality = 90,
                CompressionType = JpegCompressionMode.Baseline
            };

            // Save the processed image while preserving JPEG format
            image.Save(outputPath, jpegOptions);
        }
    }
}