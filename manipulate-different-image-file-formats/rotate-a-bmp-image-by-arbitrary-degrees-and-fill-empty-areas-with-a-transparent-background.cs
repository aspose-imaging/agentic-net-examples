using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (BmpImage image = (BmpImage)Image.Load(inputPath))
        {
            // Rotate by an arbitrary angle (e.g., 45 degrees)
            // resizeProportionally = true to expand canvas,
            // backgroundColor = transparent to fill empty areas.
            float angle = 45f;
            image.Rotate(angle, true, Color.Transparent);

            // Save the rotated image preserving transparency
            image.Save(outputPath, new BmpOptions());
        }
    }
}