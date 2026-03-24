using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.Crop.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, crop a central rectangle, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Define a rectangle that represents the central area of the image
            var cropArea = new Rectangle(
                image.Width / 4,          // left offset
                image.Height / 4,         // top offset
                image.Width / 2,          // width
                image.Height / 2);        // height

            // Perform the cropping operation
            image.Crop(cropArea);

            // Save the cropped image using PNG format
            image.Save(outputPath, new PngOptions());
        }
    }
}