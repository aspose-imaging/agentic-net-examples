// HOW-TO: Apply Gaussian Blur and Brightness Adjustment to DICOM and Export as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.dicom";
            string outputPath = "Output\\result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

                // Apply Gaussian blur filter to the whole image
                dicomImage.Filter(
                    dicomImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Adjust brightness by +15
                dicomImage.AdjustBrightness(15);

                // Save the result as PDF with default options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    dicomImage.Save(outputPath, pdfOptions);
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
 * 1. When a medical imaging application needs to preprocess DICOM scans by smoothing and brightening them before generating a PDF report.
 * 2. When a radiology workflow requires converting DICOM files to a universally viewable PDF while applying a Gaussian filter to reduce noise.
 * 3. When a developer wants to automate the creation of printable PDFs from DICOM images with consistent brightness enhancement.
 * 4. When integrating Aspose.Imaging into a C# service that prepares DICOM images for archival by applying blur and brightness adjustments prior to PDF storage.
 * 5. When building a diagnostic tool that visualizes DICOM scans with improved clarity and exports them as PDFs for sharing with clinicians.
 */
