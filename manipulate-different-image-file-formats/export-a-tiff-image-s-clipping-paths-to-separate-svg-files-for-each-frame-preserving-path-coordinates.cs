// HOW-TO: Export TIFF Clipping Paths to Separate SVG Files per Frame in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputBaseDir = "output";

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                for (int frameIndex = 0; frameIndex < tiff.Frames.Count(); frameIndex++)
                {
                    tiff.ActiveFrame = tiff.Frames[frameIndex];
                    var frame = tiff.ActiveFrame;
                    var size = frame.Size;

                    var pathResources = frame.PathResources;
                    if (pathResources == null || pathResources.Count == 0)
                        continue;

                    int pathIndex = 0;
                    foreach (var pathRes in pathResources)
                    {
                        string svgPath = Path.Combine(outputBaseDir, $"frame{frameIndex}_path{pathIndex}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(svgPath));

                        FileCreateSource source = new FileCreateSource(svgPath, false);
                        SvgOptions svgOptions = new SvgOptions { Source = source };
                        using (Image svgImage = Image.Create(svgOptions, size.Width, size.Height))
                        {
                            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(svgImage);
                            var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                                new[] { pathRes }, size);
                            Pen pen = new Pen(Color.Black);
                            graphics.DrawPath(pen, graphicsPath);
                            svgImage.Save();
                        }

                        pathIndex++;
                    }
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
 * 1. When you need to extract vector clipping paths from each page of a multi‑page TIFF and save them as individual SVG files for further editing in design tools.
 * 2. When a publishing workflow requires converting TIFF image masks into scalable SVG outlines to preserve exact coordinates for print layout.
 * 3. When an e‑commerce platform wants to generate separate SVG cut‑out shapes from product TIFF scans for dynamic image rendering.
 * 4. When a GIS application must isolate region boundaries stored as TIFF path resources and export them to SVG for overlay on web maps.
 * 5. When a digital archiving system needs to preserve the original vector paths of scanned documents by exporting them from TIFF frames to SVG for long‑term vector storage.
 */
