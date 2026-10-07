// HOW-TO: Batch Convert DjVu Files to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        pdfOptions.PdfDocumentInfo.Author = "Custom Author";

                        djvuImage.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to automate the conversion of a large collection of DjVu documents to searchable PDF files while setting a specific author name for each PDF.
 * 2. When a document management system must ingest legacy DjVu scans and store them as PDFs with consistent author metadata for compliance reporting.
 * 3. When a desktop application processes user‑uploaded DjVu files in bulk and generates PDFs that include a custom author tag for branding purposes.
 * 4. When a migration script moves archival DjVu assets to PDF format and requires embedding author information to preserve attribution.
 * 5. When a server‑side service converts multiple DjVu files to PDF on the fly and needs to add the same author metadata to all output documents for indexing.
 */
