using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Example processing: rotate the image 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Prepare PNG save options (default options are sufficient here)
            PngOptions pngOptions = new PngOptions();

            // Save the processed image to the output path
            image.Save(outputPath, pngOptions);
        }
    }
}