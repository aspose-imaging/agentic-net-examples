using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_rotated.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Rotation angle (degrees). Positive values rotate clockwise.
        float angle = 45f; // change as needed

        // Load the BMP image
        using (BmpImage bmpImage = (BmpImage)Image.Load(inputPath))
        {
            // Rotate with proportional resizing and transparent background
            bmpImage.Rotate(angle, true, Color.Transparent);

            // Save the rotated image preserving transparency (default Bitfields compression)
            bmpImage.Save(outputPath, new BmpOptions());
        }
    }
}