// HOW-TO: Convert Each DjVu Page to Separate GIF Files in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    var page = djvu.Pages[i];
                    var gifOptions = new GifOptions();
                    string pageOutput = Path.Combine(outputDir, $"page_{i + 1}.gif");
                    page.Save(pageOutput, gifOptions);
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
 * 1. When you need to extract individual pages from a multi‑page DjVu document and save them as separate GIF images for web preview.
 * 2. When an application must batch‑process scanned DjVu files and generate lightweight GIF thumbnails for each page.
 * 3. When you want to convert archival DjVu documents into GIF format to embed pages in email newsletters that only support GIF.
 * 4. When a digital library system requires separate GIF files for each DjVu page to support legacy browsers that cannot display DjVu.
 * 5. When automating a workflow that transforms DjVu manuals into GIF images for inclusion in a mobile app’s offline help section.
 */
