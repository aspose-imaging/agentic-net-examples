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
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\skewed.tif";
            string outputPath = "C:\\Images\\deskewed.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (do not resize, use white background)
                image.NormalizeAngle(false, Color.White);

                // Save the corrected image as PDF
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a scanning workflow receives skewed TIFF documents from a multi-function printer and needs to automatically straighten them before archiving as searchable PDF files.
 * 2. When a legal firm digitizes signed contracts that are saved as TIFF images and wants to correct the tilt and convert them to PDF for e‑filing.
 * 3. When a medical records system imports scanned patient forms in TIFF format, deskews them to improve OCR accuracy, and stores the cleaned pages as PDF reports.
 * 4. When a construction company processes blueprint scans that are slightly rotated, uses C# and Aspose.Imaging to normalize the angle and generate PDF drawings for distribution.
 * 5. When an e‑commerce platform receives product label scans as TIFF files, needs to remove skew for consistent presentation, and saves the result as PDF for catalog publishing.
 */