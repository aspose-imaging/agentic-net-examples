using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            // Also include *.tiff files
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

                // Build output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, adjust contrast, and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    // Increase contrast by 50 (range -100 to 100)
                    tiffImage.AdjustContrast(50f);

                    // Save as PDF using default PDF options
                    PdfOptions pdfOptions = new PdfOptions();
                    tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When a medical imaging department needs to batch‑convert scanned DICOM‑derived TIFF radiographs into high‑contrast PDF reports for easier review and archiving.
 * 2. When a legal firm must process thousands of scanned contract pages stored as TIFF files, boost their readability by increasing contrast, and generate searchable PDF documents for case management.
 * 3. When a publishing house automates the preparation of legacy manuscript scans in TIFF format, enhancing contrast to improve OCR accuracy before saving each page as a PDF for digital distribution.
 * 4. When a construction company wants to quickly improve the visibility of blueprint scans saved as TIFF files and bundle them into PDF files for on‑site tablet viewing.
 * 5. When a government agency archives historical maps stored as TIFF images, applies a uniform contrast enhancement, and converts them to PDF to ensure consistent presentation across public portals.
 */