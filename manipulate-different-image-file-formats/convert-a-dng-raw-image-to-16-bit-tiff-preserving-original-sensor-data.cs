using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image
        using (Image image = Image.Load(inputPath))
        {
            DngImage dngImage = (DngImage)image;

            // Preserve raw sensor data
            dngImage.UseRawData = true;

            // Configure TIFF options for 16‑bit per channel
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 16, 16, 16 },          // 16 bits for each color component
                Photometric = TiffPhotometrics.Rgb,                  // RGB color model
                Compression = TiffCompressions.None,                // No compression
                PlanarConfiguration = TiffPlanarConfigs.Contiguous // Store components in a single plane
            };

            // Save as 16‑bit TIFF
            dngImage.Save(outputPath, tiffOptions);
        }
    }
}