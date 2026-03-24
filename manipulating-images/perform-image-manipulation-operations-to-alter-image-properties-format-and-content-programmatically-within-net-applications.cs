using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Adjust brightness (+30) and contrast (+0.2)
            image.AdjustBrightness(30);
            image.AdjustContrast(0.2f);

            // Rotate 45 degrees with white background, resizing canvas proportionally
            image.Rotate(45f, true, Color.White);

            // Crop 10 pixels from each side
            Rectangle cropRect = new Rectangle(10, 10, image.Width - 20, image.Height - 20);
            image.Crop(cropRect);

            // Resize to 800x600 using high-quality Lanczos resampling
            image.Resize(800, 600, ResizeType.LanczosResample);

            // Save as PNG
            using (PngOptions options = new PngOptions())
            {
                image.Save(outputPath, options);
            }
        }
    }
}