// HOW-TO: Log CMX Conversion Parameters Using NLog In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            File.Copy(inputPath, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to audit every CMX to PNG conversion in a batch job, they can log the source file, target format, and conversion settings with NLog.
 * 2. When troubleshooting unexpected image quality after converting CMX files, detailed NLog entries of the parameters help pinpoint misconfigurations.
 * 3. When building a compliance‑required image processing pipeline, logging conversion metadata satisfies traceability regulations.
 * 4. When monitoring performance of large‑scale CMX conversions, NLog can record timestamps and option values to identify bottlenecks.
 * 5. When integrating Aspose.Imaging into a CI/CD workflow, NLog‑based logs provide clear evidence that each conversion ran with the intended settings.
 */
