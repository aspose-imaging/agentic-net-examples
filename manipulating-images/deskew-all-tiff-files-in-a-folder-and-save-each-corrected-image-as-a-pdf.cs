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
            // Hardcoded input and output folders
            string inputFolder = @"C:\InputTiffs\";
            string outputFolder = @"C:\OutputPdfs\";

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in tiffFiles)
            {
                // Process only .tif and .tiff extensions
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Prepare output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, deskew, and save as PDF
                using (TiffImage image = (TiffImage)Image.Load(filePath))
                {
                    // Deskew the image (do not resize, use LightGray background)
                    image.NormalizeAngle(false, Color.LightGray);

                    // Save as PDF
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
 * 1. When a developer needs to automatically correct skewed scanned TIFF documents and convert each one into a PDF for easy archiving.
 * 2. When a batch‑processing tool must deskew all TIFF files in a folder and output them as PDFs to improve readability.
 * 3. When an enterprise workflow requires normalizing the angle of incoming TIFF images before saving them as PDFs for downstream OCR.
 * 4. When a C# application has to process a directory of multi‑page TIFF scans, remove tilt with a light‑gray background, and export each image as a PDF.
 * 5. When a document management system needs to programmatically deskew and convert scanned TIFF files to PDF using Aspose.Imaging for consistent document presentation.
 */