using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW (CDR) file
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                // Save as TIFF
                cdr.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW (CDR) artwork into a lossless, web‑compatible TIFF image with LZW compression for archival or publishing workflows.
 * 2. When an automated batch process must read CDR files from a folder and generate compressed TIFF files for integration into a document management system.
 * 3. When a graphics application requires extracting vector designs from CorelDRAW and saving them as RGB TIFFs with 8‑bit per channel depth for high‑quality print previews.
 * 4. When a .NET service has to validate that a CorelDRAW file exists, create the output directory, and export the image to a TIFF file using Aspose.Imaging’s TiffOptions to ensure consistent compression.
 * 5. When a developer is building a migration tool that transforms legacy CDR assets into LZW‑compressed TIFFs to reduce storage size while preserving color fidelity.
 */