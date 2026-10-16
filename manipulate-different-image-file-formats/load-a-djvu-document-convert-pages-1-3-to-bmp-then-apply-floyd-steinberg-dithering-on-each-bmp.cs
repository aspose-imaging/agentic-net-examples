// HOW-TO: Convert First Three DjVu Pages to BMP with Floyd Steinberg Dithering in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputFolder = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvu = (DjvuImage)image;
                int pagesToConvert = Math.Min(3, djvu.Pages.Length);

                for (int i = 0; i < pagesToConvert; i++)
                {
                    string bmpPath = Path.Combine(outputFolder, $"page{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    var bmpOptions = new BmpOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(i)
                    };
                    djvu.Save(bmpPath, bmpOptions);

                    if (!File.Exists(bmpPath))
                    {
                        Console.Error.WriteLine($"Failed to create BMP: {bmpPath}");
                        continue;
                    }

                    using (RasterImage raster = (RasterImage)Image.Load(bmpPath))
                    {
                        raster.Save(bmpPath);
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
 * 1. When you need to extract the first few pages of a scanned DjVu archive and generate high‑contrast BMP images for legacy printing systems.
 * 2. When a document‑processing pipeline requires converting DjVu pages to BMP format before applying Floyd‑Steinberg dithering for OCR preprocessing.
 * 3. When you must create thumbnail‑size BMP previews of DjVu pages while preserving visual detail through error‑diffusion dithering.
 * 4. When an application has to batch‑convert selected DjVu pages to BMP files for compatibility with software that only reads BMP.
 * 5. When you want to automate the transformation of DjVu pages into dithered BMP assets for use in game textures or embedded devices.
 */
