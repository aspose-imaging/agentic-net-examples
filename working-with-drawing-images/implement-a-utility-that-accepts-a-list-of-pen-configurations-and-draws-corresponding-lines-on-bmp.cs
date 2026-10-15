// HOW-TO: Draw Multiple Colored Lines on BMP Using Pen Configurations in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Define pen configurations
            var penConfigs = new List<PenConfig>
            {
                new PenConfig { Color = Color.Red, Width = 5, X1 = 50, Y1 = 50, X2 = 450, Y2 = 50 },
                new PenConfig { Color = Color.Green, Width = 3, X1 = 50, Y1 = 100, X2 = 450, Y2 = 200 },
                new PenConfig { Color = Color.Blue, Width = 2, X1 = 100, Y1 = 300, X2 = 400, Y2 = 400 }
            };

            // Create BMP image
            var bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw lines based on configurations
                foreach (var cfg in penConfigs)
                {
                    var pen = new Pen(cfg.Color, cfg.Width);
                    graphics.DrawLine(pen, cfg.X1, cfg.Y1, cfg.X2, cfg.Y2);
                }

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    class PenConfig
    {
        public Color Color { get; set; }
        public float Width { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a simple diagram or schematic with colored lines for a report without using external design tools.
 * 2. When creating dynamic visual indicators such as progress bars or status lines in a server‑side image processing pipeline.
 * 3. When programmatically adding annotation lines to scanned documents or maps stored as BMP files.
 * 4. When building a custom chart or timeline where each segment has its own color and thickness defined at runtime.
 * 5. When automating the production of test images to verify rendering or printing quality of line graphics.
 */
