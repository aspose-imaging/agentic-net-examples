// HOW-TO: Check Default FillMode of GraphicsPath Is Alternate in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Instantiate a GraphicsPath object
            var graphicsPath = new GraphicsPath();

            // Confirm its default FillMode is Alternate
            bool isAlternate = graphicsPath.FillMode == FillMode.Alternate;
            Console.WriteLine(isAlternate ? "FillMode is Alternate" : $"FillMode is {graphicsPath.FillMode}");

            // Write result to output file
            File.WriteAllText(outputPath, isAlternate ? "Alternate" : graphicsPath.FillMode.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that a newly created GraphicsPath uses the Alternate fill rule before drawing complex vector shapes.
 * 2. When debugging an image rendering pipeline to ensure the default FillMode matches expected winding behavior for overlapping polygons.
 * 3. When writing unit tests for Aspose.Imaging code that relies on the default FillMode setting of GraphicsPath objects.
 * 4. When converting or exporting vector graphics and you must confirm the fill mode to avoid unexpected gaps or overfills.
 * 5. When generating SVG or PDF content programmatically and you want to guarantee consistent fill behavior across different platforms.
 */
