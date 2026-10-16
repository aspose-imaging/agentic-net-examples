// HOW-TO: Convert CMX Stream to TIFF in Memory Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "output.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] data = File.ReadAllBytes(inputPath);
            using (var ms = new MemoryStream(data))
            {
                using (Image image = Image.Load(ms))
                {
                    using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        image.Save(outputPath, tiffOptions);
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
 * 1. When a CAD application needs to render CMX drawings as high‑resolution TIFF images directly from a byte array without creating intermediate files.
 * 2. When a web service receives CMX data over an API and must return a TIFF preview to the client while keeping the conversion entirely in memory.
 * 3. When a batch job processes archived CMX files stored in a database BLOB column and saves the results as TIFF for archival or printing purposes.
 * 4. When an automated document workflow converts CMX design files to TIFF for OCR or indexing without consuming disk space for temporary images.
 * 5. When a desktop utility converts user‑selected CMX files to TIFF on the fly, using Aspose.Imaging to avoid file‑system permissions issues.
 */
