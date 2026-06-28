using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access adjustment methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust brightness, contrast, and gamma sequentially
                dicomImage.AdjustBrightness(30);          // increase brightness
                dicomImage.AdjustContrast(20f);           // increase contrast
                dicomImage.AdjustGamma(1.2f);             // apply gamma correction

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
 * 1. When a radiology software needs to convert a DICOM X‑ray image to a printable PDF while enhancing visibility by increasing brightness, contrast, and applying gamma correction.
 * 2. When a medical research application must batch‑process DICOM scans, improve their visual quality, and archive the results as PDF reports for easy sharing.
 * 3. When a hospital’s PACS integration requires on‑the‑fly adjustment of DICOM image parameters before exporting the study to a PDF for patient records.
 * 4. When a telemedicine platform wants to display clearer diagnostic images by programmatically tweaking DICOM brightness, contrast, and gamma, then delivering them as PDFs to clinicians.
 * 5. When a health‑tech developer needs to generate PDF documentation from DICOM files with standardized image enhancements for compliance audits.
 */