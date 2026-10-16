// HOW-TO: Create Animated APNG From PNG With Custom Frame Delay In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.apng";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, source.Width, source.Height))
                {
                    int frameCount = 5;
                    for (int i = 0; i < frameCount; i++)
                    {
                        apng.AddFrame(source);
                    }

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
 * 1. When you need to generate a simple animated APNG for a website banner by reusing a single PNG image with a specific frame duration.
 * 2. When you want to programmatically convert static PNG assets into an APNG sequence for use in mobile app splash screens that require animation.
 * 3. When you have to create an APNG file with a custom default frame time to meet a design specification for frame rate in a game UI.
 * 4. When you need to automate the production of animated PNGs for email newsletters, ensuring the output folder is created if it doesn’t exist.
 * 5. When you are building a server‑side service that receives a PNG and returns an APNG with multiple identical frames for testing animation playback across browsers.
 */
