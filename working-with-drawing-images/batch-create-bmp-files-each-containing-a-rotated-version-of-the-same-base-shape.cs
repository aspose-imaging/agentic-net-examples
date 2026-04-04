using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input path for the base shape BMP file
        string inputPath = @"C:\temp\base.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory
        string outputDir = @"C:\temp\output";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputDir + Path.DirectorySeparatorChar));

        // Define the rotation angles we want to apply
        int[] angles = new int[] { 0, 90, 180, 270 };

        foreach (int angle in angles)
        {
            // Load the base image for each iteration to avoid mutating the original
            using (Image baseImage = Image.Load(inputPath))
            {
                // Apply rotation
                baseImage.RotateFlip(GetRotateFlipType(angle));

                // Build the output file path
                string outputPath = Path.Combine(outputDir, $"rotated_{angle}.bmp");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Prepare BMP save options
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    Source = new FileCreateSource(outputPath, false) // non‑temporal file
                };

                // Save the rotated image
                baseImage.Save(outputPath, saveOptions);
            }
        }
    }

    // Helper method to map an angle to the corresponding RotateFlipType
    static RotateFlipType GetRotateFlipType(int angle)
    {
        switch (angle % 360)
        {
            case 0:   return RotateFlipType.RotateNoneFlipNone;
            case 90:  return RotateFlipType.Rotate90FlipNone;
            case 180: return RotateFlipType.Rotate180FlipNone;
            case 270: return RotateFlipType.Rotate270FlipNone;
            default:  return RotateFlipType.RotateNoneFlipNone;
        }
    }
}