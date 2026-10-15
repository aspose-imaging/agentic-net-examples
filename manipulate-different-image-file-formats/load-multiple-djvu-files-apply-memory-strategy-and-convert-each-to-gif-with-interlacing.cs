// HOW-TO: Convert Multiple DjVu Files to Interlaced GIFs with Memory Buffer in C# (Aspose.Imaging for .NET)
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
        string[] inputPaths = { "input\\file1.djvu", "input\\file2.djvu" };
        string[] outputPaths = { "output\\file1.gif", "output\\file2.gif" };

        try
        {
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions { BufferSizeHint = 1024 * 1024 };

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, loadOptions))
                {
                    var gifOptions = new GifOptions { Interlaced = true };
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
 * 1. When you need to batch‑process scanned DjVu documents into web‑friendly interlaced GIFs while controlling memory usage.
 * 2. When an application must convert multi‑page DjVu archives to animated GIFs for preview thumbnails in a browser.
 * 3. When a server‑side service processes user‑uploaded DjVu files and saves them as interlaced GIFs to reduce loading time on slow connections.
 * 4. When you want to automate the conversion of DjVu e‑books into GIF images for inclusion in a digital publishing pipeline with limited RAM.
 * 5. When a legacy system requires DjVu graphics to be transformed into GIF format with interlacing for compatibility with older image viewers.
 */
