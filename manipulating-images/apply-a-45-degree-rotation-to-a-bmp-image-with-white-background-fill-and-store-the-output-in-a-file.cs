using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image, rotate, and save
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Rotate 45 degrees, resize canvas proportionally, fill background with white
            image.Rotate(45f, true, Color.White);

            // Save the rotated image as BMP
            BmpOptions options = new BmpOptions();
            image.Save(outputPath, options);
        }
    }
}