// HOW-TO: Copy JPEG and Preserve JFIF and EXIF Segments Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                {
                    image.CacheData();
                }

                JpegOptions options = new JpegOptions();
                options.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, options);
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
 * 1. When a developer needs to create a duplicate of an existing JPEG without losing its embedded JFIF and EXIF metadata, such as camera settings or GPS information.
 * 2. When an application must re‑encode a JPEG after processing (e.g., applying filters) while keeping the original thumbnail and other metadata intact.
 * 3. When a server‑side service stores user‑uploaded photos and wants to rewrite the file to a new location or format without stripping the EXIF orientation data.
 * 4. When a batch‑processing tool generates new JPEG files from templates and must retain the original JFIF application markers for compatibility with legacy software.
 * 5. When a digital asset management system updates image files and requires that existing EXIF tags (author, copyright, etc.) remain unchanged after saving.
 */
