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
        string inputPath = "input.tif";
        string outputPath = "output.webp";

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
            // Load the TIFF image
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                // Auto-rotate based on EXIF orientation
                rasterImage.AutoRotate();

                // Convert to WebP with lossless compression
                using (WebPImage webpImage = new WebPImage(rasterImage))
                {
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

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