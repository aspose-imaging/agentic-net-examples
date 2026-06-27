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
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for CCITT Group 4 compression (black‑and‑white)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 1 };                         // 1‑bit per pixel
                tiffOptions.Compression = TiffCompressions.CcittFax4;                  // CCITT Group 4
                tiffOptions.Photometric = TiffPhotometrics.MinIsBlack;                // 0 = black, 1 = white

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
 * 1. When a developer needs to convert vector EMF drawings into compact black‑and‑white TIFF files for fax‑compatible archival using C# and Aspose.Imaging with CCITT Group 4 compression.
 * 2. When an application must generate high‑resolution, 1‑bit per pixel TIFF images from EMF logos for inclusion in legal documents that require a lossless, monochrome format.
 * 3. When a document management system processes uploaded EMF schematics and stores them as space‑efficient TIFF files with CCITT Group 4 compression to reduce storage costs.
 * 4. When a batch‑processing tool automates the conversion of EMF engineering diagrams to black‑and‑white TIFFs for printing on legacy line printers that only support monochrome TIFF.
 * 5. When a developer integrates Aspose.Imaging into a C# workflow to ensure EMF graphics are saved as TIFF with MinIsBlack photometric interpretation for accurate black‑on‑white rendering in OCR pipelines.
 */