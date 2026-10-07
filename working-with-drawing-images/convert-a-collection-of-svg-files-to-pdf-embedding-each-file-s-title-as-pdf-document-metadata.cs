// HOW-TO: Convert Multiple SVG Files to PDF with Title Metadata in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!Path.GetExtension(inputPath).Equals(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                string title = Path.GetFileNameWithoutExtension(inputPath);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    pdfOptions.PdfDocumentInfo.Title = title;

                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate printable PDFs from a batch of SVG icons while preserving each file’s name as the document title for cataloging.
 * 2. When an automated reporting system must convert vector graphics into searchable PDFs and embed descriptive metadata for easier indexing.
 * 3. When a web service receives user‑uploaded SVG diagrams and must store them as PDFs with the original diagram name in the PDF metadata for compliance.
 * 4. When a desktop application creates PDF portfolios from design assets, using the SVG filename as the title to display in PDF viewers.
 * 5. When a document management workflow requires bulk conversion of SVG assets to PDFs with title fields so that downstream tools can sort and filter files by title.
 */
