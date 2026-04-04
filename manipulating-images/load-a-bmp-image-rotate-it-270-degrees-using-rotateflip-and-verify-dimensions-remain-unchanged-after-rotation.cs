using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\rotated.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image, rotate, verify dimensions, and save
        using (Image image = Image.Load(inputPath))
        {
            // Store original dimensions
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // Rotate 270 degrees clockwise without flipping
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);

            // Verify dimensions remain unchanged
            bool dimensionsUnchanged = (image.Width == originalWidth) && (image.Height == originalHeight);
            Console.WriteLine(dimensionsUnchanged
                ? "Dimensions unchanged after rotation."
                : "Dimensions changed after rotation.");

            // Save the rotated image
            image.Save(outputPath);
        }
    }
}