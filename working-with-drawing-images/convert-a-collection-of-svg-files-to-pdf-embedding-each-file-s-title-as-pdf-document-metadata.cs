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
            // Hardcoded relative input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all SVG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options with metadata
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        pdfOptions.PdfDocumentInfo.Title = fileNameWithoutExt; // Use file name as title

                        // Save as PDF
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
 * 1. When a developer needs to batch‑convert a library of SVG icons into searchable PDF catalogs, embedding each icon’s title as PDF metadata for easy indexing.
 * 2. When an e‑learning platform must generate printable course handouts from SVG diagrams, automatically adding the diagram title to the PDF document properties.
 * 3. When a marketing team wants to create a PDF portfolio of vector artwork stored as SVG files, with each artwork’s title stored in the PDF metadata for client reference.
 * 4. When a compliance system requires archival of SVG‑based schematics as PDFs, preserving the original file name as the PDF title metadata for audit trails.
 * 5. When a reporting tool needs to export SVG charts to PDF reports, embedding the chart title in the PDF document info so downstream tools can display it in document summaries.
 */