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
        string outputPath = @"C:\Images\output_cropped.bmp";

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
            // Adjust these values as needed for the desired region
            int left = 50;
            int top = 50;
            int width = 200;
            int height = 150;
            Rectangle cropArea = new Rectangle(left, top, width, height);

            // Perform the cropping operation
            image.Crop(cropArea);

            // Save the cropped image to the output path
            image.Save(outputPath);
        }
    }
}