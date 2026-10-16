// HOW-TO: Rotate BMP Image 90 Degrees Clockwise After SVG Conversion In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string svgPath = "input.svg";
            string outputDir = "output";
            string rotatedBmpPath = Path.Combine(outputDir, "rotated.bmp");
            string tempBmpPath = Path.Combine(outputDir, "temp.bmp");

            // Input file check
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(rotatedBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));

            // Convert SVG to BMP (temporary file)
            using (Image svgImage = Image.Load(svgPath))
            {
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use original dimensions if available
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                svgImage.Save(tempBmpPath, bmpOptions);
            }

            // Load the temporary BMP, rotate, and save final result
            using (RasterImage bmpImage = (RasterImage)Image.Load(tempBmpPath))
            {
                bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bmpImage.Save(rotatedBmpPath);
            }

            // Clean up temporary file
            if (File.Exists(tempBmpPath))
            {
                try { File.Delete(tempBmpPath); } catch { /* ignore cleanup errors */ }
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
 * 1. When you need to generate a BMP thumbnail from an SVG logo and orient it correctly for display in a Windows desktop application.
 * 2. When a batch process must convert vector graphics to raster BMP files and rotate them to match a printer’s landscape layout.
 * 3. When an e‑learning platform requires SVG icons to be saved as BMP assets with a 90‑degree clockwise orientation for legacy software compatibility.
 * 4. When automating image preparation for a GIS system that only accepts BMP files and expects them to be pre‑rotated to align with map coordinates.
 * 5. When creating a migration script that transforms SVG diagrams into BMP images and applies a rotation to fit into a fixed‑size report template.
 */
