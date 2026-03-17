using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Load the single‑frame TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Ensure the image data is cached for faster processing
            if (!image.IsCached)
                image.CacheData();

            // Example processing: increase brightness by 20 units
            image.AdjustBrightness(20);

            // Save the processed image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}