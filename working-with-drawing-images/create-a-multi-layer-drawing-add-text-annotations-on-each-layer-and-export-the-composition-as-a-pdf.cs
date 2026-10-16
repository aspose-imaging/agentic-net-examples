// HOW-TO: Create Multi‑Layer PNG Drawing with Text and Export to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "Composition.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            using (var canvas = Image.Create(new PngOptions(), width, height))
            {
                var graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Layer 1
                using (var brush1 = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 300, 200));
                }
                using (var textBrush1 = new SolidBrush(Color.White))
                {
                    var font1 = new Font("Arial", 24);
                    graphics.DrawString("Layer 1 Text", font1, textBrush1, new Point(60, 120));
                }

                // Layer 2
                using (var brush2 = new SolidBrush(Color.Green))
                {
                    graphics.FillEllipse(brush2, new Rectangle(400, 100, 250, 250));
                }
                using (var textBrush2 = new SolidBrush(Color.Black))
                {
                    var font2 = new Font("Arial", 24);
                    graphics.DrawString("Layer 2 Text", font2, textBrush2, new Point(420, 200));
                }

                var pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a printable PDF report that contains layered graphics and labeled annotations directly from C# code.
 * 2. When you want to programmatically create a marketing flyer with colored shapes and custom text, then distribute it as a PDF file.
 * 3. When an application must combine multiple design elements (rectangles, ellipses) with captions into a single PDF for archival or sharing.
 * 4. When you are building a document‑generation service that requires dynamic drawing of shapes and text on a canvas before converting it to PDF.
 * 5. When you need to automate the creation of PDF certificates or badges that include background graphics and personalized text using Aspose.Imaging in .NET.
 */
