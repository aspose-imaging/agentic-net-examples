// HOW-TO: Extract All Frames from a WebP Image and Save as BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                WebPImage webpImage = image as WebPImage;
                if (webpImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a WebP image.");
                    return;
                }

                for (int i = 0; i < webpImage.Pages.Length; i++)
                {
                    var page = webpImage.Pages[i];
                    using (RasterImage frame = (RasterImage)page)
                    {
                        string outputPath = Path.Combine(outputDir, $"frame{i}.bmp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        BmpOptions bmpOptions = new BmpOptions();
                        frame.Save(outputPath, bmpOptions);
                    }
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
 * 1. When you need to convert each frame of an animated WebP file into separate BMP files for legacy Windows applications.
 * 2. When extracting individual frames from a WebP sprite sheet to process them separately in a C# image‑processing pipeline.
 * 3. When preparing frame‑by‑frame assets from a WebP animation for use in a game engine that only supports BMP textures.
 * 4. When generating high‑resolution BMP thumbnails from each page of a multi‑page WebP document for printing workflows.
 * 5. When debugging or analyzing the content of a WebP animation by saving each frame as an editable BMP image.
 */
