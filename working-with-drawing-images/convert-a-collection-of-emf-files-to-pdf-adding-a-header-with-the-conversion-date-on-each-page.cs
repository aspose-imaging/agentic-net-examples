// HOW-TO: Convert EMF Files to PDF with Date Header in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_emf";
            string outputFolder = "output_pdf";

            Directory.CreateDirectory(outputFolder);

            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");
            foreach (string emfPath in emfFiles)
            {
                if (!File.Exists(emfPath))
                {
                    Console.Error.WriteLine($"File not found: {emfPath}");
                    return;
                }

                using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(emfPath))
                {
                    int width = emfImage.Width;
                    int height = emfImage.Height;
                    int headerHeight = 50;
                    int totalHeight = height + headerHeight;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(emfPath) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Source = new FileCreateSource(outputPath, false);

                    using (Aspose.Imaging.Image pdfImage = Aspose.Imaging.Image.Create(pdfOptions, width, totalHeight))
                    {
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(pdfImage);

                        using (SolidBrush textBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                        {
                            Aspose.Imaging.Font headerFont = new Aspose.Imaging.Font("Arial", 24);
                            graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), headerFont, textBrush, new Aspose.Imaging.Point(10, 10));
                        }

                        graphics.DrawImage(emfImage, new Aspose.Imaging.Rectangle(0, headerHeight, width, height));

                        pdfImage.Save();
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
 * 1. When a developer needs to batch‑convert legacy EMF vector drawings into PDF reports that automatically include the conversion date on each page.
 * 2. When an application must generate printable PDFs from EMF logos while adding a timestamp header for audit purposes.
 * 3. When a document‑management system requires converting user‑uploaded EMF diagrams to PDF and tagging each page with the current date for version control.
 * 4. When a reporting tool has to embed EMF charts into PDF invoices and display the generation date at the top of every page.
 * 5. When a migration script must transform a folder of EMF assets into PDF files and prepend a date header for compliance documentation.
 */
