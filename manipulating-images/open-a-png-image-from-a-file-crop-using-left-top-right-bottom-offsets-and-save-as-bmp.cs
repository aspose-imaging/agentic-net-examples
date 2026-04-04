using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Offsets for cropping: left, top, right, bottom
            int leftShift = 10;
            int topShift = 20;
            int rightShift = 10;
            int bottomShift = 20;

            // Crop the image using the specified offsets
            image.Crop(leftShift, rightShift, topShift, bottomShift);

            // Prepare BMP save options (default options are sufficient)
            BmpOptions bmpOptions = new BmpOptions();

            // Save the cropped image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}