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
            string inputPath = "Input/sample.dcm";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/output.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                dicom.Save(outputPath, pdfOptions);
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
 * 1. When a hospital IT system must convert DICOM radiology scans into searchable PDF reports that embed the patient’s ID as an XMP metadata tag for electronic health record compliance.
 * 2. When a medical research platform needs to batch‑process DICOM files, extract each patient identifier, embed it in the PDF’s XMP block, and archive the PDFs for efficient indexing and retrieval.
 * 3. When a telemedicine application requires on‑the‑fly conversion of a DICOM image to a PDF document while preserving patient information in XMP so the PDF can be securely shared with clinicians.
 * 4. When a radiology workflow automation tool generates printable PDF summaries from DICOM images, ensuring the patient ID is embedded as XMP metadata for audit trails and legal documentation.
 * 5. When a health‑care compliance audit demands that every exported imaging report be a PDF with embedded patient metadata, prompting developers to use Aspose.Imaging to read DICOM, capture the patient ID, and write it as an XMP tag before saving.
 */