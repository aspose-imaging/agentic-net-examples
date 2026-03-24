using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image, perform operations, and save
        using (BmpImage image = (BmpImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Resize to 200x200 pixels
            image.Resize(200, 200);

            // Crop a rectangle (10,10) with size 180x180
            image.Crop(new Rectangle(10, 10, 180, 180));

            // Increase brightness by 30 units
            image.AdjustBrightness(30);

            // Increase contrast by 0.2 (float)
            image.AdjustContrast(0.2f);

            // Save the processed image
            image.Save(outputPath);
        }
    }
}