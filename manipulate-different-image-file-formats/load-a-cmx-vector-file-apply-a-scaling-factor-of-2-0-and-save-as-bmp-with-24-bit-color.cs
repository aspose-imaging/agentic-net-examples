// HOW-TO: Scale CMX Vector Image by 2x and Save as 24‑Bit BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int newWidth = cmx.Width * 2;
                int newHeight = cmx.Height * 2;
                cmx.Resize(newWidth, newHeight);

                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                cmx.Save(outputPath, bmpOptions);
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
 * 1. When you need to double the size of a CorelDRAW CMX drawing for high‑resolution printing and output it as a standard 24‑bit BMP file.
 * 2. When a legacy Windows application only accepts BMP images, you can convert CMX vectors to BMP while scaling them to match the required pixel dimensions.
 * 3. When preparing assets for a game engine that requires raster BMP textures, you can upscale CMX artwork to avoid pixelation and preserve color depth.
 * 4. When automating a batch process that ingests CMX files and generates larger BMP previews for a web gallery, this code handles the resize and format conversion.
 * 5. When integrating Aspose.Imaging into a C# service that receives CMX diagrams and must deliver 24‑bit BMP files at double resolution for downstream OCR analysis.
 */
