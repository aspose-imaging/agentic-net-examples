// HOW-TO: Create Wave Pattern BMP Using Bezier Curves in C# (Aspose.Imaging for .NET)
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
            string outputPath = "wave.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            int width = 800;
            int height = 200;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);

                int segmentCount = 6;
                float segmentWidth = (float)width / segmentCount;
                float amplitude = height / 4f;

                for (int i = 0; i < segmentCount; i++)
                {
                    float startX = i * segmentWidth;
                    float endX = (i + 1) * segmentWidth;
                    float startY = height / 2f;
                    float endY = startY;

                    float control1X = startX + segmentWidth / 4f;
                    float control2X = startX + 3 * segmentWidth / 4f;
                    float control1Y = startY + ((i % 2 == 0) ? amplitude : -amplitude);
                    float control2Y = startY + ((i % 2 == 0) ? -amplitude : amplitude);

                    graphics.DrawBezier(pen,
                        new PointF(startX, startY),
                        new PointF(control1X, control1Y),
                        new PointF(control2X, control2Y),
                        new PointF(endX, endY));
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
 * 1. When you need to generate a simple waveform illustration for a UI thumbnail and want to output it as a BMP file using Aspose.Imaging in C#.
 * 2. When you want to programmatically create a repeating sine‑like pattern for testing image compression or rendering pipelines without external design tools.
 * 3. When you need to embed a custom wave graphic into a report or document where BMP format is required for compatibility with legacy systems.
 * 4. When you are building a diagnostic tool that visualizes signal data as a wave and prefer drawing it with Bezier curves for smoothness in .NET.
 * 5. When you want to automate the production of background textures or decorative separators for a game or application and need precise control over curve points using C#.
 */
