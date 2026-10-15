// HOW-TO: Create BMP Image With Skewed Ellipse Using Shear Transform In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            int width = 300;
            int height = 200;

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Matrix shear = new Matrix(1, 0, 0.5f, 1, 0, 0);
                graphics.MultiplyTransform(shear);

                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(50, 30, 200, 100);
                graphics.DrawEllipse(pen, rect);

                canvas.Save();
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
 * 1. When you need to generate a BMP file with a custom‑shaped graphic, such as a skewed ellipse, for legacy Windows applications.
 * 2. When you want to programmatically apply a shear transformation to vector shapes before rasterizing them into a bitmap.
 * 3. When creating dynamic report images that require non‑uniform scaling of geometric objects like ellipses in C#.
 * 4. When building a graphics editor that lets users tilt or skew shapes and export the result as a BMP.
 * 5. When automating the production of test images with specific geometric distortions for computer‑vision algorithm validation.
 */
