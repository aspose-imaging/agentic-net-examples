// HOW-TO: Convert Animated GIF to WebP While Preserving Frame Order in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.gif";
            string outputPath = "Output\\sample.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
            {
                GifImage gif = (GifImage)img;
                GifFrameBlock firstBlock = gif.Blocks.OfType<GifFrameBlock>().FirstOrDefault();
                if (firstBlock == null)
                {
                    Console.Error.WriteLine("No frames found in GIF.");
                    return;
                }

                gif.ActiveFrame = firstBlock;
                Aspose.Imaging.RasterImage firstRaster = (Aspose.Imaging.RasterImage)gif.ActiveFrame;
                int width = firstRaster.Width;
                int height = firstRaster.Height;

                WebPOptions createOptions = new WebPOptions();
                using (WebPImage webp = (WebPImage)Aspose.Imaging.Image.Create(createOptions, width, height))
                {
                    foreach (GifFrameBlock frameBlock in gif.Blocks.OfType<GifFrameBlock>())
                    {
                        gif.ActiveFrame = frameBlock;
                        Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)gif.ActiveFrame;
                        WebPFrameBlock webpBlock = new WebPFrameBlock(raster);
                        webp.AddBlock(webpBlock);
                    }

                    WebPOptions saveOptions = new WebPOptions();
                    webp.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the file size of animated GIFs for web delivery while keeping the original animation sequence intact.
 * 2. When migrating legacy GIF assets to the modern WebP format in a .NET application to achieve faster page loads.
 * 3. When building an image‑processing pipeline that automatically converts user‑uploaded GIFs to WebP for storage efficiency.
 * 4. When creating a batch script to convert a library of GIF animations to WebP without losing frame order for mobile apps.
 * 5. When optimizing email newsletters by replacing animated GIFs with WebP equivalents while preserving the original animation timing.
 */
