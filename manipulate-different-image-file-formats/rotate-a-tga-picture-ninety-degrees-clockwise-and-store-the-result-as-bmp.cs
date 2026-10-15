// HOW-TO: Rotate TGA Image 90 Degrees Clockwise and Save as BMP in C# (Aspose.Imaging for .NET)
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

namespace ImageProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.tga";
                string outputPath = "output/output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    var options = new BmpOptions();
                    image.Save(outputPath, options);
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
 * 1. When converting legacy TGA textures from a game asset pipeline to BMP format while correcting orientation for Windows applications.
 * 2. When preparing scanned TGA graphics for printing by rotating them 90° clockwise and saving as BMP for compatibility with legacy printers.
 * 3. When automating batch processing of TGA screenshots that need to be displayed in a right‑hand orientation in a .NET desktop viewer that only supports BMP.
 * 4. When integrating a C# service that receives TGA files from a mobile device, rotates them to match portrait mode, and stores them as BMP for archival storage.
 * 5. When developing a conversion tool that fixes incorrectly oriented TGA icons before embedding them into a Windows resource file that requires BMP images.
 */
