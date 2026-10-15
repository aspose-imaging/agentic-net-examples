// HOW-TO: Convert DjVu Document To Interlaced GIF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

namespace DjvuToGifConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.djvu";
                string outputPath = "output/output.gif";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    GifOptions options = new GifOptions
                    {
                        Interlaced = true
                    };
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
 * 1. When you need to display scanned DjVu pages on web browsers that only support interlaced GIF images.
 * 2. When you want to create smaller, progressively loading GIF previews of DjVu documents for faster page rendering.
 * 3. When a document management system must archive DjVu files as GIFs with interlacing to preserve visual quality during bandwidth‑limited transfers.
 * 4. When converting multi‑page DjVu reports into a single GIF file for embedding in email newsletters or social media posts.
 * 5. When automating a batch process that transforms DjVu manuals into interlaced GIFs for compatibility with legacy image viewers.
 */
