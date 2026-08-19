// HOW-TO: Convert PNG to Monochrome TIFF with CCITT Group 4 Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for CCITT Group 4 (fax) compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.CcittFax4;          // CCITT Group 4
                tiffOptions.BitsPerSample = new ushort[] { 1 };               // 1‑bit per pixel (monochrome)
                tiffOptions.Photometric = TiffPhotometrics.MinIsBlack;       // 0 = black, 1 = white
                tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                tiffOptions.MultiPageOptions = null;                         // Single‑page output

                // Save the image as a TIFF with the specified options
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate fax‑compatible black‑and‑white TIFF files from scanned PNG images for archival or transmission.
 * 2. When a document‑management system requires 1‑bit per pixel TIFFs to reduce storage size while preserving readability.
 * 3. When converting color or grayscale PNG charts into monochrome TIFFs for inclusion in legacy printing pipelines that only accept CCITT Group 4 compression.
 * 4. When preparing images for OCR engines that perform better on high‑contrast, single‑bit TIFF files.
 * 5. When automating batch processing of scanned forms to create single‑page TIFFs that meet industry standards for electronic filing.
 */
