// HOW-TO: Batch Convert SVG Files to PDF with Title Metadata in C# (Aspose.Imaging for .NET)
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
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!Path.GetExtension(inputPath).Equals(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(Path.GetFileName(inputPath), ".pdf"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = Path.GetFileNameWithoutExtension(inputPath)
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
 * 1. When a design team needs to generate printable PDFs from a folder of SVG icons while preserving each icon’s name as the PDF title for easy catalog lookup.
 * 2. When an e‑commerce platform wants to batch‑convert product illustration SVGs to PDF brochures and embed the product code in the PDF metadata for search indexing.
 * 3. When a publishing workflow requires automated conversion of SVG chapter diagrams to PDFs with the diagram name stored as the document title for reference management.
 * 4. When a GIS application must transform a collection of SVG map overlays into PDFs and include the layer name in the PDF metadata for later layer identification.
 * 5. When a documentation system needs to create PDF versions of SVG flowcharts in bulk, embedding each chart’s description as the PDF title to support automated document archiving.
 */
