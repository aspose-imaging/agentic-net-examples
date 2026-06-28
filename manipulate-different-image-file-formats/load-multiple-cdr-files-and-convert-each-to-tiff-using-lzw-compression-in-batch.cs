using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputFiles = new string[]
            {
                @"C:\Input\sample1.cdr",
                @"C:\Input\sample2.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Output\";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image with default load options
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath, new CdrLoadOptions()))
                {
                    int pageIndex = 0;
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        // Configure TIFF save options with LZW compression
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            Compression = TiffCompressions.Lzw,
                            BitsPerSample = new ushort[] { 8, 8, 8 },
                            Photometric = TiffPhotometrics.Rgb,
                            PlanarConfiguration = TiffPlanarConfigs.Contiguous
                        };

                        // Build output file path for each page
                        string outputPath = Path.Combine(
                            outputDir,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a TIFF file
                        page.Save(outputPath, tiffOptions);
                        pageIndex++;
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
 * 1. When a graphic design studio needs to archive a collection of CorelDRAW (.cdr) artwork as lossless TIFF files with LZW compression for long‑term storage, they can use this batch conversion code.
 * 2. When an automated document‑processing pipeline must ingest multiple CDR files and produce TIFF images that are compatible with legacy printing systems, the example shows how to load each file and save each page as a compressed TIFF.
 * 3. When a cloud‑based conversion service wants to offer users the ability to upload several CDR files at once and receive high‑quality TIFF outputs without manual intervention, the code demonstrates the required C# loop and TIFF options.
 * 4. When a quality‑control tool needs to generate TIFF previews of every page in a batch of CorelDRAW files for visual inspection while keeping file size low, the sample illustrates using LZW compression and page‑by‑page processing.
 * 5. When a migration project moves design assets from CorelDRAW to a TIFF‑based digital asset management system, this script provides a straightforward way to convert multiple CDR files to TIFF with proper color and compression settings.
 */