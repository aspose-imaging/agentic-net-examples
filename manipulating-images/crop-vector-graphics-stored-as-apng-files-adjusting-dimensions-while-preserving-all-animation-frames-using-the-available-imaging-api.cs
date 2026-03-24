using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output_cropped.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Define cropping parameters (left, right, top, bottom shifts)
            int leftShift = 10;
            int rightShift = 10;
            int topShift = 10;
            int bottomShift = 10;

            // Crop all frames of the APNG image
            apngImage.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped APNG preserving animation frames
            apngImage.Save(outputPath);
        }
    }
}