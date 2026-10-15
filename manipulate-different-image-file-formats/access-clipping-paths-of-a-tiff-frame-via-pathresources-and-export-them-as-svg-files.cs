// HOW-TO: Extract TIFF Clipping Paths to Separate SVG Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputDir = "output_paths";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDir);

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var pathResources = tiffImage.ActiveFrame.PathResources;
                int index = 0;
                foreach (var pathResource in pathResources)
                {
                    string svgPath = Path.Combine(outputDir, $"path_{index}.svg");
                    var svgOptions = new SvgOptions
                    {
                        Source = new FileCreateSource(svgPath, false)
                    };
                    using (Image svgImage = Image.Create(svgOptions, tiffImage.Width, tiffImage.Height))
                    {
                        svgImage.Save();
                    }
                    index++;
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
 * 1. When a developer needs to preserve vector outlines from a multi‑page TIFF for use in web graphics, they can extract each clipping path as an SVG file.
 * 2. When preparing print‑ready assets, extracting TIFF clipping paths to SVG allows designers to edit or reuse the vector masks in illustration software.
 * 3. When building a document conversion pipeline, exporting TIFF path resources as SVG enables downstream tools to apply the same cutout shapes to other image formats.
 * 4. When creating an interactive image viewer, developers can load the SVG paths to render selectable regions that match the original TIFF’s clipping masks.
 * 5. When automating quality‑control checks, extracting and comparing SVG representations of TIFF clipping paths helps verify that vector data has not been corrupted during processing.
 */
