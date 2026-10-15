// HOW-TO: Apply Zero Opacity Alpha Blend to JPEG Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";
                string overlayPath = "overlay.png";
                string outputPath = "output\\result.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
                if (!File.Exists(overlayPath))
                {
                    Console.Error.WriteLine($"File not found: {overlayPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage background = (RasterImage)Image.Load(inputPath))
                {
                    using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                    {
                        background.Blend(new Point(0, 0), overlay, 0);
                        JpegOptions options = new JpegOptions()
                        {
                            Source = new FileCreateSource(outputPath, false),
                            Quality = 100
                        };
                        background.Save(outputPath, options);
                    }
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
 * 1. When you need to confirm that applying an overlay with zero opacity does not alter the original JPEG background image in a C# application.
 * 2. When you want to test the alpha‑blending functionality of Aspose.Imaging without affecting the source image, using a PNG overlay on a JPEG.
 * 3. When building an automated image pipeline that must safely ignore optional watermarks by blending them with 0% opacity.
 * 4. When validating that the Blend method preserves image quality before saving the result with high‑quality JPEG options.
 * 5. When creating unit tests for image processing code that ensure background integrity after a no‑effect blend operation.
 */
