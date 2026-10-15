// HOW-TO: Create Multiple BMP Images With Colored Diagonal Lines In C# (Aspose.Imaging for .NET)
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
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            int width = 200;
            int height = 200;

            var colors = new (Color color, string name)[]
            {
                (Color.Red, "Red"),
                (Color.Green, "Green"),
                (Color.Blue, "Blue"),
                (Color.Yellow, "Yellow"),
                (Color.Magenta, "Magenta"),
                (Color.Cyan, "Cyan"),
                (Color.Black, "Black")
            };

            foreach (var (color, name) in colors)
            {
                string outputPath = Path.Combine(outputDir, $"diag_{name}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var bmpOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (var image = Image.Create(bmpOptions, width, height))
                {
                    var graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    var pen = new Pen(color, 5);
                    graphics.DrawLine(pen, 0, 0, width - 1, height - 1);
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
 * 1. When you need a set of BMP test files with distinct colored diagonal lines to verify image rendering pipelines in a C# application.
 * 2. When generating sample assets for UI components that display diagonal patterns, such as loading screens or placeholders, using Aspose.Imaging.
 * 3. When creating reference images for automated visual regression tests that compare color accuracy across different BMP outputs.
 * 4. When preparing demonstration graphics for documentation or tutorials that show how to draw lines with various pens in .NET.
 * 5. When batch‑producing simple diagnostic images to check file‑system permissions and BMP file creation on different environments.
 */
