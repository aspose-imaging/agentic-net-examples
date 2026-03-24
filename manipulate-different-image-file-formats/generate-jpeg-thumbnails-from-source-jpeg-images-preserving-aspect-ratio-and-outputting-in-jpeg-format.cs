using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output_thumbnail.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Define maximum thumbnail dimensions
            int maxWidth = 150;
            int maxHeight = 150;

            // Calculate scaling factor to preserve aspect ratio
            double scale = Math.Min((double)maxWidth / image.Width, (double)maxHeight / image.Height);
            if (scale > 1) scale = 1; // Do not upscale smaller images

            int thumbWidth = (int)(image.Width * scale);
            int thumbHeight = (int)(image.Height * scale);

            // Resize the image to thumbnail size
            image.Resize(thumbWidth, thumbHeight);

            // Set JPEG save options (e.g., quality)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 80
            };

            // Save the thumbnail as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}