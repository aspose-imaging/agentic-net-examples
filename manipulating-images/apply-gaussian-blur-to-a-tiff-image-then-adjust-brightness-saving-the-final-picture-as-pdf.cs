using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

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
 * 1. When a developer needs to convert scanned multi‑page TIFF documents into PDF files while applying a Gaussian blur to reduce noise and then increasing brightness for better readability.
 * 2. When an application must preprocess legacy medical imaging TIFF files by smoothing them with a Gaussian blur filter and enhancing brightness before archiving them as PDF reports.
 * 3. When a batch‑processing service automates the preparation of TIFF‑based product catalogs, applying blur to hide sensitive details and adjusting brightness before delivering the final PDF to clients.
 * 4. When a document management system requires on‑the‑fly conversion of uploaded TIFF images to PDF with built‑in image‑processing steps such as Gaussian blur and brightness correction using Aspose.Imaging for .NET.
 * 5. When a developer builds a C# utility that cleans up low‑quality scanned invoices (TIFF) by smoothing edges and brightening the image, then saves the polished result as a PDF for downstream accounting workflows.
 */