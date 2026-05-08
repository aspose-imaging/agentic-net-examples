using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input CDR files
            string[] inputPaths = new[]
            {
                @"C:\Input\sample1.cdr",
                @"C:\Input\sample2.cdr",
                @"C:\Input\sample3.cdr"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output TIFF path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".tif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image
                using (FileStream stream = File.OpenRead(inputPath))
                using (CdrImage cdrImage = new CdrImage(stream, new CdrLoadOptions()))
                {
                    // Configure TIFF save options with LZW compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        BitsPerSample = new ushort[] { 8, 8, 8 },
                        ByteOrder = TiffByteOrder.BigEndian,
                        Compression = TiffCompressions.Lzw,
                        Photometric = TiffPhotometrics.Rgb,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                        Predictor = TiffPredictor.Horizontal
                    };

                    // Save as TIFF
                    cdrImage.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}