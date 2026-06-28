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
            // Hardcoded input EPS file path
            string inputPath = "Sample.eps";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output PDF path using custom pattern: <original name>_converted.pdf
            string inputDirectory = Path.GetDirectoryName(inputPath) ?? "";
            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_converted.pdf";
            string outputPath = Path.Combine(inputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(inputDirectory);

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Set PDF options (optional compliance can be set here)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Example compliance setting; adjust as needed
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF with the specified options
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
 * 1. When a desktop publishing workflow needs to batch‑convert incoming EPS artwork into PDF files with a naming convention that appends “_converted” to the original file name.
 * 2. When an automated document generation service must ensure that vector EPS logos are saved as PDF/A‑1b compliant files for long‑term archival while preserving the original file’s location.
 * 3. When a C# application processes user‑uploaded EPS files and stores the resulting PDFs in the same directory using a predictable pattern for easy retrieval by downstream systems.
 * 4. When a print‑ready pipeline validates the existence of an EPS source, converts it to PDF with specific PdfCoreOptions, and creates the output folder on‑the‑fly to avoid path errors.
 * 5. When a .NET backend needs to programmatically rename and convert EPS design assets to PDF for inclusion in email attachments or web previews without manual file handling.
 */