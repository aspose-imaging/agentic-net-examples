using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\cropped.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Define offset values (left, right, top, bottom)
            int leftShift = 10;
            int rightShift = 10;
            int topShift = 20;
            int bottomShift = 20;

            // Perform offset-based cropping
            image.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image as APNG
            image.Save(outputPath, new ApngOptions());
        }
    }
}