using System;
using System.IO;
using System.Linq;
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

            foreach (var filePath in files)
            {
                if (!filePath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                string inputPath = filePath;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.ChangeExtension(Path.GetFileName(inputPath), ".pdf");
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        pdfOptions.PdfDocumentInfo.Title = Path.GetFileNameWithoutExtension(inputPath);
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
 * 1. When a developer needs to batch‑convert a library of SVG icons into searchable PDF catalogs, preserving each icon’s name as the PDF title metadata.
 * 2. When an automated build pipeline must generate printable PDF reports from SVG diagrams and embed the diagram name as the document title for easier indexing.
 * 3. When a web service offers users the ability to download their SVG artwork as PDF files, and the service must set the PDF metadata title to match the original file name.
 * 4. When a document management system imports SVG assets and requires each PDF version to carry the original SVG filename in the PDF document info for compliance tracking.
 * 5. When a desktop utility processes a folder of SVG floor plans, converting them to PDF while using the floor plan’s filename as the PDF title to aid search and retrieval.
 */