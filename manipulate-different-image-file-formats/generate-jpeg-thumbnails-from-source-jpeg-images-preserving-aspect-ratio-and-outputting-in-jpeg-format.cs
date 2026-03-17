using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputDir = "InputImages";
        string outputDir = "Thumbnails";

        // Desired maximum thumbnail dimensions
        int maxWidth = 150;
        int maxHeight = 150;

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Process each JPEG file in the input directory
        foreach (string inputPath in Directory.GetFiles(inputDir, "*.jpg"))
        {
            // Load the source image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!image.IsCached)
                {
                    image.CacheData();
                }

                // Calculate scaling factor to preserve aspect ratio
                double widthScale = (double)maxWidth / image.Width;
                double heightScale = (double)maxHeight / image.Height;
                double scale = Math.Min(widthScale, heightScale);
                // Do not upscale images smaller than the target size
                scale = Math.Min(1.0, scale);

                int thumbWidth = Math.Max(1, (int)(image.Width * scale));
                int thumbHeight = Math.Max(1, (int)(image.Height * scale));

                // Resize the image to thumbnail dimensions
                image.Resize(thumbWidth, thumbHeight);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 75 // Adjust quality as needed
                };

                // Build output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.jpg");

                // Save the thumbnail as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}