// HOW-TO: Create BMP Image with Nested Colored Rectangles in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/nested_rectangles.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 500;
            int height = 500;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int rectCount = 10;
                int marginStep = 20;
                Color[] colors = new Color[] { Color.Red, Color.Blue };

                for (int i = 0; i < rectCount; i++)
                {
                    int margin = i * marginStep;
                    int rectWidth = width - 2 * margin;
                    int rectHeight = height - 2 * margin;
                    if (rectWidth <= 0 || rectHeight <= 0)
                        break;

                    using (SolidBrush brush = new SolidBrush(colors[i % colors.Length]))
                    {
                        graphics.FillRectangle(brush, margin, margin, rectWidth, rectHeight);
                    }
                }

                image.Save();
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
 * 1. When you need to programmatically generate a BMP file that visualizes a series of concentric rectangles for UI mock‑ups or design prototypes.
 * 2. When creating test patterns to verify image processing pipelines, such as checking scaling or cropping algorithms on a known nested‑shape bitmap.
 * 3. When producing simple graphics for educational tutorials that demonstrate drawing operations with Aspose.Imaging’s Graphics and SolidBrush classes.
 * 4. When generating placeholder assets for games or applications that require alternating colored frames as background elements.
 * 5. When automating the creation of printable diagrams, like step‑by‑step layout guides, that rely on decreasing rectangle sizes in a BMP format.
 */
