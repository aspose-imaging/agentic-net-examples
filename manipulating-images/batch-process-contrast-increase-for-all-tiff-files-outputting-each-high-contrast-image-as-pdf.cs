// HOW-TO: Batch Increase Contrast of TIFF Files and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "input";
            string outputDirectory = "output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allTiffFiles, 0);
            tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

            foreach (string inputPath in allTiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Increase contrast (value can be adjusted as needed)
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.AdjustContrast(50); // increase contrast by 50%
                    }

                    // Prepare output PDF path
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to automatically enhance the visual clarity of a large set of scanned TIFF documents before archiving them as PDFs.
 * 2. When a medical imaging workflow requires batch contrast boosting of radiology TIFF images and saving them as PDFs for easier distribution.
 * 3. When a publishing system must prepare high‑contrast TIFF artwork for print‑ready PDF output without manual editing.
 * 4. When a legal firm wants to improve readability of multi‑page TIFF evidence files and store them as PDFs for case management.
 * 5. When a cloud service processes user‑uploaded TIFF photos, applies a contrast filter, and returns PDF versions for download.
 */
