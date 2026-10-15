// HOW-TO: Convert PNG to SVG and Export High Resolution PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.png");
            string svgPath = Path.Combine("Output", "image.svg");
            string pdfPath = Path.Combine("Output", "image.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(svgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            using (Image pngImage = Image.Load(inputPath))
            {
                pngImage.Save(svgPath, new SvgOptions());
            }

            using (Image svgImage = Image.Load(svgPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    },
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };
                svgImage.Save(pdfPath, pdfOptions);
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
 * 1. When you need to embed a raster logo from a PNG into a printable PDF with vector quality, you can convert the PNG to SVG and then rasterize it at 300 dpi for the PDF.
 * 2. When generating product catalogs, you may convert product images stored as PNGs to scalable SVGs and then create high‑resolution PDF pages that retain sharpness on any paper size.
 * 3. When an application must provide downloadable PDFs of UI screenshots, converting the PNG screenshots to SVG first ensures the PDF can be scaled without pixelation.
 * 4. When automating report generation, you can transform PNG charts into SVG vectors and embed them in a PDF with precise dimensions and white background.
 * 5. When preparing marketing assets, converting PNG icons to SVG and then exporting them as 300 dpi PDFs allows designers to print the icons at any size while preserving clarity.
 */
