// HOW-TO: Create Animated WebP From Multiple BMP Images In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string frame1 = "frame1.bmp";
            string frame2 = "frame2.bmp";
            string frame3 = "frame3.bmp";
            string outputPath = "output\\animated.webp";

            if (!File.Exists(frame1))
            {
                Console.Error.WriteLine($"File not found: {frame1}");
                return;
            }
            if (!File.Exists(frame2))
            {
                Console.Error.WriteLine($"File not found: {frame2}");
                return;
            }
            if (!File.Exists(frame3))
            {
                Console.Error.WriteLine($"File not found: {frame3}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage firstFrame = (RasterImage)Image.Load(frame1))
            {
                using (WebPImage webp = new WebPImage(firstFrame))
                {
                    webp.Options.AnimLoopCount = 0;
                    webp.Options.Lossless = false;
                    webp.Options.Quality = 80;

                    using (RasterImage secondFrame = (RasterImage)Image.Load(frame2))
                    {
                        webp.AddPage(secondFrame);
                    }

                    using (RasterImage thirdFrame = (RasterImage)Image.Load(frame3))
                    {
                        webp.AddPage(thirdFrame);
                    }

                    webp.Save(outputPath);
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
 * 1. When you need to convert a series of BMP screenshots into a single animated WebP file for lightweight web delivery.
 * 2. When you want to generate an animated WebP banner from BMP assets while controlling loop count and quality using Aspose.Imaging in a C# application.
 * 3. When a game developer must package multiple BMP sprite frames into an animated WebP texture to reduce file size on mobile devices.
 * 4. When an e‑learning platform creates step‑by‑step tutorial animations by stitching BMP diagrams into an animated WebP with Aspose.Imaging.
 * 5. When a reporting tool assembles BMP chart images into an animated WebP slideshow for embedding in HTML emails.
 */
