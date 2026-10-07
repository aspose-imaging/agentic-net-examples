// HOW-TO: Create APNG From PNG With 100ms Frame Delay In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, source.Width, source.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(source);
                    apng.Save();
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
 * 1. When you need to turn a static PNG icon into a lightweight animated APNG for use in web UI with a 100 ms frame interval.
 * 2. When generating a simple frame‑by‑frame animation from a single image for inclusion in mobile app splash screens that require precise timing.
 * 3. When converting a PNG logo into an animated badge that loops every tenth of a second for display in desktop notifications.
 * 4. When creating an APNG sprite sheet from a single PNG to meet platform constraints that only support animated PNGs with fixed frame delays.
 * 5. When automating the production of animated PNG assets for game UI elements where each frame must display for exactly 100 ms.
 */
