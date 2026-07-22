using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image and save as PDF
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
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
 * 1. When a radiology department wants to convert DICOM X‑ray images to PDF files for easy viewing and printing using C# and Aspose.Imaging.
 * 2. When a medical research application must batch‑process DICOM scans and store them as PDF documents for inclusion in study reports.
 * 3. When a healthcare web service needs to expose a REST endpoint that receives a DICOM file and returns a PDF version for integration with electronic health record (EHR) systems.
 * 4. When a desktop utility is built to let clinicians select a DICOM file and instantly generate a PDF that can be attached to patient discharge summaries.
 * 5. When a compliance tool requires converting DICOM images to PDF to archive them in a non‑proprietary format that can be indexed by document management systems.
 */