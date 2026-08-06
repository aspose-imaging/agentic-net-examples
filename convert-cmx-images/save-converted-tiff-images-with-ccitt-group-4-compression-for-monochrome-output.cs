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
            string inputPath = "C:\\temp\\input.png";
            string outputPath = "C:\\temp\\output.tif";

            // Verify input file exists
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
                // Configure TIFF options for CCITT Group 4 (monochrome) compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.CcittFax4;   // CCITT Group 4
                tiffOptions.BitsPerSample = new ushort[] { 1 };        // 1 bit per pixel
                tiffOptions.Photometric = TiffPhotometrics.MinIsBlack; // Black = 0

                // Save the image as TIFF with the specified options
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
 * 1. When a developer needs to generate fax‑compatible monochrome documents by converting PNG scans to TIFF files with CCITT Group 4 compression for minimal file size.
 * 2. When an archival system requires storing black‑and‑white engineering drawings as 1‑bit per pixel TIFF images to preserve quality while reducing storage costs.
 * 3. When a medical imaging workflow must transform scanned pathology slides from PNG to a standard TIFF format with MinIsBlack photometric interpretation for downstream analysis tools.
 * 4. When a printing pipeline needs to create high‑speed, low‑bandwidth print jobs by converting color PNG assets to monochrome TIFF using Aspose.Imaging in a C# application.
 * 5. When a document management solution automates the conversion of user‑uploaded PNG receipts into compact, searchable TIFF files that comply with CCITT Group 4 fax standards.
 */