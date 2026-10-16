// HOW-TO: Load EPS Image From File and Get Dimensions In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.eps";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                Console.WriteLine($"Loaded EPS image. Width: {image.Width}, Height: {image.Height}");
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
 * 1. When you need to read an EPS vector file in a C# application to retrieve its pixel width and height before converting it to another raster format.
 * 2. When validating that an EPS file exists on disk and can be opened without errors using Aspose.Imaging’s Image.Load method.
 * 3. When building a batch‑processing tool that logs the dimensions of each EPS artwork for quality‑control reporting.
 * 4. When integrating Aspose.Imaging into a workflow that requires checking EPS image metadata (such as size) prior to scaling, cropping, or other transformations.
 * 5. When troubleshooting rendering issues by confirming that the EPS file loads correctly and reports the expected width and height values.
 */
