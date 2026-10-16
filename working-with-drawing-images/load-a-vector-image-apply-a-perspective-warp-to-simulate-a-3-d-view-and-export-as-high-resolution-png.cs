// HOW-TO: Apply Perspective Warp to EPS Vector and Export High-Resolution PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "vector.eps");
            string outputPath = Path.Combine("Output", "warped.png");
            string tempPngPath = Path.Combine("Output", "temp.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load vector image and rasterize to high‑resolution PNG
            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = 2000,
                        PageHeight = 2000
                    }
                };
                vectorImage.Save(tempPngPath, rasterOptions);
            }

            // Load the rasterized image
            using (RasterImage sourceRaster = (RasterImage)Image.Load(tempPngPath))
            {
                // Create a blank canvas for the warped result
                var canvasOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, sourceRaster.Width, sourceRaster.Height))
                {
                    // Define destination quadrilateral points for perspective warp
                    var destPoints = new PointF[]
                    {
                        new PointF(0, 0),
                        new PointF(sourceRaster.Width * 0.9f, sourceRaster.Height * 0.1f),
                        new PointF(sourceRaster.Width * 0.8f, sourceRaster.Height),
                        new PointF(sourceRaster.Width * 0.2f, sourceRaster.Height * 0.9f)
                    };

                    // Draw the source image onto the canvas with the warp
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(
                        sourceRaster,
                        destPoints,
                        new Rectangle(0, 0, sourceRaster.Width, sourceRaster.Height),
                        GraphicsUnit.Pixel);

                    // Save the warped image as high‑resolution PNG
                    canvas.Save(outputPath, new PngOptions());
                }
            }

            // Optional cleanup of temporary file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { }
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
 * 1. When you need to display a scalable EPS logo on a 3-D product mockup, you can rasterize it and apply a perspective warp to generate a high-resolution PNG for the web.
 * 2. When converting architectural vector drawings to realistic angled views for presentation slides, this code rasterizes the EPS and warps it to simulate depth before saving as PNG.
 * 3. When creating printable marketing materials that require a vector illustration to appear as if photographed from an angle, the perspective transformation produces a high-quality PNG ready for print.
 * 4. When building an e‑commerce platform that shows product packaging designs in a tilted view, you can use this routine to turn EPS artwork into a warped PNG thumbnail.
 * 5. When generating game assets where a flat vector texture must be shown with perspective on a UI element, the code rasterizes the EPS and warps it to a PNG with alpha transparency.
 */
