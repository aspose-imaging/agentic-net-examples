// HOW-TO: Parallel Batch Convert WebP Images to GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            Directory.CreateDirectory(outputDirectory);

            var webpFiles = Directory.GetFiles(inputDirectory, "*.webp", SearchOption.AllDirectories);

            Parallel.ForEach(webpFiles, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(relativePath, ".gif"));

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    using (WebPImage image = (WebPImage)Image.Load(inputPath))
                    {
                        image.Save(outputPath, new GifOptions());
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly convert a large collection of WebP photos to animated GIFs for web galleries using all CPU cores.
 * 2. When a server‑side service must process user‑uploaded WebP files and output GIFs without blocking other requests.
 * 3. When migrating legacy assets from WebP to GIF format for compatibility with older browsers or email clients.
 * 4. When generating GIF previews of WebP screenshots in a CI pipeline that runs on multi‑core build agents.
 * 5. When building a desktop utility that reorganizes image folders while converting WebP files to GIFs in parallel to reduce processing time.
 */
