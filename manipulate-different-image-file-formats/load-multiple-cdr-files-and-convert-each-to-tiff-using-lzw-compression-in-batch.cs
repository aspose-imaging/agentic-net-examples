// HOW-TO: Batch Convert Multiple CDR Files to LZW Compressed TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr",
                @"C:\Input\file3.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Output\";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .tif extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image with default load options
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    var loadOptions = new CdrLoadOptions();
                    using (CdrImage cdrImage = new CdrImage(stream, loadOptions))
                    {
                        // Set up TIFF save options with LZW compression
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            Compression = TiffCompressions.Lzw,
                            BitsPerSample = new ushort[] { 8, 8, 8 },
                            ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.BigEndian,
                            Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
                            PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous
                        };

                        // Save as TIFF
                        cdrImage.Save(outputPath, tiffOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphic design studio needs to archive a collection of CorelDRAW drawings as lossless TIFF files for long‑term storage.
 * 2. When an automated build pipeline must generate print‑ready TIFF images from CDR source files before sending them to a publishing system.
 * 3. When a document management system imports CDR artwork and stores it in a standardized TIFF format with LZW compression to reduce file size.
 * 4. When a batch conversion tool is required to process dozens of CDR files at once, ensuring each output TIFF uses the same compression settings.
 * 5. When a developer wants to integrate CDR‑to‑TIFF conversion into a C# application that validates file existence and creates output directories automatically.
 */
