// HOW-TO: Export EMF to High Quality JPEG with 95% Quality in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                JpegOptions options = new JpegOptions
                {
                    Quality = 95
                };
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
 * 1. When a Windows application must convert vector EMF charts into JPEG thumbnails for display in a web UI while preserving visual fidelity.
 * 2. When an automated report generator needs to embed high‑resolution JPEG images derived from EMF diagrams into PDF documents.
 * 3. When a migration script processes legacy EMF assets and saves them as compressed JPEG files for use in mobile apps.
 * 4. When a cloud service receives EMF uploads and returns JPEG previews with a specific 95 percent quality setting to balance size and clarity.
 * 5. When a batch job updates a product catalog by converting EMF logos to JPEG format with consistent quality for SEO‑friendly image assets.
 */
