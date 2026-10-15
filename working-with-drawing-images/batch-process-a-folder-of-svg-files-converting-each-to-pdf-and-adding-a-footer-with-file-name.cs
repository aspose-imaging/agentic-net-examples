// HOW-TO: Batch Convert SVG Files to PDF with Filename Footer in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

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

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG and convert to PDF
                using (Image svgImage = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        svgImage.Save(outputPath, pdfOptions);
                    }
                }

                // Load the generated PDF, add footer, and save again
                using (Image pdfImage = Image.Load(outputPath))
                {
                    // Ensure raster data is cached
                    if (pdfImage is RasterCachedImage rci && !rci.IsCached)
                    {
                        rci.CacheData();
                    }

                    Graphics graphics = new Graphics(pdfImage);
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 12);
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        graphics.DrawString(fileName, font, brush, new Point(10, pdfImage.Height - 30));
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    pdfImage.Save(outputPath);
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
 * 1. When you need to generate printable PDFs from a collection of SVG icons and automatically label each page with its original file name.
 * 2. When a reporting system must batch‑process vector graphics into PDF reports and include a footer that identifies the source SVG for audit purposes.
 * 3. When an e‑commerce platform wants to convert product SVG illustrations to PDF catalogs while adding the SKU as a footer on each document.
 * 4. When a documentation workflow requires converting design SVG assets to PDF handouts and appending the asset name as a reference footer.
 * 5. When a CI/CD pipeline automates the creation of PDF assets from SVG files and needs to embed the filename in the PDF for traceability.
 */
