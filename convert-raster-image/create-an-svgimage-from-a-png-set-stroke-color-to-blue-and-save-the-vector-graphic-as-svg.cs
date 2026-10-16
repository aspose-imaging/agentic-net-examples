// HOW-TO: Create SVG From PNG With Blue Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pngImage = Image.Load(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;

                SvgOptions svgOptions = new SvgOptions();
                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);

                    Pen bluePen = new Pen(Color.Blue);
                    graphics.DrawRectangle(bluePen, 0, 0, width - 1, height - 1);
                    graphics.DrawImage(pngImage, new Point(0, 0));

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
 * 1. When you need to embed a PNG image into an SVG file and add a blue rectangle border for web display.
 * 2. When you want to convert existing raster assets to scalable SVGs while preserving size and applying a blue stroke using C# and Aspose.Imaging.
 * 3. When you automate branding pipelines that generate SVG versions of product photos with a consistent blue outline.
 * 4. When you create mixed-content graphics that combine vector shapes and a raster PNG for printing or PDF output in a .NET application.
 * 5. When you build a C# tool that prepares SVG icons with a blue frame for UI components or documentation.
 */
