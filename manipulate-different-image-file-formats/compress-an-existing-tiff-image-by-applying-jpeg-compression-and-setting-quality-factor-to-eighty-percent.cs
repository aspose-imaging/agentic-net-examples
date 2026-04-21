using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.tif";
            string outputPath = @"C:\Images\compressed.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for JPEG compression with 80% quality
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Jpeg,
                    CompressedQuality = 80,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Save the image with the specified options
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}