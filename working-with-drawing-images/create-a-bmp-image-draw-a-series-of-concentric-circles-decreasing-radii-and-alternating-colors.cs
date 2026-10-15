// HOW-TO: Create BMP with Concentric Red and Blue Circles in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;
            int centerX = width / 2;
            int centerY = height / 2;

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20;
                int index = 0;

                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Aspose.Imaging.Color circleColor = (index % 2 == 0) ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Pen pen = new Pen(circleColor, 3);
                    graphics.DrawEllipse(pen, centerX - radius, centerY - radius, radius * 2, radius * 2);
                    index++;
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
 * 1. When you need to generate a BMP file that visualizes radar range rings for a mapping application.
 * 2. When you want to create a simple test pattern of alternating colored circles to verify image rendering pipelines.
 * 3. When you are building a desktop tool that produces printable circular badges or stickers in BMP format.
 * 4. When you need to programmatically draw concentric circles for a scientific diagram, such as illustrating wavefronts, using C# and Aspose.Imaging.
 * 5. When you require an automated way to produce layered circle graphics for UI placeholders or background textures without using external design software.
 */
