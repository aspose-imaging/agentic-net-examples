using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output/output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is a WebPImage, resize it
            if (image is WebPImage webp)
            {
                int newWidth = webp.Width / 2;
                int newHeight = webp.Height / 2;

                // Resize using high-quality resampling
                webp.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                // Save the resized animation as APNG
                webp.Save(outputPath, new ApngOptions());
            }
            else
            {
                // Fallback: save without resizing if not a WebPImage
                image.Save(outputPath, new ApngOptions());
            }
        }
    }
}