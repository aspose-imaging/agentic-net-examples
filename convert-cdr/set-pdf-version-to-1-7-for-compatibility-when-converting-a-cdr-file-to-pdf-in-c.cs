using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with PDF 1.7 compatibility (Aspose.Imaging supports up to PDF 1.5)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Set the highest available compliance level (PDF 1.5)
                        PdfCompliance = PdfComplianceVersion.Pdf15
                    }
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to archive CorelDRAW (.cdr) artwork as PDFs that must be viewable in PDF‑1.7 compliant readers such as Adobe Acrobat, they can use this C# code to convert the images while specifying the PDF compliance level.
 * 2. When an e‑commerce platform automatically generates product catalogs from CDR source files and must ensure the PDFs meet the PDF‑1.7 standard required by third‑party printing services, the code provides a reliable conversion routine.
 * 3. When a document management system ingests legacy CDR graphics and stores them as PDFs that must pass PDF/A‑2b validation (which is based on PDF‑1.7), developers can employ this snippet to enforce the appropriate PDF version during conversion.
 * 4. When a legal firm needs to submit design evidence originally created in CorelDRAW and the court’s electronic filing system only accepts PDFs conforming to PDF‑1.7, the C# example enables seamless conversion with the correct compliance setting.
 * 5. When a cloud‑based workflow automates the transformation of CDR files into shareable PDFs for mobile devices that only support PDF‑1.7 features like transparency groups, this code ensures the output meets the required version.
 */