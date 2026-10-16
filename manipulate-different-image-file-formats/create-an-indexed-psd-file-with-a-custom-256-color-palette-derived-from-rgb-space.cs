// HOW-TO: Create Indexed PSD With Custom 256‑Color RGB Palette In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output\\indexed_palette.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Color[] colors = new Color[256];
            int index = 0;
            for (int r = 0; r < 6; r++)
            {
                for (int g = 0; g < 6; g++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (index < 256)
                        {
                            colors[index++] = Color.FromArgb(255,
                                (r * 255) / 5,
                                (g * 255) / 5,
                                (b * 255) / 5);
                        }
                    }
                }
            }
            while (index < 256)
            {
                colors[index++] = Color.FromArgb(255, 0, 0, 0);
            }

            var palette = new ColorPalette(colors);

            var psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                Palette = palette
            };

            int width = 256;
            int height = 256;

            using (var image = Image.Create(psdOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                image.Save();
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
 * 1. When you need to generate a Photoshop PSD file that uses an indexed color mode with a specific 256‑color palette for web‑friendly graphics or legacy workflows.
 * 2. When a game developer must export level maps as indexed PSDs to reduce file size while preserving a predefined RGB color set.
 * 3. When an e‑learning platform creates slide thumbnails in PSD format and wants consistent branding colors across all images.
 * 4. When a printing service prepares pre‑flight files that require an indexed palette to match spot‑color specifications before rasterization.
 * 5. When a batch‑processing tool converts large batches of images to PSD with a custom palette to ensure uniform color mapping for downstream automation.
 */
