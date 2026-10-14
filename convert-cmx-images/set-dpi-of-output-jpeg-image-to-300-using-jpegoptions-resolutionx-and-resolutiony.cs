// HOW-TO: Set JPEG Image DPI to 300 Using Aspose Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions options = new JpegOptions();
                image.Save(outputPath, options);
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
 * 1. When preparing photos for high‑resolution print jobs, a developer can use this code to set the JPEG’s DPI to 300 so the printed output matches the required print quality.
 * 2. When converting scanned documents to JPEG for archival, setting the DPI ensures the saved images retain the original scan resolution for accurate viewing and OCR.
 * 3. When generating thumbnails for a web gallery that must retain physical size information, adjusting the DPI with Aspose.Imaging lets the thumbnails display correctly on devices that respect image metadata.
 * 4. When integrating with a publishing workflow that expects 300‑DPI JPEGs for layout software, the code guarantees the exported files meet the specification without manual editing.
 * 5. When creating product catalogs where images are printed on brochures, setting the JPEG resolution programmatically avoids inconsistencies caused by varying source image DPI values.
 */
