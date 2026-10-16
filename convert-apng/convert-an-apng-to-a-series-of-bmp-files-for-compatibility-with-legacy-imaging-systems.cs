// HOW-TO: Extract APNG Frames to BMP Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "animation.apng");
            string outputDirectory = Path.Combine("Output");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                ApngImage apng = (ApngImage)image;
                int frameCount = apng.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    RasterImage frame = (RasterImage)apng.Pages[i];
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    frame.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to break down an animated PNG into individual BMP files for a legacy system that only supports static BMP images.
 * 2. When converting game asset animations stored as APNG into separate BMP frames to feed into an older graphics engine that requires BMP textures.
 * 3. When preparing frame‑by‑frame screenshots from an APNG for documentation or quality‑assurance testing that must be saved in BMP format.
 * 4. When migrating a batch of APNG animations to a printing workflow that only accepts BMP files for each page of the animation.
 * 5. When integrating APNG support into a C# application that must output each animation frame as a BMP to maintain compatibility with third‑party hardware devices.
 */
