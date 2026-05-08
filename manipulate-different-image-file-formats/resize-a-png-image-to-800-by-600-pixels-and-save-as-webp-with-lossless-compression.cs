using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to RasterImage (base for raster formats like PNG)
                var raster = loadedImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Create a WebPImage from the raster image
                using (WebPImage webpImage = new WebPImage(raster))
                {
                    // Resize to 800x600 using nearest neighbour resampling
                    webpImage.Resize(800, 600, ResizeType.NearestNeighbourResample);

                    // Set lossless compression options
                    var webpOptions = new WebPOptions { Lossless = true };

                    // Save as WebP
                    webpImage.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}