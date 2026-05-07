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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    // 8 bits per color component (RGB)
                    BitsPerSample = new ushort[] { 8, 8, 8 },

                    // Use Big Endian byte order (Motorola)
                    ByteOrder = TiffByteOrder.BigEndian,

                    // LZW compression
                    Compression = TiffCompressions.Lzw,

                    // Predictor improves LZW efficiency for continuous-tone images
                    Predictor = TiffPredictor.Horizontal,

                    // RGB photometric interpretation
                    Photometric = TiffPhotometrics.Rgb,

                    // Store all components in a single plane
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the image as TIFF with the configured options
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}