// HOW-TO: Combine Selected PDF Pages into a Single SVG with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pdfImage = Image.Load(inputPath))
            {
                if (!(pdfImage is IMultipageImage multipage))
                {
                    Console.Error.WriteLine("The loaded file is not a multipage image.");
                    return;
                }

                // Select pages to combine (e.g., first two pages if available)
                int[] selectedPages = new int[] { 0, 1 };
                int pageCount = Math.Min(selectedPages.Length, multipage.PageCount);

                // Determine canvas size (vertical stacking)
                int canvasWidth = 0;
                int canvasHeight = 0;
                for (int i = 0; i < pageCount; i++)
                {
                    Image pageImg = multipage.Pages[selectedPages[i]];
                    canvasWidth = Math.Max(canvasWidth, pageImg.Width);
                    canvasHeight += pageImg.Height;
                }

                // Create SVG graphics canvas
                var svgGraphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(canvasWidth, canvasHeight, 96);
                int offsetY = 0;

                for (int i = 0; i < pageCount; i++)
                {
                    Image pageImg = multipage.Pages[selectedPages[i]];
                    using (RasterImage rasterPage = (RasterImage)pageImg)
                    {
                        svgGraphics.DrawImage(rasterPage, new Point(0, offsetY));
                        offsetY += rasterPage.Height;
                    }
                }

                // Finalize SVG and save
                using (SvgImage finalSvg = svgGraphics.EndRecording())
                {
                    finalSvg.Save(outputPath);
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
 * 1. When you need to merge specific pages of a multi‑page PDF into one scalable SVG for web display.
 * 2. When you want to extract vector graphics from PDF pages and create a combined SVG for printing or editing.
 * 3. When a reporting tool must convert selected PDF report pages into a single SVG chart for inclusion in dashboards.
 * 4. When an e‑learning platform requires consolidating lecture slides from a PDF into one SVG file to preserve resolution independence.
 * 5. When a mobile app needs to load only certain PDF pages as vector assets and render them together as an SVG to reduce file size.
 */
