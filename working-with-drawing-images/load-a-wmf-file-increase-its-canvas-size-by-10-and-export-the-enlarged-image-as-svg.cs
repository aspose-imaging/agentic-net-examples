// HOW-TO: Resize WMF Canvas by 10% and Export as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                int newWidth = (int)(originalWidth * 1.1);
                int newHeight = (int)(originalHeight * 1.1);

                var rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = newWidth,
                    PageHeight = newHeight,
                    BackgroundColor = Color.White
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a Windows Metafile in a web page and must enlarge its dimensions without losing vector quality, you can load the WMF, increase the canvas by 10%, and save it as SVG using Aspose.Imaging for .NET.
 * 2. When generating printable graphics from legacy WMF assets and the target size is slightly larger than the original, this code resizes the image and converts it to scalable SVG for high‑resolution output.
 * 3. When an application migrates old WMF icons to modern UI frameworks that require SVG, the snippet expands the icon canvas to add padding and exports it as an SVG file.
 * 4. When automating batch processing of WMF drawings that need a uniform 10 % margin before being stored in a vector‑based asset library, the code performs the resize and conversion in C#.
 * 5. When creating responsive diagrams from WMF sources for mobile devices, increasing the canvas size and converting to SVG ensures the graphics scale cleanly across different screen sizes.
 */
