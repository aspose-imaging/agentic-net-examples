// HOW-TO: Batch Convert Images to PDF with Date Watermark in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f =>
                {
                    string ext = Path.GetExtension(f).ToLowerInvariant();
                    return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif" || ext == ".tif" || ext == ".tiff";
                })
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var raster = (RasterImage)image;

                    var graphics = new Graphics(raster);
                    string watermarkText = $"Generated on {DateTime.Now:yyyy-MM-dd}";
                    var font = new Font("Arial", 24);
                    var brush = new SolidBrush(Color.Yellow);
                    float x = raster.Width - 200; // approximate position
                    float y = raster.Height - 30;
                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));

                    var pdfOptions = new PdfOptions();
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
 * 1. When a company needs to archive daily scanned photos as PDF documents that show the generation date for compliance.
 * 2. When a developer wants to automate converting a folder of product photos (PNG, JPG, BMP, GIF, TIFF) into PDFs with a timestamp watermark.
 * 3. When an application must generate PDF reports from user‑uploaded images and include the current date as proof of creation.
 * 4. When a legal team requires batch processing of evidence images into PDFs that display the date they were processed.
 * 5. When a photographer wants to create watermarked PDF portfolios from a collection of raster images, automatically adding today’s date.
 */
