using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Define cropping offsets (left, right, top, bottom)
            int leftShift = 50;   // example offset from the left edge
            int rightShift = 50;  // example offset from the right edge
            int topShift = 30;    // example offset from the top edge
            int bottomShift = 30; // example offset from the bottom edge

            // Perform the crop operation
            image.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}