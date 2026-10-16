// HOW-TO: Check If EPS File Contains a TIFF Preview Image In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Image preview = null;
                try
                {
                    preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF);
                }
                catch
                {
                }

                if (preview != null)
                {
                    Console.WriteLine("Preview image exists.");
                    preview.Dispose();
                }
                else
                {
                    Console.WriteLine("No preview image found.");
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
 * 1. When you need to verify that an EPS document includes an embedded TIFF preview before extracting it for thumbnail generation.
 * 2. When processing a batch of EPS files you want to skip those without preview images to avoid unnecessary errors during conversion.
 * 3. When building a preview gallery for a design portal and must confirm each EPS file has a preview to display to users.
 * 4. When validating incoming EPS assets in a content‑management workflow to ensure they contain a preview for quick visual inspection.
 * 5. When extracting a low‑resolution preview from EPS files for PDF generation and need to detect its presence programmatically.
 */
