// HOW-TO: Convert WebP to GIF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
        string inputPath = "Input\\input.webp";
        string outputPath = "Output\\output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (GifOptions gifOptions = new GifOptions())
            {
                image.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to serve animated images in GIF format for browsers that do not support WebP, they can convert WebP files to GIF using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform wants to generate lightweight product animation previews from high‑quality WebP assets for email newsletters, this code enables batch conversion to GIF.
 * 3. When a mobile app must cache user‑uploaded WebP stickers as GIFs for compatibility with older Android versions, the snippet provides a simple C# conversion routine.
 * 4. When a content management system automates the creation of GIF thumbnails from WebP uploads to maintain consistent media formats across the site, developers can use this approach.
 * 5. When a digital marketing tool needs to transform WebP banners into GIFs for social media platforms that only accept GIF files, the code offers a quick C# solution.
 */
