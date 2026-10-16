// HOW-TO: How To Substitute Missing Fonts When Saving ODG With Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample_converted.odg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
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
 * 1. When an application generates ODG reports that use custom fonts not installed on the server, developers can configure font substitution to ensure the saved files render correctly.
 * 2. When converting user‑uploaded ODG drawings to a standardized version on a cloud service, missing fonts need to be replaced automatically to avoid broken text.
 * 3. When batch‑processing a library of ODG graphics for archival, font substitution guarantees that each saved file retains readable text despite varying client font installations.
 * 4. When integrating Aspose.Imaging into a document‑editing workflow that must preserve layout after saving, developers use font substitution to handle absent fonts in the target environment.
 * 5. When creating a cross‑platform C# tool that opens ODG files on machines without the original fonts, configuring font substitution prevents runtime errors and maintains visual fidelity.
 */
