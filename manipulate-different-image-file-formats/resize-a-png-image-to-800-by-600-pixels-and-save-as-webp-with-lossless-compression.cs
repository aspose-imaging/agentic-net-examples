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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.webp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage (required for WebPImage constructor)
                var raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Create a WebPImage from the raster image
                using (WebPImage webpImage = new WebPImage(raster))
                {
                    // Resize to 800x600 using nearest neighbour resampling
                    webpImage.Resize(800, 600, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                    // Prepare lossless WebP options
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save the resized image as lossless WebP
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