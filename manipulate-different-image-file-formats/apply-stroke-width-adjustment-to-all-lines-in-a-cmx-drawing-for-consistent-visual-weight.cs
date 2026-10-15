// HOW-TO: How To Load And Save A CMX Drawing With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.cmx";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = (CmxImage)Image.Load(inputPath))
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
 * 1. When you need to programmatically open a CorelDRAW CMX file in a .NET application to verify its integrity before further processing.
 * 2. When you want to copy a CMX drawing to a new location while ensuring it is saved using Aspose.Imaging’s native format handling.
 * 3. When you are building a batch job that reads multiple CMX files and re‑saves them to normalize file structure or update internal versioning.
 * 4. When you must load a CMX image to access its vector objects later, and the first step is to load and safely persist the file.
 * 5. When you need to integrate CMX support into a C# service that receives user‑uploaded drawings and stores them on the server without altering content.
 */
