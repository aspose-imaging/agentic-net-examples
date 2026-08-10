// HOW-TO: Batch Deskew TIFF Images and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputFolder);

            // Process each TIFF file in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly))
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                    continue; // Skip non‑TIFF files

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Prepare output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, deskew, and save as PDF
                using (TiffImage image = (TiffImage)Image.Load(filePath))
                {
                    // Deskew the image (do not resize, use LightGray background)
                    image.NormalizeAngle(false, Color.LightGray);

                    // Save as PDF using default PDF options
                    PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to automatically straighten scanned TIFF documents and archive them as searchable PDFs.
 * 2. When a batch of scanned receipts saved as TIFF files must be deskewed before being shared with accounting in PDF format.
 * 3. When a medical imaging workflow requires correcting orientation of TIFF X‑ray images and converting them to PDF reports.
 * 4. When a legal firm wants to preprocess TIFF evidence files by removing skew and packaging each as a PDF for case management.
 * 5. When an automated document pipeline must process incoming TIFF files, normalize their angle, and output PDFs for downstream OCR processing.
 */
