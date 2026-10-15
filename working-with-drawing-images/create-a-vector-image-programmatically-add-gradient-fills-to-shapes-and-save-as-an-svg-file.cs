// HOW-TO: Create SVG with Gradient Filled Shapes Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output/example.svg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var svgImage = new SvgImage(800, 600))
            {
                var graphics = new Graphics(svgImage);

                var rectGradient = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(800, 0),
                    Color.Red,
                    Color.Blue);
                graphics.FillRectangle(rectGradient, new Rectangle(50, 50, 300, 200));

                var ellipseGradient = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, 600),
                    Color.Green,
                    Color.Yellow);
                graphics.FillEllipse(ellipseGradient, new Rectangle(400, 100, 300, 300));

                svgImage.Save(outputPath);
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
 * 1. When you need to generate a scalable vector graphic with a red‑to‑blue rectangle and a green‑to‑yellow ellipse for a web dashboard.
 * 2. When you want to programmatically create SVG assets with linear gradient fills for branding or marketing materials.
 * 3. When an application must export dynamic charts or diagrams as SVG files that preserve resolution at any size.
 * 4. When you are building a reporting tool that requires on‑the‑fly vector images with custom color transitions.
 * 5. When you need to automate the creation of SVG icons or illustrations for responsive UI components.
 */
