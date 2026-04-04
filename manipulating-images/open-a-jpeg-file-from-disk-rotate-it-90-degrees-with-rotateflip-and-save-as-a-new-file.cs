using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image, rotate it 90 degrees clockwise, and save the result
        using (Image image = Image.Load(inputPath))
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            image.Save(outputPath);
        }
    }
}