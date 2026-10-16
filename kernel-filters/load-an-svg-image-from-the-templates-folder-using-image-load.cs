// HOW-TO: Load SVG Image from File Path and Get Dimensions in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

namespace SvgLoaderApp
{
    class Program
    {
        static void Main()
        {
            const string inputPath = "templates/sample.svg";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    Console.WriteLine($"Loaded SVG image: {image.Width}x{image.Height}");
                }
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
 * 1. When you need to read an SVG logo stored in a project’s templates folder and determine its pixel width and height before embedding it in a PDF report.
 * 2. When a web service must validate that an uploaded SVG file exists and can be opened without errors using Aspose.Imaging in a .NET backend.
 * 3. When generating dynamic thumbnails, you first load the original SVG to obtain its intrinsic size so you can calculate appropriate scaling factors.
 * 4. When performing batch processing of design assets, you load each SVG to log its dimensions for inventory or quality‑control purposes.
 * 5. When integrating SVG graphics into a Windows desktop application, you load the file to confirm it loads correctly and retrieve its size for layout calculations.
 */
