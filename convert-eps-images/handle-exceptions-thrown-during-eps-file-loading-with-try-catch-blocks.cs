// HOW-TO: How to Safely Convert EPS to PNG with Error Handling in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert a vector EPS file to a raster PNG in a .NET application while ensuring the program doesn’t crash if the file is missing or corrupted.
 * 2. When you want to validate the existence of an input EPS before processing and automatically create the output folder for the resulting PNG.
 * 3. When you are building a batch image conversion service that must log friendly error messages instead of exposing stack traces to end users.
 * 4. When you integrate Aspose.Imaging into a C# backend that processes user‑uploaded EPS files and must handle loading failures gracefully.
 * 5. When you develop a desktop utility that converts design assets to web‑ready PNGs and needs robust try‑catch handling for unexpected I/O issues.
 */
