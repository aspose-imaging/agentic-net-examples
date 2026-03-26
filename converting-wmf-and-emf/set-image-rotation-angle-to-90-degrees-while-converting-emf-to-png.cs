using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image, rotate it 90 degrees clockwise, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise without flipping
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the rotated image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}