using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

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
            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.AdjustGamma(2.2f);
                }

                using (var pdfOptions = new PdfOptions())
                {
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
 * 1. When a developer needs to improve the brightness and contrast of scanned TIFF documents before converting them to searchable PDF archives for digital libraries.
 * 2. When an application must standardize the visual appearance of medical imaging TIFF files by applying gamma correction and then deliver them as PDF reports to clinicians.
 * 3. When a batch processing tool converts legacy TIFF photographs to PDF while adjusting gamma to ensure consistent exposure across all output pages.
 * 4. When a web service receives high‑resolution TIFF scans, applies gamma correction to match display standards, and returns the result as a PDF for easy viewing in browsers.
 * 5. When a document management system automates the transformation of TIFF invoices, correcting gamma to enhance readability and saving them as PDF files for archival compliance.
 */