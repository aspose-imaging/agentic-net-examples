// HOW-TO: Convert ODG File to BMP Image While Keeping Original Size in C# (Aspose.Imaging for .NET)
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

namespace OdgToBmpConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output\\output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    BmpOptions options = new BmpOptions();
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
 * 1. When a developer needs to display an OpenDocument Graphic in a Windows Forms control that only accepts BMP images.
 * 2. When converting ODG diagrams to BMP format for printing on devices that require bitmap input while preserving the original dimensions.
 * 3. When generating BMP thumbnails of ODG files for a file‑explorer preview pane in a C# application.
 * 4. When archiving ODG assets in a legacy system that only supports BMP files and must keep the exact size of the original graphics.
 * 5. When preprocessing ODG drawings before applying further Aspose.Imaging operations that work exclusively with bitmap formats.
 */
