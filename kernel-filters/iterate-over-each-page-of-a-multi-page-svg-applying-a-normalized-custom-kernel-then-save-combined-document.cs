// HOW-TO: Convert Multi‑Page SVG To Multi‑Page TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF output options
                Source outputSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = outputSource
                };

                // Save as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive vector graphics from an SVG file as a lossless, multi‑page TIFF for long‑term storage or compliance.
 * 2. When a reporting system generates charts as SVG and you must convert them to TIFF to embed in PDF reports that only accept raster images.
 * 3. When a batch process must transform user‑uploaded SVG diagrams into TIFF files for printing on high‑resolution printers that require TIFF input.
 * 4. When integrating Aspose.Imaging in a C# application to programmatically convert multi‑page SVG assets into a single TIFF document for easy viewing in standard image viewers.
 * 5. When automating a workflow that consolidates several SVG pages into one TIFF file to simplify distribution to stakeholders who cannot open SVG files.
 */
