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
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the source TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TiffOptions with desired encoding parameters
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // 8 bits per color component (RGB)
                BitsPerSample = new ushort[] { 8, 8, 8 },

                // Use Big Endian byte order (Motorola)
                ByteOrder = TiffByteOrder.BigEndian,

                // LZW compression (good for lossless compression)
                Compression = TiffCompressions.Lzw,

                // Predictor improves LZW compression for continuous-tone images
                Predictor = TiffPredictor.Horizontal,

                // Set the photometric interpretation to RGB
                Photometric = TiffPhotometrics.Rgb,

                // Store all color components in a single plane
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            // Save the image using the configured TiffOptions
            image.Save(outputPath, tiffOptions);
        }
    }
}