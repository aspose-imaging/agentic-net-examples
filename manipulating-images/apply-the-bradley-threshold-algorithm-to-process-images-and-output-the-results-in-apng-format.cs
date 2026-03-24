using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.BinarizeBradley5_10x10.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access BinarizeBradley
            if (image is RasterImage rasterImage)
            {
                // Apply Bradley adaptive thresholding (brightnessDifference = 5, windowSize = 10)
                rasterImage.BinarizeBradley(5, 10);

                // Save the processed image as APNG
                var apngOptions = new ApngOptions();
                rasterImage.Save(outputPath, apngOptions);
            }
            else
            {
                Console.Error.WriteLine("The loaded image does not support raster operations.");
            }
        }
    }
}