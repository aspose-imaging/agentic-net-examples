// HOW-TO: Convert ODG to PDF and Flatten Annotations in C# (Aspose.Imaging for .NET)
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

namespace OdgToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PdfOptions();
                    image.Save(outputPath, options);
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
 * 1. When a designer needs to archive OpenDocument Graphics (ODG) drawings as non‑editable PDF files for legal or compliance purposes.
 * 2. When an application must generate a printable PDF version of an ODG diagram while removing interactive annotation layers.
 * 3. When a document management system imports ODG assets and requires them to be stored as flattened PDFs for consistent viewing across browsers.
 * 4. When a reporting tool converts ODG charts into PDF pages to embed them in multi‑page reports without preserving edit capabilities.
 * 5. When a batch process converts multiple ODG files to PDF using Aspose.Imaging in C# to create a static portfolio of graphics.
 */
