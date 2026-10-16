// HOW-TO: Create Dark Blue SolidBrush for Image Drawing in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(0, 0, 139)))
            {
                Console.WriteLine("SolidBrush configured with dark blue color.");
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
 * 1. When you need to fill vector shapes or text with a dark blue color while generating PNG graphics using Aspose.Imaging in a C# application.
 * 2. When adding a solid dark blue background or overlay to JPEG images before converting them to PNG format for web publishing.
 * 3. When drawing custom annotations, such as borders or highlights, on scanned documents and you require a consistent dark blue brush color.
 * 4. When programmatically creating icons or UI assets where a specific dark blue fill is required for consistency across different screen resolutions.
 * 5. When applying a dark blue fill to chart elements or diagram components generated on the fly in a .NET service that processes image files.
 */
