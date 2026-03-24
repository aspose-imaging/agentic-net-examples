using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Apply rotation and flip to each frame
            for (int i = 0; i < apng.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apng.Pages[i];
                frame.RotateFlip(RotateFlipType.Rotate90FlipX); // Example: rotate 90° and flip horizontally
            }

            // Save the transformed APNG
            apng.Save(outputPath);
        }
    }
}