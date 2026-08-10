// HOW-TO: Convert CMX Stream To TIFF In Memory With Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.tif";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX data into memory
            byte[] cmxData = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(cmxData))
            {
                // Load CMX image from the memory stream
                using (CmxImage cmxImage = (CmxImage)Image.Load(ms))
                {
                    // Prepare TIFF save options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Source = new FileCreateSource(outputPath, false);

                    // Save CMX as TIFF directly from memory
                    cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to transform a CorelDRAW CMX file received as a byte array into a TIFF image without writing intermediate files to disk.
 * 2. When a web service processes uploaded CMX documents in memory and must return a high‑resolution TIFF for downstream reporting.
 * 3. When a batch job reads CMX files from a network share, converts them to TIFF, and stores the results in a different folder while preserving the original directory structure.
 * 4. When you want to integrate CMX‑to‑TIFF conversion into a C# application that runs in a sandboxed environment where file‑system access is limited.
 * 5. When you must ensure the output TIFF is created with Aspose.Imaging’s default options and avoid temporary storage for performance or security reasons.
 */
