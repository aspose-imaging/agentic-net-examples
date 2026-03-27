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
            // Cast to CdrImage to access RotateFlip
            CdrImage cdrImage = image as CdrImage;
            if (cdrImage == null)
            {
                Console.Error.WriteLine("Loaded image is not a CDR file.");
                return;
            }

            // Apply a horizontal flip
            cdrImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Prepare TIFF save options with LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw
            };

            // Save as TIFF
            cdrImage.Save(outputPath, tiffOptions);
        }
    }
}