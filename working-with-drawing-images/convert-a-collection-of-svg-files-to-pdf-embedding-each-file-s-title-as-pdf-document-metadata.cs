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
            // Batch input/output directory setup (mandatory block)
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
                // Process only SVG files
                if (!string.Equals(Path.GetExtension(inputPath), ".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options with metadata
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo()
                    };
                    pdfOptions.PdfDocumentInfo.Title = fileNameWithoutExt;

                    // Set vector rasterization options for SVG/vector images
                    if (image is VectorImage)
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                    }

                    // Save as PDF
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
 * 1. When a design team needs to archive vector artwork from SVG files as searchable PDF documents with each file’s title stored in the PDF metadata for easy retrieval.
 * 2. When an e‑learning platform automatically converts SVG illustrations into PDF handouts, embedding the illustration title so learners can see the source name in the PDF properties.
 * 3. When a marketing department batch‑processes brand assets, turning SVG logos into PDF files that include the logo name in the document metadata for compliance reporting.
 * 4. When a government agency publishes public data visualizations, converting SVG charts to PDF while preserving the chart title in the PDF metadata for indexing by document management systems.
 * 5. When a software product generates printable reports from SVG diagrams, using C# to create PDFs that embed the diagram title as metadata so end users can quickly locate the original diagram file.
 */