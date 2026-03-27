using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage (required for WebP conversion)
            var raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("The input file is not a raster image.");
                return;
            }

            // Create a WebP image from the raster image
            using (WebPImage webpImage = new WebPImage(raster))
            {
                // Resize to 800x600 using nearest neighbour resampling
                webpImage.Resize(800, 600, ResizeType.NearestNeighbourResample);

                // Save as lossless WebP
                var webpOptions = new WebPOptions { Lossless = true };
                webpImage.Save(outputPath, webpOptions);
            }
        }
    }
}