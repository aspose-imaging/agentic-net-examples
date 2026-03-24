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
        string inputPath = @"C:\Temp\input.jpg";
        string outputPath = @"C:\Temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TiffOptions with desired settings
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            // 8 bits per color component (RGB)
            BitsPerSample = new ushort[] { 8, 8, 8 },

            // Use Big Endian byte order (Motorola)
            ByteOrder = TiffByteOrder.BigEndian,

            // LZW compression
            Compression = TiffCompressions.Lzw,

            // Predictor for better LZW compression
            Predictor = TiffPredictor.Horizontal,

            // RGB photometric interpretation
            Photometric = TiffPhotometrics.Rgb,

            // Store all components in a single plane
            PlanarConfiguration = TiffPlanarConfigs.Contiguous
        };

        // Load the source image and save it as TIFF using the configured options
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, tiffOptions);
        }
    }
}