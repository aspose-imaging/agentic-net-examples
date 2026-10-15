// HOW-TO: Create BMP Venn Diagram with Overlapping Transparent Ellipses in C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output/venn_diagram.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Create(new BmpOptions(), 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // First ellipse - Red
                using (SolidBrush brushRed = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    RectangleF rectRed = new RectangleF(100, 150, 200, 200);
                    graphics.FillEllipse(brushRed, rectRed);
                }

                // Second ellipse - Green
                using (SolidBrush brushGreen = new SolidBrush(Color.FromArgb(128, 0, 255, 0)))
                {
                    RectangleF rectGreen = new RectangleF(200, 150, 200, 200);
                    graphics.FillEllipse(brushGreen, rectGreen);
                }

                // Third ellipse - Blue
                using (SolidBrush brushBlue = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    RectangleF rectBlue = new RectangleF(150, 250, 200, 200);
                    graphics.FillEllipse(brushBlue, rectBlue);
                }

                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to generate a BMP file that visualizes set relationships as a Venn diagram for reports or presentations.
 * 2. When you want to programmatically draw overlapping colored shapes with alpha blending to illustrate data intersections in a .NET application.
 * 3. When you must create a static image for a UI component that requires transparent ellipses to highlight shared areas without using external graphic tools.
 * 4. When you are automating the production of educational graphics, such as biology or math diagrams, directly from C# code using Aspose.Imaging.
 * 5. When you need to export a custom diagram to BMP format for legacy systems that only accept uncompressed bitmap images.
 */
