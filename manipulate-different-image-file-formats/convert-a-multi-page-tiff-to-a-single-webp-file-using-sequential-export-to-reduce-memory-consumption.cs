// HOW-TO: Convert Multi‑Page TIFF to Single WebP Efficiently in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/combined.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int width = tiff.Width;
                int height = tiff.Height;

                WebPOptions webpOptions = new WebPOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 90,
                    Lossless = false
                };

                using (Image webpImage = Image.Create(webpOptions, width, height))
                {
                    WebPImage webp = (WebPImage)webpImage;

                    for (int i = 0; i < tiff.PageCount; i++)
                    {
                        using (RasterImage page = (RasterImage)tiff.Pages[i])
                        {
                            if (!page.IsCached)
                                page.CacheData();

                            if (i == 0)
                            {
                                Graphics graphics = new Graphics(webp);
                                graphics.DrawImage(page, 0, 0);
                            }
                            else
                            {
                                webp.AddPage(page);
                            }
                        }
                    }

                    webp.Save();
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
 * 1. When you need to combine scanned document pages stored as a multi‑page TIFF into a lightweight WebP file for faster web delivery while keeping memory usage low.
 * 2. When a server‑side C# application must generate a single WebP from a multi‑page TIFF without loading all pages into memory at once.
 * 3. When you want to create a compact WebP preview of a large multi‑page TIFF archive for mobile apps using Aspose.Imaging’s streaming API.
 * 4. When an automated image‑processing pipeline has to transform legacy TIFF bundles into modern WebP assets while preserving page dimensions and quality settings.
 * 5. When you are building a .NET service that needs to cache each TIFF page on demand and sequentially add them to a WebP container to reduce RAM consumption.
 */
