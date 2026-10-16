// HOW-TO: Batch Convert SVG Files to PDF with Title Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;

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
                    continue;
                }

                if (!Path.GetExtension(inputPath).Equals(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Extract title from SVG
                string title;
                try
                {
                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.Load(inputPath);
                    var titleNode = xmlDoc.GetElementsByTagName("title");
                    title = titleNode.Count > 0 ? titleNode[0].InnerText : Path.GetFileNameWithoutExtension(inputPath);
                }
                catch
                {
                    title = Path.GetFileNameWithoutExtension(inputPath);
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        pdfOptions.PdfDocumentInfo.Title = title;
                        pdfOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height
                        };

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
 * 1. When you need to generate searchable PDF reports from a set of SVG diagrams while preserving each diagram’s title as PDF metadata.
 * 2. When automating the creation of printable documentation that consolidates multiple SVG assets into individual PDF files with proper document titles.
 * 3. When building a workflow that extracts SVG titles and stores them in PDF properties for better indexing in document management systems.
 * 4. When converting web‑generated SVG graphics to PDF for archival, ensuring the original title appears in the PDF’s metadata for easy retrieval.
 * 5. When developing a batch processing tool that reads SVG files from a folder, converts each to PDF, and embeds the SVG’s <title> element as the PDF’s document title.
 */
