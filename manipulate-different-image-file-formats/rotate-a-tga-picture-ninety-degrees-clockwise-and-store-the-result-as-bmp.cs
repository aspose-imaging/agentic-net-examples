using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.tga";
        string outputPath = @"C:\Images\Rotated\result.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image, rotate 90 degrees clockwise, and save as BMP
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise without flipping
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the rotated image as BMP
            image.Save(outputPath);
        }
    }
}