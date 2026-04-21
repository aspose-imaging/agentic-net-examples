using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded list of CDR files to convert
        string[] inputFiles = new string[]
        {
            @"C:\Images\Input1.cdr",
            @"C:\Images\Input2.cdr",
            @"C:\Images\Input3.cdr"
        };

        // Output directory (hard‑coded)
        string outputDir = @"C:\Images\Converted";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        // Prepare TIFF save options with LZW compression
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Compression = TiffCompressions.Lzw,
            BitsPerSample = new ushort[] { 8, 8, 8 },
            ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.BigEndian,
            Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
            PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Derive output file name (same base name with .tif extension)
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Save as TIFF using the prepared options
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}