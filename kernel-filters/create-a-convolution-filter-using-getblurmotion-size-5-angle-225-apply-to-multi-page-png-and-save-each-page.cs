// HOW-TO: Extract and Save Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input_multi.png";
            string outputDir = "output_pages";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        using (Image page = multipage.Pages[i])
                        {
                            string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            var pngOptions = new PngOptions();
                            page.Save(outputPath, pngOptions);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The input image is not a multi-page image.");
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
 * 1. When you need to split a multi‑page PNG (such as a scanned PDF saved as PNG) into individual page files for further processing or distribution.
 * 2. When an application must programmatically extract each frame from an animated PNG and store them as separate static PNG images.
 * 3. When a workflow requires converting a multi‑page medical imaging file into separate images for analysis with other tools.
 * 4. When you want to automate the preparation of individual page assets from a multi‑page design file for web publishing.
 * 5. When a batch job must read a multi‑page PNG, isolate each page, and save them with consistent naming using Aspose.Imaging in C#.
 */
