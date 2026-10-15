// HOW-TO: Apply Sepia Tone to EMF Illustration and Save as PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\illustration.emf";
        string outputPath = "output\\sepia.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emf = Image.Load(inputPath))
            {
                int width = emf.Width;
                int height = emf.Height;

                using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(emf, new Rectangle(0, 0, width, height));

                    int[] pixels = canvas.LoadArgb32Pixels(new Rectangle(0, 0, width, height));
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                        int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                        int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                        if (tr > 255) tr = 255;
                        if (tg > 255) tg = 255;
                        if (tb > 255) tb = 255;

                        pixels[i] = (a << 24) | (tr << 16) | (tg << 8) | tb;
                    }

                    canvas.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                    PngOptions pngOptions = new PngOptions();
                    canvas.Save(outputPath, pngOptions);
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
 * 1. When you need to convert vector EMF graphics to raster PNG with a vintage sepia look for web publishing.
 * 2. When generating thumbnails of legacy EMF diagrams for a mobile app and want a consistent sepia color scheme.
 * 3. When preparing print‑ready assets from EMF files and require a sepia filter to match a brand’s retro aesthetic.
 * 4. When automating batch processing of engineering drawings stored as EMF and need to output them as PNG with sepia tone for documentation.
 * 5. When integrating image processing into a C# service that receives EMF uploads and must return a sepia‑styled PNG for preview.
 */
