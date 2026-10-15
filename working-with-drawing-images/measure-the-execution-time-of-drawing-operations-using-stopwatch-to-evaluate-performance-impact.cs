// HOW-TO: Measure Drawing Performance on PNG Images with Stopwatch in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    Pen pen = new Pen(Color.Blue, 5);
                    Font font = new Font("Arial", 24);

                    var stopwatch = new System.Diagnostics.Stopwatch();
                    stopwatch.Start();

                    graphics.DrawRectangle(pen, 50, 50, 200, 150);
                    graphics.FillEllipse(brush, 100, 100, 150, 100);
                    graphics.DrawLine(pen, new Point(0, 0), new Point(300, 300));
                    graphics.DrawString("Test", font, brush, new PointF(60, 60));

                    stopwatch.Stop();
                    Console.WriteLine($"Drawing time: {stopwatch.ElapsedMilliseconds} ms");
                }

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to benchmark how long custom graphics such as rectangles, ellipses, lines, and text take to render on a PNG using Aspose.Imaging in C#.
 * 2. When you want to compare the performance impact of different brushes, pens, or fonts in Aspose.Imaging drawing operations.
 * 3. When you are building a server‑side image generation service and must ensure drawing operations meet specific latency requirements.
 * 4. When you need to log the rendering time of dynamically created charts or diagrams to monitor application health.
 * 5. When you are profiling how image size or drawing complexity affects speed to choose optimal dimensions for a web application.
 */
