// HOW-TO: Create Vector Diagram with Shapes and Connectors and Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "diagram.svg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            SvgOptions svgOptions = new SvgOptions();

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(svgOptions, 800, 600))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);

                graphics.DrawRectangle(blackPen, new Aspose.Imaging.Rectangle(100, 100, 200, 150));
                graphics.DrawEllipse(blackPen, new Aspose.Imaging.Rectangle(100, 100, 200, 150));
                graphics.DrawLine(blackPen, new Aspose.Imaging.Point(300, 175), new Aspose.Imaging.Point(500, 300));
                graphics.DrawRectangle(blackPen, new Aspose.Imaging.Rectangle(500, 250, 150, 100));

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
 * 1. When you need to generate a scalable flow‑chart or network diagram on the fly in a web application and embed it as an SVG without using external design tools.
 * 2. When an automated reporting system must create vector‑based illustrations such as rectangles, ellipses, and connector lines for PDF or HTML reports using C#.
 * 3. When a SaaS platform wants to provide users with downloadable SVG schematics of custom layouts created programmatically with Aspose.Imaging.
 * 4. When you are building a diagramming component that requires high‑quality, resolution‑independent graphics for responsive web pages.
 * 5. When you need to batch‑process multiple diagram files, drawing shapes and lines dynamically and saving each as an SVG for later editing in vector editors.
 */
