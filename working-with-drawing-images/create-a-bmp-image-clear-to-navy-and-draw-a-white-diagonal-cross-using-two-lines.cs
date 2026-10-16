// HOW-TO: Create BMP Image with Navy Background and White Diagonal Cross in C# (Aspose.Imaging for .NET)
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
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "cross.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Navy);

                Pen whitePen = new Pen(Color.White, 1);
                graphics.DrawLine(whitePen, 0, 0, width - 1, height - 1);
                graphics.DrawLine(whitePen, 0, height - 1, width - 1, 0);

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
 * 1. When you need to generate a small BMP placeholder with a navy background and a white X for UI testing or mock‑ups.
 * 2. When you want to programmatically create a simple flag‑style graphic, such as a navy field crossed by white lines, for reports or dashboards.
 * 3. When you need to produce a test pattern image to verify that image‑processing pipelines correctly handle BMP files, colors, and line drawing.
 * 4. When you are building a custom icon set and require a basic cross symbol on a solid background without using external design tools.
 * 5. When you want to automate the creation of watermark overlays that consist of diagonal lines on a solid color for batch‑processing images.
 */
