// HOW-TO: Verify WebP to GIF Conversion Keeps Original Image Dimensions in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load WebP image
            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                int webpWidth = webpImage.Width;
                int webpHeight = webpImage.Height;

                // Save as GIF
                GifOptions gifOptions = new GifOptions();
                webpImage.Save(outputPath, gifOptions);

                // Load resulting GIF
                using (GifImage gifImage = (GifImage)Image.Load(outputPath))
                {
                    int gifWidth = gifImage.Width;
                    int gifHeight = gifImage.Height;

                    if (webpWidth == gifWidth && webpHeight == gifHeight)
                    {
                        Console.WriteLine($"Dimensions match: Width={webpWidth}, Height={webpHeight}");
                    }
                    else
                    {
                        Console.WriteLine($"Dimensions differ: WebP (Width={webpWidth}, Height={webpHeight}) vs GIF (Width={gifWidth}, Height={gifHeight})");
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
 * 1. When a web application needs to convert user‑uploaded WebP avatars to GIFs while preserving the exact width and height for consistent UI layout.
 * 2. When a batch image processing script must ensure that animated GIFs generated from WebP assets retain the original dimensions to avoid cropping or scaling issues.
 * 3. When validating image assets for an e‑learning platform, developers can compare WebP source sizes with the resulting GIFs to guarantee size consistency across devices.
 * 4. When creating thumbnails from WebP files for email newsletters, the code can confirm that the GIF thumbnails match the source dimensions before embedding.
 * 5. When performing automated quality checks in a CI pipeline, the dimension comparison helps detect unintended resizing during WebP‑to‑GIF conversion.
 */
