using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Apply gamma correction
                tiffImage.AdjustGamma(2.0f);

                // Apply Gaussian blur
                var blurOptions = new GaussianBlurFilterOptions(5, 1.0f);
                tiffImage.Filter(tiffImage.Bounds, blurOptions);

                // Save as PDF
                var pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to improve the visual contrast of a scanned TIFF document and then embed the enhanced image into a PDF report for distribution.
 * 2. When an application must preprocess high‑resolution TIFF photographs by applying gamma correction and a Gaussian blur before converting them to PDF for archival storage.
 * 3. When a medical imaging system requires automatic brightness adjustment and noise reduction on TIFF X‑ray images prior to generating PDF files for patient records.
 * 4. When a publishing workflow needs to standardize the appearance of TIFF artwork by correcting gamma and smoothing edges before creating a print‑ready PDF.
 * 5. When a document management solution must batch‑process TIFF scans, apply image enhancements, and output searchable PDF files for easy retrieval.
 */