using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "C:\\InputDjvu";
            string outputFolder = "C:\\OutputPdf";

            string[] inputFiles = new string[]
            {
                Path.Combine(inputFolder, "sample1.djvu"),
                Path.Combine(inputFolder, "sample2.djvu")
            };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo
                        {
                            Author = "Custom Author"
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
 * 1. When a developer needs to batch‑convert a collection of DjVu scanned documents into searchable PDF files while adding a custom author name for compliance reporting.
 * 2. When an archival system requires automated processing of DjVu e‑books into PDF format with embedded metadata to preserve author attribution across a digital library.
 * 3. When a document‑management workflow must transform multiple DjVu image files into PDF for easier distribution, and the PDFs must include a specific author field for legal traceability.
 * 4. When a C# application integrates Aspose.Imaging to generate PDF reports from DjVu technical drawings, inserting a custom author tag to identify the engineer who created the source files.
 * 5. When a batch‑processing script is needed to read DjVu pages, convert each to PDF, and set the PdfDocumentInfo.Author property so that downstream indexing services can categorize the PDFs by author.
 */