using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.BinarizeBradley5_10x10.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Bradley binarization, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access BinarizeBradley method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Bradley's adaptive thresholding
            // brightnessDifference = 5, windowSize = 10
            rasterImage.BinarizeBradley(5, 10);

            // Save the binarized image
            rasterImage.Save(outputPath);
        }
    }
}