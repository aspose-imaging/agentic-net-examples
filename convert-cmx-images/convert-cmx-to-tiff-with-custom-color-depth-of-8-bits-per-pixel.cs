using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.cmx";
        string outputPath = @"c:\temp\output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Configure TIFF save options for 8 bits per color component
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },                     // 8 bits per sample (RGB)
                    ByteOrder = TiffByteOrder.BigEndian,                        // Motorola byte order
                    Compression = TiffCompressions.Lzw,                         // LZW compression
                    Photometric = TiffPhotometrics.Rgb,                         // RGB photometric
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous         // Single plane
                };

                // Save the image as TIFF using the configured options
                cmxImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}