// HOW-TO: Batch Convert EMF To TIFF With LZW Compression And 150 DPI In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories (relative to current directory)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists; if not, create it and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all EMF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path with .tif extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure TIFF options: LZW compression and 150 DPI resolution
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    tiffOptions.ResolutionSettings = new ResolutionSetting(150, 150);

                    // Save as TIFF
                    image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive a collection of vector EMF drawings as lossless TIFF files for long‑term storage.
 * 2. When a printing workflow requires all images to be 150 DPI TIFFs with LZW compression before sending to a RIP.
 * 3. When migrating legacy EMF assets to a format supported by web‑based document viewers that only accept TIFF.
 * 4. When generating TIFF thumbnails for a batch of EMF icons while keeping file size low using LZW.
 * 5. When automating a nightly job that converts newly added EMF reports into standardized TIFFs for compliance archives.
 */
