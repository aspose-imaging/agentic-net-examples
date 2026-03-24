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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF options with Deflate compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Deflate; // Deflate compression
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 }; // 8 bits per color component
            tiffOptions.Photometric = TiffPhotometrics.Rgb; // RGB color model
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous; // Single plane

            // Save the image as TIFF using the configured options
            image.Save(outputPath, tiffOptions);
        }
    }
}