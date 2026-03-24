using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TIFF save options with desired compression and encoding settings
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Compression = TiffCompressions.Lzw;               // LZW compression
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };          // 8 bits per color component
        tiffOptions.Photometric = TiffPhotometrics.Rgb;               // RGB color model
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous; // Single plane storage
        tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;          // Little endian byte order

        // Load the source image and save it as a TIFF using the configured options
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, tiffOptions);
        }
    }
}