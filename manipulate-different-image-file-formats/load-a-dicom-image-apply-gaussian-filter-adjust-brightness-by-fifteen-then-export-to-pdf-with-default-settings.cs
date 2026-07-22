using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

                dicomImage.Filter(dicomImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                dicomImage.AdjustBrightness(15);

                dicomImage.Save(outputPath, new PdfOptions());
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
 * 1. When a medical imaging application needs to clean up noisy DICOM scans, apply a Gaussian blur, enhance visibility by increasing brightness, and generate a printable PDF report for clinicians.
 * 2. When a radiology research tool must batch‑process DICOM files, reduce artifact noise, adjust contrast levels, and archive the results as PDF documents for easy sharing.
 * 3. When a hospital’s PACS integration requires converting a single DICOM image into a PDF after smoothing and brightening it to meet diagnostic documentation standards.
 * 4. When a telemedicine platform wants to prepare a DICOM X‑ray for remote review by applying a blur filter, brightening the image, and exporting it to a PDF that can be viewed in any browser.
 * 5. When a healthcare compliance system automates the creation of PDF records from DICOM images, using Gaussian filtering and brightness adjustment to ensure the final PDF meets visual quality guidelines.
 */