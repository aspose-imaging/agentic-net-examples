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
            // Hardcoded input and output paths
            string inputPath = "Sample.eps";
            string outputPath = "output/Sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and export to PDF
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b // Set required PDF compliance
                    }
                };

                image.Save(outputPath, options);
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
 * 1. When a developer needs to convert legacy EPS vector artwork stored on a file server into PDF/A‑1b compliant documents for archival or electronic distribution using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must generate printable PDF files from EPS logos supplied by designers, ensuring the output folder is created and the conversion runs without manual intervention.
 * 3. When a web application processes user‑uploaded EPS files and must instantly transform them into PDF format for preview or download, using Aspose.Imaging’s Image.Load and PdfOptions in .NET.
 * 4. When a document management system requires batch conversion of EPS assets to PDF while validating file existence and handling errors gracefully in a C# service.
 * 5. When a desktop utility needs to read an EPS file, apply PDF compliance settings such as PdfA1b, and save the result as a PDF in a specified directory using Aspose.Imaging for .NET.
 */