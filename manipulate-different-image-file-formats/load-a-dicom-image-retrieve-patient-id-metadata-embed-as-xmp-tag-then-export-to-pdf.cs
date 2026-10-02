// HOW-TO: Convert DICOM Image To PDF With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.dcm";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    dicom.Save(outputPath, pdfOptions);
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
 * 1. When a healthcare application must generate a printable PDF report from a DICOM scan for clinicians to review.
 * 2. When a hospital information system needs to archive radiology images as PDF files to comply with document management policies.
 * 3. When a telemedicine platform wants to embed DICOM images into patient records that are stored as PDFs for easy sharing.
 * 4. When a medical research tool requires batch conversion of DICOM files to PDFs for inclusion in study publications.
 * 5. When a diagnostic software needs to convert a single DICOM image to PDF on the fly for integration with non‑medical document workflows.
 */
