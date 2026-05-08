using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image as a raster image
            using (RasterImage image = Image.Load(inputPath) as RasterImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load the image as a raster image.");
                    return;
                }

                // Rotate according to EXIF orientation
                image.AutoRotate();

                // Prepare lossless WebP options
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save as WebP with lossless compression
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}