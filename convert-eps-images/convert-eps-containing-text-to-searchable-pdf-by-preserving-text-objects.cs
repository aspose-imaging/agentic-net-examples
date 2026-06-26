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
        // Hardcoded input and output paths
        string inputPath = "input/Sample.eps";
        string outputPath = "output/Sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF saving options (PDF/A-1b compliance)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as searchable PDF preserving text objects
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
 * 1. When a developer needs to convert legacy EPS artwork that includes editable text into a PDF/A‑1b compliant searchable PDF for archival or compliance purposes.
 * 2. When an automated document‑processing pipeline must transform vector‑based EPS files into searchable PDFs while retaining the original text objects for indexing by search engines.
 * 3. When a C# application generates reports in EPS format and must provide end‑users with a searchable PDF version without rasterizing the text.
 * 4. When a digital asset management system imports EPS logos and diagrams and requires searchable PDFs to enable text‑based retrieval and accessibility compliance.
 * 5. When a batch‑processing tool needs to validate the existence of EPS files, create output directories, and reliably save them as searchable PDFs using Aspose.Imaging in a .NET environment.
 */