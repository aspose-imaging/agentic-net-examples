// HOW-TO: Convert DjVu Pages to Interlaced GIF Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/document.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true,
                        MultiPageOptions = new DjvuMultiPageOptions(i)
                    };

                    djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as web‑optimized interlaced GIFs for faster progressive loading.
 * 2. When a document‑management system must convert scanned DjVu archives into animated‑compatible GIF frames while preserving page order.
 * 3. When you want to generate thumbnail previews of DjVu pages in GIF format with interlacing enabled for smoother display on low‑bandwidth connections.
 * 4. When an e‑learning platform requires converting DjVu lecture notes into separate GIF images that can be embedded in HTML pages with progressive rendering.
 * 5. When a batch‑processing tool must automate the conversion of a folder of DjVu files into interlaced GIFs for archival or publishing workflows.
 */
