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
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output_lzw.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF save options with LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Predictor = TiffPredictor.Horizontal; // improves LZW size for continuous-tone images

            // Save the image as TIFF using the configured options
            image.Save(outputPath, tiffOptions);
        }

        // Compare file sizes to verify reduction
        long originalSize = new FileInfo(inputPath).Length;
        long tiffSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"Original size: {originalSize} bytes");
        Console.WriteLine($"TIFF (LZW) size: {tiffSize} bytes");

        if (tiffSize < originalSize)
        {
            Console.WriteLine("File size reduced after LZW compression.");
        }
        else
        {
            Console.WriteLine("File size not reduced after LZW compression.");
        }
    }
}