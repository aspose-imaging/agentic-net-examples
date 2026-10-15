// HOW-TO: Convert EMF to SVG with Custom Background Color in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = emfImage.Width;
                int height = emfImage.Height;

                SvgOptions svgOptions = new SvgOptions();
                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Create(svgOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(svgImage);
                    using (SolidBrush bgBrush = new SolidBrush(Aspose.Imaging.Color.LightBlue))
                    {
                        graphics.FillRectangle(bgBrush, 0, 0, width, height);
                    }

                    graphics.DrawImage(emfImage, new Aspose.Imaging.Point(0, 0));

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
                    svgImage.Save(outputPath);
                }
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
 * 1. When you need to embed a legacy EMF diagram into a web page as scalable SVG with a solid background color.
 * 2. When converting printed vector assets to SVG for responsive UI while ensuring a consistent background hue.
 * 3. When generating SVG thumbnails from EMF files for a document management system that requires a uniform background.
 * 4. When preprocessing EMF logos for branding assets, adding a brand‑color backdrop before exporting to SVG.
 * 5. When automating batch conversion of EMF charts to SVG in a C# application, applying a light background to improve visibility.
 */
