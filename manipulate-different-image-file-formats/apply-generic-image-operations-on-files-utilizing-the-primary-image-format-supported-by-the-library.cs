using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging.Image.Load (provided rule)
        using (Image image = Image.Load(inputPath))
        {
            // Example generic operation: rotate the image 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Prepare PNG save options (primary format supported)
            PngOptions saveOptions = new PngOptions();

            // Save the processed image to the output path (provided rule)
            image.Save(outputPath, saveOptions);
        }
    }
}