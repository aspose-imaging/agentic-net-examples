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
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert scanned archival DjVu documents into searchable PDF files while preserving the original metadata for compliance reporting.
 * 2. When an application must batch‑process legal case files stored as DjVu and generate PDF versions that retain author, creation date, and title information for e‑discovery.
 * 3. When a digital library platform wants to serve users PDFs instead of DjVu but still keep the embedded metadata for cataloging and indexing purposes.
 * 4. When a document management system requires on‑the‑fly conversion of DjVu blueprints to PDF with metadata intact to integrate with existing PDF workflow tools.
 * 5. When a C# service automates the migration of legacy DjVu manuals to PDF format, ensuring that the original metadata is embedded for future search and retrieval.
 */