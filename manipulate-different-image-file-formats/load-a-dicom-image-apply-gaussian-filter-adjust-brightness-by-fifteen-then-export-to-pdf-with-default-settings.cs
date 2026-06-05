using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.dcm";
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
                var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

                // Apply Gaussian blur filter to the entire image
                dicomImage.Filter(
                    dicomImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Adjust brightness by 15
                dicomImage.AdjustBrightness(15);

                // Save as PDF with default options
                var pdfOptions = new PdfOptions();
                dicomImage.Save(outputPath, pdfOptions);
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
 * 1. When a medical imaging application needs to anonymize patient scans by reducing noise with a Gaussian blur, brightening the image for better visibility, and then generating a PDF report for clinicians.
 * 2. When a radiology research tool must preprocess DICOM files—applying a Gaussian filter to smooth artifacts, adjusting brightness by fifteen units, and exporting the result as a PDF for inclusion in publications.
 * 3. When a hospital’s document management system requires converting raw DICOM images into searchable PDF documents after enhancing contrast and reducing grain with a Gaussian blur in a C# workflow.
 * 4. When a telemedicine platform wants to automatically improve the visual quality of uploaded DICOM scans, apply a Gaussian blur to remove high‑frequency noise, increase brightness, and deliver the final image as a PDF attachment.
 * 5. When a health‑tech startup builds a C# service that batch‑processes DICOM images, applies Gaussian blur filtering, brightens them, and saves the output as PDF files for easy distribution to patients.
 */