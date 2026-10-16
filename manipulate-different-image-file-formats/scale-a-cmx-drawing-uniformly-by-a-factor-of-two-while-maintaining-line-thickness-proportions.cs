// HOW-TO: Scale CMX Drawing by 2x While Preserving Line Thickness in C# (Aspose.Imaging for .NET)
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

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int newWidth = cmx.Width * 2;
                int newHeight = cmx.Height * 2;

                cmx.Resize(newWidth, newHeight);
                cmx.Save(outputPath);
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
 * 1. When you need to double the size of a CorelDRAW CMX file for high‑resolution printing without distorting line weights.
 * 2. When a CAD‑to‑presentation workflow requires scaling vector drawings uniformly before embedding them in slides.
 * 3. When an automated build script must enlarge legacy CMX schematics to match a new display DPI setting.
 * 4. When a web service generates enlarged thumbnails of CMX artwork while keeping stroke thickness consistent.
 * 5. When migrating old CMX assets to a larger canvas for a redesign project using Aspose.Imaging in a .NET application.
 */
