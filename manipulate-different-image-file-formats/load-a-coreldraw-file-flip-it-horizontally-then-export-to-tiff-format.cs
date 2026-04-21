using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) image
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Flip the image horizontally
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Prepare default TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the flipped image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}