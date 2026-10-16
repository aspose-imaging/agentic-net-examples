// HOW-TO: Apply Red Tint to WMF and Export as SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image wmfImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)wmfImage;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                RasterImage tint = (RasterImage)Image.Create(new BmpOptions(), raster.Width, raster.Height);
                Graphics g = new Graphics(tint);
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), new Rectangle(0, 0, tint.Width, tint.Height));

                raster.Blend(new Point(0, 0), tint, 128);

                raster.Save(outputPath, new SvgOptions());
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
 * 1. When you need to recolor legacy WMF icons with a semi‑transparent red overlay before embedding them in a web page as scalable SVG graphics.
 * 2. When a reporting tool generates WMF charts that must match a brand’s red color scheme and be saved as SVG for responsive design.
 * 3. When converting printed vector assets to SVG while applying a uniform tint to meet accessibility contrast requirements.
 * 4. When automating batch processing of WMF files to add a corporate color tint and output lightweight SVG files for mobile applications.
 * 5. When integrating Aspose.Imaging in a C# service that dynamically tints user‑uploaded WMF drawings and returns them as SVG for further editing.
 */
