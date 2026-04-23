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
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.jpg";
        string outputPath = @"C:\temp\output_lzw.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF options for LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Lzw;               // LZW compression
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };        // 8 bits per color component
            tiffOptions.Photometric = TiffPhotometrics.Rgb;             // RGB color model
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous; // Single plane
            tiffOptions.ByteOrder = TiffByteOrder.BigEndian;           // Big endian byte order
            tiffOptions.Predictor = TiffPredictor.Horizontal;          // Predictor for better LZW efficiency

            // Save the image as a TIFF file using the configured options
            image.Save(outputPath, tiffOptions);
        }
    }
}