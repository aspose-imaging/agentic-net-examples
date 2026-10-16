// HOW-TO: Load EPS Image With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

namespace EpsLoader
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using var image = Image.Load(inputPath);
                Console.WriteLine("EPS image loaded successfully.");
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
 * 1. When you need to open a vector EPS file in a .NET application to display or process it further.
 * 2. When you want to verify that an EPS artwork exists on disk before performing any image conversion.
 * 3. When you are building a batch job that reads multiple EPS files and needs a simple way to load each file safely.
 * 4. When you need to catch and log exceptions while loading EPS images to prevent your application from crashing.
 * 5. When you are integrating Aspose.Imaging into a C# service that must read EPS files without specifying custom load options.
 */
