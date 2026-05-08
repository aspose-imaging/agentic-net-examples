using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
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
                // Configure TIFF options for LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.Predictor = TiffPredictor.Horizontal; // improves LZW compression

                // Save the image as TIFF with the specified options
                image.Save(outputPath, tiffOptions);
            }

            // Compare file sizes to verify reduction
            long originalSize = new FileInfo(inputPath).Length;
            long tiffSize = new FileInfo(outputPath).Length;

            if (tiffSize < originalSize)
            {
                Console.WriteLine($"Success: TIFF size reduced from {originalSize} to {tiffSize} bytes.");
            }
            else
            {
                Console.WriteLine($"Warning: TIFF size ({tiffSize} bytes) is not smaller than original ({originalSize} bytes).");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}