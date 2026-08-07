using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in tiffFiles)
            {
                // Process only .tif and .tiff extensions
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PDF path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, deskew, and save as PDF
                using (TiffImage image = (TiffImage)Image.Load(inputPath))
                {
                    // Deskew the image (do not resize, use light gray background)
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
 * 1. When a company needs to batch‑process scanned receipts stored as TIFF files, automatically deskew each image and archive them as searchable PDF documents for accounting audits.
 * 2. When a legal firm receives case files in multi‑page TIFF format, they can use this code to correct skewed pages and convert them to PDF for easy review and e‑filing.
 * 3. When a healthcare provider digitizes patient records as TIFF scans, the script deskews the images and saves them as PDF to integrate with electronic health‑record (EHR) systems.
 * 4. When a construction project manager collects site photos in TIFF, the program straightens the pictures and creates PDF portfolios for client presentations.
 * 5. When an archival project migrates historical documents from TIFF to PDF, this C# routine normalizes the image angles and produces clean PDF files for long‑term digital preservation.
 */