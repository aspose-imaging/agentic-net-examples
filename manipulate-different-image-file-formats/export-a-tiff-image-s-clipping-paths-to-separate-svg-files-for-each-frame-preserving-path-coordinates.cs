// HOW-TO: Export TIFF Frame Clipping Paths to Individual SVG Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (TiffFrame frame in tiffImage.Frames)
                {
                    tiffImage.ActiveFrame = frame;

                    int width = frame.Width;
                    int height = frame.Height;

                    SvgOptions svgOptions = new SvgOptions();
                    using (Image svgImage = Image.Create(svgOptions, width, height))
                    {
                        Graphics graphics = new Graphics(svgImage);
                        Pen pen = new Pen(Color.Black);

                        var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                            tiffImage.ActiveFrame.PathResources.ToArray(),
                            tiffImage.ActiveFrame.Size);

                        graphics.DrawPath(pen, graphicsPath);

                        string outputPath = Path.Combine(outputDirectory, $"frame_{frameIndex}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        svgImage.Save(outputPath);
                    }

                    frameIndex++;
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
 * 1. When you need to convert each page of a multi‑page TIFF that contains vector clipping paths into separate SVG files for web display or further editing.
 * 2. When you want to preserve the exact path coordinates from a scanned document’s clipping paths while extracting them to scalable vector graphics for CAD integration.
 * 3. When a publishing workflow requires extracting vector outlines from each frame of a TIFF to generate SVG assets for responsive design.
 * 4. When automating batch processing of TIFF artwork, you need to isolate each frame’s clipping path and save it as an SVG to feed into a vector‑based printing pipeline.
 * 5. When developing a C# application that must read TIFF frame metadata and export the associated vector paths to SVG for use in GIS or mapping software.
 */
