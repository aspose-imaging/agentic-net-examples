using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Resize the image to 800x600 using Lanczos resampling
            image.Resize(800, 600, ResizeType.LanczosResample);

            // Rotate the image 90 degrees clockwise without flipping
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the transformed image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}