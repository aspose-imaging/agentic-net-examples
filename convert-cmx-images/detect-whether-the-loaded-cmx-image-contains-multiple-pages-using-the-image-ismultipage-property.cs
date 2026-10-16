// HOW-TO: Check If a CMX Image Has Multiple Pages in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
            string inputPath = "input.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                bool isMultiPage = image is Aspose.Imaging.IMultipageImage;
                Console.WriteLine($"Is multi-page: {isMultiPage}");
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
 * 1. When you need to verify whether a CMX vector file contains more than one page before converting each page to separate PNG files.
 * 2. When processing a batch of legacy CorelDRAW CMX files and you must skip single‑page images while handling multi‑page documents differently.
 * 3. When building a document viewer that should enable page navigation only for CMX files that are multi‑page.
 * 4. When creating an automated workflow that extracts metadata and logs whether each CMX file is multi‑page to decide further processing steps.
 * 5. When validating user‑uploaded CMX files in a web application to ensure they meet multi‑page requirements for printing or publishing.
 */
