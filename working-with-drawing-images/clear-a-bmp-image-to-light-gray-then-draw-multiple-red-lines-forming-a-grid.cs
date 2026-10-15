// HOW-TO: Create BMP Image with Light Gray Background and Red Grid in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            int width = 800;
            int height = 600;

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (var image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                var lightGray = Color.FromArgb(211, 211, 211);
                graphics.Clear(lightGray);

                var redPen = new Pen(Color.Red, 1);

                for (int x = 0; x <= width; x += 50)
                {
                    graphics.DrawLine(redPen, x, 0, x, height);
                }

                for (int y = 0; y <= height; y += 50)
                {
                    graphics.DrawLine(redPen, 0, y, width, y);
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
 * 1. When you need to generate a BMP file with a uniform light‑gray canvas and overlay a red grid for diagramming or UI mock‑ups in a C# application.
 * 2. When you want to programmatically create a background image for a game level map where the grid helps align objects and the file must be saved as BMP.
 * 3. When you are building a reporting tool that adds a printable grid overlay to scanned documents and requires the output in BMP format using Aspose.Imaging.
 * 4. When you need to produce a simple test pattern image for calibrating display hardware, with a light gray base and evenly spaced red lines created in .NET.
 * 5. When you are automating the creation of placeholder graphics for documentation, needing a light gray BMP with a red grid to illustrate layout dimensions.
 */
