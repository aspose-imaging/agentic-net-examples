// HOW-TO: Extract WebP Animation Frames to BMP and Create GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputWebP = "input.webp";
            string bmpFolder = "bmp_frames";
            string outputGif = "output.gif";

            if (!File.Exists(inputWebP))
            {
                Console.Error.WriteLine($"File not found: {inputWebP}");
                return;
            }

            Directory.CreateDirectory(bmpFolder);

            List<Image> bmpImages = new List<Image>();

            using (WebPImage webp = (WebPImage)Image.Load(inputWebP))
            {
                int frameCount = webp.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    RasterImage frame = (RasterImage)webp.Pages[i];
                    string bmpPath = Path.Combine(bmpFolder, $"frame{i}.bmp");
                    frame.Save(bmpPath, new BmpOptions());
                    Image bmpImg = Image.Load(bmpPath);
                    bmpImages.Add(bmpImg);
                }
            }

            if (bmpImages.Count > 0)
            {
                string outputDir = Path.GetDirectoryName(outputGif);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Image gifImage = Image.Create(bmpImages.ToArray(), true))
                {
                    GifOptions gifOptions = new GifOptions();
                    gifImage.Save(outputGif, gifOptions);
                }
            }

            foreach (var img in bmpImages)
            {
                img.Dispose();
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
 * 1. When you need to convert an animated WebP file into a GIF for browsers that only support GIF animations.
 * 2. When you want to extract each frame of a WebP animation as separate BMP images for editing in Windows‑based graphics tools.
 * 3. When you must generate a GIF slideshow from BMP frames extracted from a WebP animation to embed in presentations or email newsletters.
 * 4. When you are building a server‑side service that receives WebP animations and outputs GIFs for legacy mobile devices using Aspose.Imaging for .NET.
 * 5. When you need to archive the individual frames of a WebP animation in lossless BMP format before applying custom watermarking or frame‑by‑frame analysis.
 */
