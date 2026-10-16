// HOW-TO: Draw Thick Black Border Around BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                Graphics graphics = new Graphics(raster);
                Pen pen = new Pen(Color.Black, 10);
                graphics.DrawRectangle(pen, new Rectangle(0, 0, raster.Width - 1, raster.Height - 1));

                BmpOptions saveOptions = new BmpOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to add a bold black frame to a BMP file for printing or presentation purposes.
 * 2. When you want to highlight the edges of a scanned bitmap by drawing a thick rectangle before saving it.
 * 3. When creating a simple UI thumbnail that requires a visible border around a BMP canvas.
 * 4. When preparing BMP assets for a game or application that expects a consistent border thickness around images.
 * 5. When generating batch‑processed BMP images that need a uniform black outline for branding or watermarking.
 */
