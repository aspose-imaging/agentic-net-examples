using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_rotated.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply rotation/flip, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise and flip horizontally
            image.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save the transformed image to the output path
            image.Save(outputPath);
        }
    }
}