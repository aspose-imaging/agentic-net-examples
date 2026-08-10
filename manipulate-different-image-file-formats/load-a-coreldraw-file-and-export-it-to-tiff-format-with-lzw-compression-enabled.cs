// HOW-TO: Convert CorelDRAW CDR to TIFF with LZW Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.cdr";
            string outputPath = @"C:\output\sample.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure TIFF options with LZW compression
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw
                };

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
 * 1. When a developer needs to archive vector artwork from CorelDRAW as loss‑less TIFF files for long‑term storage.
 * 2. When an application must generate print‑ready TIFF images from CDR designs while preserving file size using LZW compression.
 * 3. When a workflow converts user‑uploaded CDR files to TIFF to display them in a web viewer that only supports raster formats.
 * 4. When a batch‑processing service transforms multiple CorelDRAW files into compressed TIFFs for downstream image analysis.
 * 5. When integrating Aspose.Imaging into a C# project to replace manual export steps in a design‑to‑production pipeline.
 */
