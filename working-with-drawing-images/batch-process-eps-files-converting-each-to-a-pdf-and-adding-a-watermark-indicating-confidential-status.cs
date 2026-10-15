// HOW-TO: Batch Convert EPS to PDF with Confidential Watermark in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (var epsPath in files)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(epsPath))
                {
                    var graphics = new Aspose.Imaging.Graphics(epsImage);
                    var font = new Aspose.Imaging.Font("Arial", 48);
                    var brush = new SolidBrush(Aspose.Imaging.Color.Red);
                    var point = new Aspose.Imaging.PointF(10, epsImage.Height - 60);
                    graphics.DrawString("Confidential", font, brush, point);

                    var pdfOptions = new PdfOptions();
                    epsImage.Save(outputPath, pdfOptions);
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
 * 1. When a design team needs to archive multiple Adobe EPS artwork files as PDF documents while automatically marking them as confidential.
 * 2. When a legal department must distribute a set of vector drawings in PDF format with a red "Confidential" stamp to prevent unauthorized sharing.
 * 3. When an automated build pipeline has to convert generated EPS charts into PDFs and embed a watermark for internal review.
 * 4. When a printing service wants to prepare client EPS submissions for preview by converting them to PDFs and adding a confidentiality label.
 * 5. When a document management system requires bulk transformation of EPS files to searchable PDFs with a visible security watermark.
 */
