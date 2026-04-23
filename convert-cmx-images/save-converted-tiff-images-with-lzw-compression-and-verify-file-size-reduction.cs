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
        string outputPath = @"C:\temp\output.tif";

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
            // Configure TIFF save options with LZW compression and predictor
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Predictor = TiffPredictor.Horizontal;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Save the image as TIFF with the specified options
            image.Save(outputPath, tiffOptions);
        }

        // Compare file sizes to verify reduction
        long originalSize = new FileInfo(inputPath).Length;
        long tiffSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"Original file size: {originalSize} bytes");
        Console.WriteLine($"TIFF file size: {tiffSize} bytes");

        if (tiffSize < originalSize)
        {
            Console.WriteLine("File size reduction achieved.");
        }
        else
        {
            Console.WriteLine("No size reduction (or increase) observed.");
        }
    }
}