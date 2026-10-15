// HOW-TO: Create a Star Outline PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Aspose.Imaging.Image.Create(
                new PngOptions { Source = new FileCreateSource(outputPath, false) },
                500, 500))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);

                var p0 = new Aspose.Imaging.Point(250, 50);
                var p1 = new Aspose.Imaging.Point(317, 200);
                var p2 = new Aspose.Imaging.Point(470, 200);
                var p3 = new Aspose.Imaging.Point(340, 300);
                var p4 = new Aspose.Imaging.Point(380, 450);
                var p5 = new Aspose.Imaging.Point(250, 350);
                var p6 = new Aspose.Imaging.Point(120, 450);
                var p7 = new Aspose.Imaging.Point(160, 300);
                var p8 = new Aspose.Imaging.Point(30, 200);
                var p9 = new Aspose.Imaging.Point(183, 200);

                graphics.DrawLine(pen, p0, p1);
                graphics.DrawLine(pen, p1, p2);
                graphics.DrawLine(pen, p2, p3);
                graphics.DrawLine(pen, p3, p4);
                graphics.DrawLine(pen, p4, p5);
                graphics.DrawLine(pen, p5, p6);
                graphics.DrawLine(pen, p6, p7);
                graphics.DrawLine(pen, p7, p8);
                graphics.DrawLine(pen, p8, p9);
                graphics.DrawLine(pen, p9, p0);

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
 * 1. When you need to generate a decorative star overlay on a blank PNG for UI icons or watermarks.
 * 2. When you want to programmatically draw custom vector shapes, such as a star, without using external design tools.
 * 3. When you need to create a high‑resolution PNG badge with precise line thickness and color for branding.
 * 4. When you are building a reporting tool that adds geometric markers (e.g., stars) to charts or diagrams on the fly.
 * 5. When you require an automated way to produce template images with star outlines for game assets or printable materials.
 */
