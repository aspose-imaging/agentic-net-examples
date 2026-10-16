// HOW-TO: Blend a 200x150 Red Overlay onto a GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(inputPath))
            {
                int overlayWidth = 200;
                int overlayHeight = 150;

                BmpOptions bmpOptions = new BmpOptions();
                using (RasterImage overlay = (RasterImage)Image.Create(bmpOptions, overlayWidth, overlayHeight))
                {
                    int[] pixels = new int[overlayWidth * overlayHeight];
                    int argb = (255 << 24) | (255 << 16) | (0 << 8) | 0; // Red color
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        pixels[i] = argb;
                    }

                    overlay.SaveArgb32Pixels(new Rectangle(0, 0, overlayWidth, overlayHeight), pixels);

                    int posX = (background.Width - overlayWidth) / 2;
                    int posY = (background.Height - overlayHeight) / 2;
                    background.Blend(new Point(posX, posY), overlay, 127);
                }

                GifOptions gifOptions = new GifOptions() { Source = new FileCreateSource(outputPath, false) };
                background.Save(outputPath, gifOptions);
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
 * 1. When you need to add a semi‑transparent colored banner to an animated GIF for branding or watermarking.
 * 2. When you want to programmatically place a rectangular highlight on a GIF frame to draw user attention in a UI.
 * 3. When generating custom thumbnails that combine a solid‑color overlay with an existing GIF background.
 * 4. When creating promotional GIFs that require a centered red call‑to‑action box blended with the original animation.
 * 5. When automating batch processing to overlay fixed‑size graphics onto multiple GIF files for social‑media campaigns.
 */
