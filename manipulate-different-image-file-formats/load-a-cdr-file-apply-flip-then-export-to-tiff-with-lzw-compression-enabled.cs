using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.cdr";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Apply a flip operation (horizontal flip in this example)
            if (image is CdrImage cdrImage)
            {
                cdrImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            // Configure TIFF save options with LZW compression
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw
            };

            // Save the transformed image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}