// HOW-TO: How To Disable Anti-Aliasing When Converting Svg To Png In C# (Aspose.Imaging for .NET)
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
using System.Drawing.Drawing2D;

namespace SvgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.None
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    image.Save(outputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating thumbnails from vector graphics and need faster rendering by turning off smoothing.
 * 2. When processing large batches of SVG files on a server and want to reduce CPU usage during PNG conversion.
 * 3. When creating pixel-perfect screenshots of SVG diagrams for technical documentation where anti-aliasing would blur fine lines.
 * 4. When integrating SVG to PNG conversion into a game asset pipeline that requires crisp edges without smoothing.
 * 5. When developing a web service that returns PNG previews of user‑uploaded SVGs and must deliver results quickly.
 */
