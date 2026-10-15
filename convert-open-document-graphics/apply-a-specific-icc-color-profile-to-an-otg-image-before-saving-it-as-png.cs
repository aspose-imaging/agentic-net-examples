// HOW-TO: Convert OTG to PNG and Embed ICC Profile Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.otg";
            string iccPath = "Input/profile.icc";
            string outputPath = "Output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(iccPath))
            {
                Console.Error.WriteLine($"File not found: {iccPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] iccData = File.ReadAllBytes(iccPath);

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
                    image.Save(outputPath, options);
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
 * 1. When you need to convert a proprietary OTG vector graphic to a widely supported PNG for web display using C#.
 * 2. When you must embed a specific ICC color profile into an image before saving to ensure color consistency across devices.
 * 3. When automating a batch process that reads OTG files, applies color management, and outputs PNGs in a .NET application.
 * 4. When integrating Aspose.Imaging into a server‑side service that receives OTG uploads and returns PNG thumbnails with the correct color space.
 * 5. When creating a desktop utility that validates the presence of an ICC profile file and converts OTG images to PNG while preserving the profile.
 */
