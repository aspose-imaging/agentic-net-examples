// HOW-TO: How To Load And Save Multi‑Page PNG Images In C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        Image page = multipage.Pages[i];
                        // No processing applied to each page in this example
                    }
                }

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to read a multi‑page PNG file, edit each page individually, and then write the result back to disk using C#.
 * 2. When you want to batch‑process scanned documents stored as a multi‑page PNG, applying transformations page by page before saving.
 * 3. When an application must extract each frame of an animated PNG for further analysis or conversion in a .NET environment.
 * 4. When you need to ensure the output PNG retains the same multi‑page structure after performing custom operations on each page.
 * 5. When a server‑side service processes uploaded multi‑page PNGs and must re‑save them with specific Aspose.Imaging options.
 */
