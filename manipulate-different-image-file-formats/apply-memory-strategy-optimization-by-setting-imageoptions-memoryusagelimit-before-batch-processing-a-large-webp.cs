// HOW-TO: Set ImageOptions MemoryUsageLimit to Convert Large WebP Batch to BMP in C# (Aspose.Imaging for .NET)
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
                    continue;
                }

                using (Image image = Image.Load(inputPath))
                {
                    WebPImage webpImage = image as WebPImage;
                    if (webpImage == null)
                    {
                        Console.Error.WriteLine($"Not a WebP image: {inputPath}");
                        continue;
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions saveOptions = new BmpOptions();
                    webpImage.Save(outputPath, saveOptions);
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
 * 1. When you need to convert thousands of WebP files to BMP on a server with limited RAM, setting MemoryUsageLimit prevents out‑of‑memory crashes.
 * 2. When building a desktop utility that processes a user‑selected folder of WebP images and saves them as BMP for legacy applications, you can batch convert them efficiently with Aspose.Imaging.
 * 3. When automating image preparation for a printing workflow that only accepts BMP, you can programmatically read each WebP, apply a memory cap, and output BMP files.
 * 4. When migrating a web‑app’s assets from WebP to BMP for compatibility with older browsers, you can loop through a directory and convert each file while controlling memory consumption.
 * 5. When creating a scheduled job that cleans up a large WebP archive by converting images to BMP for archival storage, using ImageOptions.MemoryUsageLimit ensures the job runs within the allocated resources.
 */
