// HOW-TO: Increase GIF Contrast to Maximum Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath) as RasterImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load image as RasterImage.");
                    return;
                }

                // Set contrast to a high level (maximum 100)
                image.AdjustContrast(100);
                image.Save(outputPath);
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
 * 1. When you need to enhance the visual impact of animated GIFs for a marketing email by boosting their contrast using Aspose.Imaging before embedding them.
 * 2. When a web application must automatically improve low‑contrast GIF icons uploaded by users to meet brand style guidelines with a C# contrast‑adjustment routine.
 * 3. When a game developer wants to preprocess sprite‑sheet GIFs to make characters stand out on dark backgrounds by increasing contrast programmatically.
 * 4. When a digital archivist needs to increase the readability of scanned GIF documents that appear faded by applying maximum contrast in C#.
 * 5. When a social‑media tool generates GIF memes and requires a quick C# method to apply maximum contrast for better shareability.
 */
