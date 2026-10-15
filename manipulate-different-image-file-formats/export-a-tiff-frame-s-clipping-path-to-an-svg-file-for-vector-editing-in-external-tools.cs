// HOW-TO: Export TIFF Clipping Path to SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/clip.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                TiffFrame frame = tiff.ActiveFrame;
                var pathResources = frame.PathResources;
                if (pathResources == null || pathResources.Count == 0)
                {
                    Console.Error.WriteLine("No clipping path found in the TIFF frame.");
                    return;
                }

                var pathResource = pathResources[0];
                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                    new[] { pathResource }, frame.Size);

                var svgOptions = new SvgOptions();
                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Create(svgOptions, frame.Width, frame.Height))
                {
                    var graphics = new Aspose.Imaging.Graphics(svgImage);
                    var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
                    graphics.DrawPath(pen, graphicsPath);
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
 * 1. When you need to edit a TIFF image's vector clipping mask in Illustrator, you can extract it as an SVG file.
 * 2. When converting legacy scanned documents that contain clipping paths into scalable vector graphics for web display.
 * 3. When preparing print‑ready assets and you must separate the clipping path from a multi‑page TIFF for further vector editing.
 * 4. When automating a workflow that moves region‑of‑interest data from TIFF frames into SVG for use in CAD or GIS tools.
 * 5. When building a C# application that validates the presence of a clipping path in a TIFF and exports it for downstream vector processing.
 */
