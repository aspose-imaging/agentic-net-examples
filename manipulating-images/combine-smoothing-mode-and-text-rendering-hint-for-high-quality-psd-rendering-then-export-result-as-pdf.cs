// HOW-TO: Render EPS to High‑Quality PSD and Convert to PDF in C# (Aspose.Imaging for .NET)
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
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace VectorToPdfExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.eps";
                string psdPath = "output/output.psd";
                string pdfPath = "output/output.pdf";

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(psdPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                // Load the vector image (e.g., EPS)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options with high quality settings
                    var rasterizationOptions = new VectorRasterizationOptions
                    {
                        // Define desired size for rasterization
                        PageWidth = 1200,
                        PageHeight = 800,
                        // High‑quality rendering options
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                    };

                    // Set up PSD save options using the rasterization settings
                    var psdOptions = new PsdOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save as PSD
                    image.Save(psdPath, psdOptions);
                }

                // Load the generated PSD and export to PDF
                using (Image psdImage = Image.Load(psdPath))
                {
                    var pdfOptions = new PdfOptions();
                    psdImage.Save(pdfPath, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a designer needs to preserve vector artwork from an EPS file as a high‑resolution PSD for further editing in Photoshop while ensuring smooth edges and crisp text.
 * 2. When an automated publishing pipeline must generate PDF previews from vector graphics with anti‑aliased rendering to maintain visual fidelity.
 * 3. When a web service converts user‑uploaded EPS files into printable PDFs, requiring intermediate PSD files with optimal rasterization settings.
 * 4. When a batch‑processing tool creates archival PSD copies of vector assets with consistent smoothing and text rendering before distributing them as PDFs.
 * 5. When a desktop application needs to rasterize vector logos into PSD format with high‑quality settings and then export them to PDF for client delivery.
 */
