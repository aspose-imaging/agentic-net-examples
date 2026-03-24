using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample_binarized.apng";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to a raster image to access BinarizeBradley
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("The loaded image type does not support binarization.");
                return;
            }

            // Apply Bradley adaptive thresholding (brightnessDifference = 5, windowSize = 10)
            raster.BinarizeBradley(5, 10);

            // Save the processed image as an APNG file
            raster.Save(outputPath, new ApngOptions());
        }
    }
}