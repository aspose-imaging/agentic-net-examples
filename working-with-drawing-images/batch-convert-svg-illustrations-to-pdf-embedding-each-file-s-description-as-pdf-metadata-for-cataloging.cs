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
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    pdfOptions.PdfDocumentInfo.Title = Path.GetFileNameWithoutExtension(inputPath);
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
 * 1. When a design team needs to archive a library of SVG icons as searchable PDF catalogs, this C# batch converter creates PDFs with each file’s title stored in the PDF metadata.
 * 2. When an e‑learning platform must transform SVG illustrations into printable PDF handouts while preserving descriptive titles for indexing, the code automates the conversion and metadata embedding.
 * 3. When a marketing department wants to generate client‑ready PDF portfolios from SVG artwork and include the artwork name as the PDF document title for easy reference, this script processes the entire input folder in one run.
 * 4. When a documentation system requires SVG diagrams to be bundled into PDF files with embedded titles for integration with document management software, the example provides a simple C# solution.
 * 5. When a CI/CD pipeline needs to verify that all SVG assets are converted to PDF with proper metadata before release, the code can be invoked to batch‑process the assets and ensure each PDF carries the original file name as its title.
 */