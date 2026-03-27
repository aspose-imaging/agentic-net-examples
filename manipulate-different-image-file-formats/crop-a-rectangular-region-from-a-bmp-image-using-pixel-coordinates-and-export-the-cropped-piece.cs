using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Define the rectangle to crop (left, top, width, height)
            // Example: crop a 200x150 region starting at (50,50)
            Rectangle cropArea = new Rectangle(50, 50, 200, 150);

            // Perform the crop operation
            image.Crop(cropArea);

            // Save the cropped image as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}