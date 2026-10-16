// HOW-TO: Create BMP Image With Ellipse And Reset Transform In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                using (Image image = Image.Create(bmpOptions, 200, 200))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    Pen pen = new Pen(Color.Blue, 3);
                    Rectangle rect = new Rectangle(20, 20, 160, 120);
                    graphics.DrawEllipse(pen, rect);
                    graphics.ResetTransform();
                    image.Save();
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
 * 1. When you need to generate a BMP file programmatically and draw a vector ellipse for a simple diagram or placeholder graphic.
 * 2. When you want to create a blank canvas, render a shape, and then clear any transformations before adding more drawing operations.
 * 3. When an application must produce a bitmap thumbnail that includes a highlighted circular region, such as a selection mask.
 * 4. When you are building a reporting tool that adds custom elliptical annotations to BMP charts and requires the graphics state to be reset for subsequent elements.
 * 5. When you need to automate the creation of test images with specific dimensions and shapes to validate image‑processing pipelines.
 */
