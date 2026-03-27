using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Dng;

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

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare TIFF saving options with 16‑bit per channel
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 16, 16, 16 }, // 16‑bit for R, G, B
                Photometric = TiffPhotometrics.Rgb,
                Compression = TiffCompressions.None,
                // Preserve original metadata if needed
                ExifData = ((DngImage)image).ExifData,
                XmpData = ((DngImage)image).XmpData
            };

            // Save as 16‑bit TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}