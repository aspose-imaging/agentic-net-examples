using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputEps";
            string outputDir = @"C:\OutputPdf";

            // Collection of EPS file names to process
            string[] epsFiles = new[]
            {
                "file1.eps",
                "file2.eps",
                "file3.eps"
            };

            foreach (string fileName in epsFiles)
            {
                // Build full input path and verify existence
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path and ensure its directory exists
                string outputFileName = Path.ChangeExtension(fileName, ".pdf");
                string outputPath = Path.Combine(outputDir, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image, configure PDF options, and save as PDF
                using (EpsImage image = (EpsImage)Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            PdfCompliance = PdfComplianceVersion.PdfA1b
                        }
                    };

                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to batch‑convert a set of vector EPS artwork files into PDF/A‑1b compliant documents for archival or printing workflows.
 * 2. When an automated build script must generate PDF previews of EPS logos stored in a known folder before they are uploaded to a web portal.
 * 3. When a desktop application processes a predefined list of EPS design assets and saves them as PDF files in a separate output directory for client delivery.
 * 4. When a migration tool reads EPS files from a legacy directory, validates their existence, and converts each to PDF using Aspose.Imaging within a C# foreach loop.
 * 5. When a reporting service creates PDF reports from EPS charts by iterating over file names and applying PDF compliance options during the save operation.
 */