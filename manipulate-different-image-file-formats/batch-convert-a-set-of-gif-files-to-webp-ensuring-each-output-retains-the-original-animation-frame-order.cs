// HOW-TO: Batch Convert Animated GIFs to WebP While Preserving Frame Order in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!inputPath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".webp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image gif = Image.Load(inputPath))
                {
                    var options = new WebPOptions();
                    gif.Save(outputPath, options);
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
 * 1. When you need to reduce the size of animated GIFs for faster web page loading without losing the animation sequence, you can batch convert them to WebP using C#.
 * 2. When preparing a mobile app’s asset pipeline and want to serve animated images in the more efficient WebP format while keeping the original frame order, this code automates the conversion.
 * 3. When migrating an existing image library from GIF to WebP to improve compression and support modern browsers, you can process all files in a folder with this script.
 * 4. When building a server‑side image processing service that receives GIF uploads and must store them as WebP while preserving animation, the example shows how to handle it in .NET.
 * 5. When creating a CI/CD step that optimizes animated graphics before deployment, you can use this batch conversion to ensure every GIF is turned into a WebP with the correct frame sequence.
 */
