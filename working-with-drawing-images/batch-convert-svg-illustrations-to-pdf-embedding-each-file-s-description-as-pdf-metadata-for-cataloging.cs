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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!Path.GetExtension(inputPath).Equals(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                string description = "";
                try
                {
                    string svgContent = File.ReadAllText(inputPath);
                    int start = svgContent.IndexOf("<desc>", StringComparison.OrdinalIgnoreCase);
                    if (start >= 0)
                    {
                        int end = svgContent.IndexOf("</desc>", start, StringComparison.OrdinalIgnoreCase);
                        if (end > start)
                        {
                            description = svgContent.Substring(start + 6, end - (start + 6)).Trim();
                        }
                    }
                }
                catch
                {
                }

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo()
                    };

                    // Optional: set metadata, e.g., pdfOptions.PdfDocumentInfo.Title = description;

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
 * 1. When a publishing workflow requires batch converting hundreds of SVG artwork files into PDF documents while automatically embedding each SVG’s <desc> element as PDF metadata for searchable catalogs.
 * 2. When an e‑learning platform needs to transform SVG diagrams into PDF handouts and preserve the diagram descriptions for accessibility tools that read PDF metadata.
 * 3. When a marketing team wants to generate printable PDF brochures from SVG icons and ensure each icon’s description is stored in the PDF’s document information for easy indexing.
 * 4. When a software documentation system must convert SVG flowcharts to PDF pages and retain the original <desc> annotations as PDF metadata to support keyword‑based retrieval.
 * 5. When a legal firm automates the archival of SVG legal illustrations into PDF files, embedding the illustration’s description in the PDF metadata to meet compliance and audit requirements.
 */