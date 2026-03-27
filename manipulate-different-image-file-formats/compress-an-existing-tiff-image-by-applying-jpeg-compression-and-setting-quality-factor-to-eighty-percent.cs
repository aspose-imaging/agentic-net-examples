using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output\\compressed.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Configure TIFF save options for JPEG compression with 80% quality
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // Set JPEG compression
                Compression = TiffCompressions.Jpeg,
                // Set compression quality to 80
                CompressedQuality = 80,
                // Typical settings for an RGB image
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Save the image using the configured options
            image.Save(outputPath, tiffOptions);
        }
    }
}