using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

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
            // Calculate offset margins (10% of dimensions)
            int leftShift = image.Width / 10;
            int rightShift = image.Width / 10;
            int topShift = image.Height / 10;
            int bottomShift = image.Height / 10;

            // Apply offset-based cropping
            image.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}