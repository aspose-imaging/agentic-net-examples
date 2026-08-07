using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputEps";
            string outputDirectory = @"C:\OutputPdf";

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine the output PDF path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
                {
                    // Configure PDF options with compliance and a confidential watermark in metadata
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            PdfCompliance = PdfComplianceVersion.PdfA1b
                        },
                        PdfDocumentInfo = new PdfDocumentInfo
                        {
                            Title = "Confidential"
                        }
                    };

                    // Save the EPS as a PDF
                    epsImage.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to batch‑convert a folder of Adobe Illustrator EPS artwork into PDF/A‑1b compliant PDFs while automatically adding a “Confidential” watermark in the document metadata.
 * 2. When a legal department must archive EPS‑based contract diagrams as secure PDFs, embedding a confidentiality flag to satisfy record‑keeping regulations.
 * 3. When an engineering firm wants to automate the transformation of EPS schematics into searchable PDF files for client distribution, with a built‑in “Confidential” title for each document.
 * 4. When a publishing house processes thousands of EPS illustrations for print, converting them to PDFs that meet PDF compliance standards and include a confidential watermark for internal review.
 * 5. When a corporate intranet tool programmatically reads EPS files from a directory, generates PDF versions using Aspose.Imaging, and adds a “Confidential” watermark to prevent unauthorized sharing.
 */