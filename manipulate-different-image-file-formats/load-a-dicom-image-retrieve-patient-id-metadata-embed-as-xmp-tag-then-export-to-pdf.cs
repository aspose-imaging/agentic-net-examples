// HOW-TO: Convert DICOM Image to PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.dcm";
            string outputPdfPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                using (var pdfOptions = new PdfOptions())
                {
                    dicomImage.Save(outputPdfPath, pdfOptions);
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
 * 1. When a healthcare application must embed a radiology scan into a patient report, developers can convert the DICOM file to a PDF for easy viewing and printing.
 * 2. When integrating a PACS system with a document management workflow, the code enables automatic transformation of DICOM images into PDF documents for archival compliance.
 * 3. When building a web portal that allows clinicians to download imaging studies, converting DICOM to PDF provides a universally accessible format without requiring specialized viewers.
 * 4. When generating electronic health records that combine text and images, developers can use this snippet to embed diagnostic images as PDF pages alongside other patient data.
 * 5. When creating a batch processing job to migrate legacy DICOM files to a PDF‑based repository, the example shows how to programmatically perform the conversion in C#.
 */
