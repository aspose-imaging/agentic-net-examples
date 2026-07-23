using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Deskew the image without resizing canvas and with white background
                tiffImage.NormalizeAngle(false, Color.White);

                // Apply smoothing mode
                Graphics graphics = new Graphics(tiffImage);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to correct the orientation of scanned TIFF documents, deskew them, apply anti‑alias smoothing, and produce a clean PDF for archiving.
 * 2. When an application must convert multi‑page TIFF invoices that are slightly rotated into high‑quality PDF reports while preserving a white background and smooth edges.
 * 3. When a document management system requires automated preprocessing of uploaded TIFF scans—removing skew, applying smoothing mode, and outputting a PDF for downstream workflows.
 * 4. When a legal firm wants to transform skewed TIFF evidence images into readable PDF files with anti‑aliasing to ensure clarity in court filings.
 * 5. When a batch processing tool handles scanned forms in TIFF format, normalizes their angle, enhances visual quality with smoothing, and saves them as PDFs for electronic distribution.
 */