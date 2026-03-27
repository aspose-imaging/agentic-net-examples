using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input CDR files
        string[] inputFiles = new[]
        {
            @"C:\Input\Sample1.cdr",
            @"C:\Input\Sample2.cdr",
            @"C:\Input\Sample3.cdr"
        };

        // Hard‑coded output directory
        string outputDir = @"C:\Output";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output TIFF path (same base name, .tif extension)
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image with default load options
            using (Image image = Image.Load(inputPath, new CdrLoadOptions()))
            {
                // Configure TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    // Optional: set other typical TIFF settings
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}