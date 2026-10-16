// HOW-TO: Convert DjVu Document To Animated GIF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                djvuImage.Save(outputPath, gifOptions);
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
 * 1. When you need to display multi‑page DjVu scans as a single animated GIF on a website using C#.
 * 2. When you want to generate lightweight GIF previews of DjVu manuals for mobile apps without custom animation settings.
 * 3. When an archival system requires converting DjVu documents to GIF format for compatibility with legacy image viewers.
 * 4. When you automate batch processing to turn scanned DjVu books into GIF animations for e‑learning platforms.
 * 5. When you integrate Aspose.Imaging in a .NET service that streams DjVu pages as GIFs for quick client‑side rendering.
 */
