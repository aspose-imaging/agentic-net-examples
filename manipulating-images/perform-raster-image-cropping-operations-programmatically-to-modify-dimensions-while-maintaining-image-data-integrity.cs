using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output_cropped.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance (optional)
            if (!image.IsCached)
                image.CacheData();

            // Define a rectangle that represents the central half of the image
            Rectangle cropArea = new Rectangle(
                image.Width / 4,
                image.Height / 4,
                image.Width / 2,
                image.Height / 2);

            // Perform cropping using the rectangle
            image.Crop(cropArea);

            // Save the cropped image
            image.Save(outputPath);
        }
    }
}