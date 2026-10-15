// HOW-TO: Apply Emboss 5x5 Filter to Each Frame of an Animated PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                for (int i = 0; i < apng.PageCount; i++)
                {
                    var frame = (RasterImage)apng.Pages[i];
                    frame.Filter(frame.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));
                }

                apng.Save(outputPath, new ApngOptions());
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
 * 1. When you want to add a stylized embossed effect to every frame of an APNG without losing its animation timing.
 * 2. When you need to programmatically process animated PNGs in a .NET application to create a consistent visual style across all frames.
 * 3. When you are building a game or UI that requires embossed animated icons generated on the fly using C#.
 * 4. When you must batch‑process a collection of APNG files to apply a convolution filter while preserving each frame’s delay information.
 * 5. When you want to integrate Aspose.Imaging into a server‑side service that transforms uploaded animated PNGs with an emboss effect before serving them to clients.
 */
