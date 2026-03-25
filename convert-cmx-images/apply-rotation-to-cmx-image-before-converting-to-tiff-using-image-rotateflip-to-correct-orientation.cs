using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image, rotate it, and save as TIFF
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise (adjust as needed)
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the rotated image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}