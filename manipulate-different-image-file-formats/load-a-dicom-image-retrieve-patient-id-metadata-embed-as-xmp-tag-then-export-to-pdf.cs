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
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Retrieve Patient ID from DICOM metadata (if available)
                string patientId = null;
                try
                {
                    // Attempt to read Patient ID from FileInfo if present
                    var fileInfo = dicomImage.FileInfo;
                    var patientIdProp = fileInfo?.GetType().GetProperty("PatientId");
                    if (patientIdProp != null)
                    {
                        patientId = patientIdProp.GetValue(fileInfo) as string;
                    }
                }
                catch
                {
                    // Ignore any errors while retrieving metadata
                }

                // Prepare PDF options and embed Patient ID as document title (metadata)
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    if (!string.IsNullOrEmpty(patientId))
                    {
                        pdfOptions.PdfDocumentInfo.Title = patientId;
                    }

                    // Save DICOM image as PDF with the metadata
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
 * 1. When a radiology software needs to convert DICOM scans into PDF reports while preserving the patient’s identifier as document metadata for easy indexing in electronic health records.
 * 2. When a healthcare integration service must extract the Patient ID from DICOM files and embed it as the PDF title to enable searchable archives in a PACS‑to‑EMR workflow.
 * 3. When a medical research application wants to batch‑process DICOM images, embed study metadata into PDFs, and store them in a document management system that relies on PDF metadata for retrieval.
 * 4. When a telemedicine platform requires on‑the‑fly conversion of diagnostic DICOM images to PDF with patient information attached, so clinicians can view and share the reports without specialized DICOM viewers.
 * 5. When a compliance audit tool needs to generate PDF evidence of imaging studies, ensuring the patient ID is captured in the PDF’s XMP metadata to meet regulatory traceability requirements.
 */