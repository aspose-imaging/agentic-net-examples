// HOW-TO: Convert DICOM to PDF with Gaussian Blur and Brightness Adjustment in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage image = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(1, 1.0);
                image.Filter(image.Bounds, gaussianOptions);
                image.AdjustBrightness(15);

                using (PdfOptions pdfOptions = new PdfOptions())
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
 * 1. When a hospital needs to anonymize and enhance X‑ray images before embedding them in patient PDF reports.
 * 2. When a radiology software developer wants to batch‑process DICOM scans, apply a softening filter and increase visibility for better presentation.
 * 3. When a medical research team requires converting raw DICOM files to PDF while adjusting contrast to highlight anatomical details.
 * 4. When a healthcare app must generate printable PDFs from DICOM images with consistent brightness and reduced noise for patient education materials.
 * 5. When a developer integrates Aspose.Imaging into a C# workflow to transform diagnostic images into PDF documents with built‑in Gaussian blur and brightness correction.
 */
