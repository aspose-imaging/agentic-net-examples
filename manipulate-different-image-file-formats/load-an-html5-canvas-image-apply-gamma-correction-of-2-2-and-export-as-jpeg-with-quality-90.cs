using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\canvas.html";
        string outputPath = @"C:\temp\canvas_corrected.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (HTML5 canvas file)
        using (Image image = Image.Load(inputPath))
        {
            // Apply gamma correction (2.2) – cast to a raster type that supports AdjustGamma
            if (image is RasterImage rasterImage)
            {
                rasterImage.AdjustGamma(2.2f);
            }
            else if (image is RasterCachedImage cachedImage)
            {
                cachedImage.AdjustGamma(2.2f);
            }
            // If the image type does not support AdjustGamma, it will be saved unchanged

            // Prepare JPEG options with quality 90
            var jpegOptions = new JpegOptions { Quality = 90 };

            // Save the processed image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}