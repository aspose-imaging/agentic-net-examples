// HOW-TO: Adjust Brightness Contrast and Gamma of DICOM and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.dcm";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access adjustment methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust brightness (range -255 to 255)
                dicomImage.AdjustBrightness(30);

                // Adjust contrast (range -100 to 100)
                dicomImage.AdjustContrast(20f);

                // Adjust gamma (single value applied to all channels)
                dicomImage.AdjustGamma(1.2f);

                // Save the processed image as PDF
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
 * 1. When a medical imaging application needs to enhance a DICOM X‑ray by increasing brightness, contrast, and gamma before generating a PDF report for clinicians.
 * 2. When a radiology workflow requires converting processed DICOM scans into PDF files for easy sharing with patients who cannot view DICOM viewers.
 * 3. When a healthcare integration service must programmatically adjust image quality of DICOM files to meet visual standards before archiving them as PDFs.
 * 4. When a diagnostic software needs to batch‑process DICOM images, apply consistent visual adjustments, and store the results in a portable PDF format for electronic health records.
 * 5. When a developer wants to demonstrate image‑processing capabilities by loading a DICOM, tweaking its visual parameters, and exporting the result as a PDF document in a .NET application.
 */
