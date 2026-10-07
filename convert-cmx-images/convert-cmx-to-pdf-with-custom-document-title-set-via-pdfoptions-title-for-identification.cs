// HOW-TO: Convert CMX to PDF with Custom Document Title in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as searchable PDF files with a specific title for easy retrieval.
 * 2. When generating PDF reports from CMX artwork in an automated C# workflow and want the PDF metadata to reflect the original document name.
 * 3. When integrating a document management system that requires PDFs to carry a custom title attribute for indexing and compliance.
 * 4. When converting batch CMX files to PDF on a server and need to set a consistent title to differentiate versions in a version‑control process.
 * 5. When building a web service that receives CMX uploads and returns PDFs with a predefined title for downstream processing or printing.
 */
