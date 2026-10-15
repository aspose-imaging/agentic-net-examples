// HOW-TO: Convert OTG to PNG with Automatic Resource Disposal in C# (Aspose.Imaging for .NET)
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

namespace OtgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert legacy OTG graphics to modern PNG files in a desktop C# application while ensuring memory is released promptly.
 * 2. When building an automated image‑processing pipeline that reads OTG assets from a folder and outputs PNGs for web display, using a using block prevents resource leaks.
 * 3. When integrating Aspose.Imaging into a server‑side service that receives OTG uploads and returns PNG thumbnails, proper disposal avoids exhausting server resources.
 * 4. When migrating a legacy design workflow to .NET and must batch‑convert multiple OTG drawings to PNG without leaving file handles open.
 * 5. When creating a command‑line utility for designers to quickly export OTG diagrams as PNGs, wrapping the Image object in a using statement guarantees clean cleanup after each conversion.
 */
