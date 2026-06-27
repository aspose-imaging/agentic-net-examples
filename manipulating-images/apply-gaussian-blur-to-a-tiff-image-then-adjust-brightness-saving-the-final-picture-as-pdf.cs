using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.tif";
        string outputPath = "Output\\result.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Adjust brightness
                tiffImage.AdjustBrightness(50);

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
 * 1. When a developer needs to preprocess scanned TIFF documents by softening noise with a Gaussian blur, brightening the image, and delivering the result as a searchable PDF for archival.
 * 2. When an imaging application must convert high‑resolution medical TIFF scans into PDF reports while enhancing visibility through blur and brightness adjustments.
 * 3. When a document management system requires automated preparation of TIFF blueprints, applying blur to reduce fine detail, increasing brightness for readability, and exporting to PDF for client distribution.
 * 4. When a batch‑processing tool needs to improve the legibility of old TIFF photographs by smoothing edges, boosting brightness, and packaging them as PDF portfolios.
 * 5. When a web service generates printable PDFs from user‑uploaded TIFF invoices, using Gaussian blur to mask sensitive details, adjusting brightness for consistent appearance, and saving the final document as PDF.
 */