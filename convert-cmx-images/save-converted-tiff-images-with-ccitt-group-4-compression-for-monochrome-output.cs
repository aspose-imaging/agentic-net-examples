using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF options for 1‑bit monochrome with CCITT Group 4 compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 1 };                     // 1 bit per pixel
            tiffOptions.Compression = TiffCompressions.CcittFax4;              // CCITT Group 4
            tiffOptions.Photometric = TiffPhotometrics.MinIsBlack;            // 0 = black, 1 = white
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;   // single plane

            // Save the image as a TIFF using the configured options
            image.Save(outputPath, tiffOptions);
        }
    }
}