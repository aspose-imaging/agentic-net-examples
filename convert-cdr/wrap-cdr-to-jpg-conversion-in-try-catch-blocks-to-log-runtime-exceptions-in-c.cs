// HOW-TO: Convert CDR to JPG with Error Handling in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to batch‑convert CorelDRAW (.cdr) files to JPEGs in a .NET service while ensuring missing files are reported.
 * 2. When an automated image‑processing pipeline must create output folders on the fly before saving converted images.
 * 3. When you want to catch and log any runtime errors (e.g., unsupported features or I/O issues) during CDR‑to‑JPG conversion.
 * 4. When integrating Aspose.Imaging into a Windows console app to transform design assets into web‑ready JPEGs.
 * 5. When deploying a C# utility that validates the source file exists, converts it, and writes a clear error message to the console on failure.
 */
