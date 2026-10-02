// HOW-TO: Export TIFF Frame Clipping Path to SVG with Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame frame = tiffImage.Frames[0];
                tiffImage.ActiveFrame = frame;

                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                    frame.PathResources.ToArray(),
                    frame.Size);

                var svgGraphics = new SvgGraphics2D(frame.Width, frame.Height, 96);
                svgGraphics.DrawPath(new Pen(Color.Black), graphicsPath);

                using (SvgImage svgImage = svgGraphics.EndRecording())
                {
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
 * 1. When you need to extract a vector clipping path from a multi‑page TIFF and edit it in Illustrator or Inkscape, this code converts the first frame’s path to an SVG file.
 * 2. When a printing workflow requires the TIFF’s cut‑out shape for spot‑color registration, you can export the clipping path as SVG for precise vector manipulation.
 * 3. When automating a document‑digitization pipeline, you may want to isolate the TIFF image’s vector mask and save it as SVG for downstream CAD or GIS processing.
 * 4. When building a web application that lets users refine TIFF‑based graphics, you can generate an SVG representation of the frame’s clipping path for browser‑based editing.
 * 5. When integrating Aspose.Imaging into a C# service that prepares assets for laser‑cutting, exporting the TIFF clipping path to SVG provides a scalable vector file for the cutter’s software.
 */
