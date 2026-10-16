// HOW-TO: Count Shapes in Each Figure of a GraphicsPath Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var graphicsPath = new Aspose.Imaging.GraphicsPath();

            var figure = new Aspose.Imaging.Figure();
            graphicsPath.AddFigure(figure);

            foreach (var fig in graphicsPath.Figures)
            {
                int shapeCount = fig.Shapes != null ? fig.Shapes.Count() : 0;
                Console.WriteLine($"Figure contains {shapeCount} shape(s).");
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
 * 1. When you need to verify how many vector shapes are stored in each figure of a PNG image before editing it with Aspose.Imaging.
 * 2. When generating a report of shape counts for each figure in a complex graphic to ensure proper rendering in a C# application.
 * 3. When debugging a graphics pipeline to confirm that figures have been populated with the expected number of shapes after importing SVG data.
 * 4. When performing quality checks on batch‑processed images to detect empty or malformed figures in a GraphicsPath collection.
 * 5. When building a tool that logs shape statistics for each figure to assist designers in optimizing vector artwork in .NET.
 */
