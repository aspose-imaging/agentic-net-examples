using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Optional: cache data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Calculate new dimensions (example: half the original size)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Perform resizing while preserving transparency
            image.Resize(newWidth, newHeight);

            // Save the resized image as an APNG, preserving alpha channel
            var apngOptions = new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, apngOptions);
        }
    }
}