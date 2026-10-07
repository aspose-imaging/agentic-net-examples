// HOW-TO: Convert Animated WebP to APNG with Inverted Colors in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.webp";
            string outputPath = "Output\\output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                foreach (RasterImage page in webp.Pages)
                {
                    var rect = page.Bounds;
                    int[] pixels = page.LoadArgb32Pixels(rect);
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;
                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;
                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }
                    page.SaveArgb32Pixels(rect, pixels);
                }

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, webp.Width, webp.Height))
                {
                    apng.RemoveAllFrames();
                    foreach (RasterImage page in webp.Pages)
                    {
                        apng.AddFrame(page);
                    }
                    apng.Save();
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
 * 1. When you need to recolor an animated WebP for a dark‑mode UI and deliver it as an APNG to browsers that only support PNG animation.
 * 2. When a game developer wants to apply a negative filter to each frame of a WebP sprite sheet and export the result as an APNG for use in Unity.
 * 3. When a marketing team requires batch conversion of promotional animated WebP assets to APNG with a custom color palette for email newsletters.
 * 4. When an e‑learning platform must transform user‑uploaded animated WebP diagrams into APNGs with inverted colors to improve contrast on projectors.
 * 5. When a mobile app needs to preprocess animated WebP icons by swapping their colors and saving them as APNGs to reduce runtime processing.
 */
