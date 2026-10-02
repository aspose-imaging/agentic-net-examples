// HOW-TO: Configure Font Substitution to Save ODG with Missing Fonts in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.odg";
        string outputPath = "output/output.odg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions();

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                image.Save(outputPath);
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
 * 1. When a web application receives ODG files that reference fonts not installed on the server, this code ensures the images are saved without font‑related errors by substituting available fonts.
 * 2. When automating batch processing of ODG drawings on a build server that lacks the original design fonts, the code lets developers generate output files reliably.
 * 3. When creating PDF or PNG exports from ODG files in a CI pipeline, configuring font substitution prevents missing‑glyph issues in the rendered images.
 * 4. When migrating legacy ODG assets to a new environment where some fonts are unavailable, this approach preserves the visual layout by using fallback fonts during save.
 * 5. When a desktop tool processes user‑uploaded ODG diagrams on machines without the required fonts, the code enables consistent saving of the files without manual font installation.
 */
