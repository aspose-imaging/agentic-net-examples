// HOW-TO: How To Load SVG And Save As PNG With Error Handling In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Image image;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (Exception loadEx)
            {
                Console.Error.WriteLine($"Failed to load SVG: {loadEx.Message}");
                Console.Error.WriteLine(loadEx.StackTrace);
                return;
            }

            using (image)
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to convert user‑uploaded SVG graphics to PNG thumbnails while ensuring missing files or corrupted SVGs are logged for debugging.
 * 2. When an automated batch process must create PNG assets from SVG sources and gracefully handle load failures without crashing the application.
 * 3. When a web service receives SVG input, validates its existence, and must return a PNG response while capturing any parsing errors for support tickets.
 * 4. When integrating Aspose.Imaging into a CI pipeline to verify that SVG assets can be rendered as PNG and any exceptions are recorded for build diagnostics.
 * 5. When building a desktop tool that reads SVG icons, saves them as PNG for Windows compatibility, and provides detailed error messages if the SVG cannot be processed.
 */
