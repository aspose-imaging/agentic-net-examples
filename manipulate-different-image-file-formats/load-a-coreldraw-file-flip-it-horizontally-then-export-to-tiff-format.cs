using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_flipped.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the CorelDRAW (CDR) file
        using (Image image = Image.Load(inputPath))
        {
            // Flip the image horizontally
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the flipped image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}