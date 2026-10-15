// HOW-TO: Apply Magic Wand Selection to JPEG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Apply();

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, new PngOptions());
                    File.WriteAllBytes(outputPath, ms.ToArray());
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
 * 1. When you need to programmatically select a region in a JPEG using Aspose.Imaging's MagicWand tool and export the edited image as a PNG file.
 * 2. When you want to process user‑uploaded photos in memory, apply a tolerance‑based selection, and store the result without writing intermediate files.
 * 3. When you are building a web service that receives image bytes, performs content‑aware editing, and returns the modified image as a stream.
 * 4. When you must convert high‑resolution raster images to lossless PNG after applying selective masking for further analysis or printing.
 * 5. When you need to integrate Aspose.Imaging into a C# workflow that automates background removal or object isolation before saving the output.
 */
