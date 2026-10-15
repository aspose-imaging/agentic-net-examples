// HOW-TO: Shear an SVG and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.svg";
        string outputPath = "output/output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = vectorImage.Width * 2;
                int height = vectorImage.Height * 2;
                int shearOffset = width / 10;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Compression = TiffCompressions.None;

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(tiffOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    Aspose.Imaging.Point[] destPoints = new Aspose.Imaging.Point[]
                    {
                        new Aspose.Imaging.Point(0, 0),
                        new Aspose.Imaging.Point(width + shearOffset, 0),
                        new Aspose.Imaging.Point(0, height)
                    };
                    graphics.DrawImage(vectorImage, destPoints);

                    canvas.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a scalable vector graphic into a raster TIFF for printing while applying a shear distortion.
 * 2. When you must generate a high‑resolution TIFF from an SVG for archival purposes and need to double its dimensions.
 * 3. When a web service requires a non‑compressed TIFF image with a custom shear transformation for downstream image analysis.
 * 4. When creating batch‑processed engineering drawings where SVG diagrams must be sheared and saved as TIFF for CAD compatibility.
 * 5. When automating the preparation of marketing assets that need a slanted SVG rendered as a TIFF with exact pixel control.
 */
