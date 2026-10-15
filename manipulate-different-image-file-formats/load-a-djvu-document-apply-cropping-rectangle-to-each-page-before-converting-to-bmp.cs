// HOW-TO: Crop DjVu Pages and Convert to BMP Images in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputDir = "output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Aspose.Imaging.Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    var page = (DjvuPage)djvu.Pages[i];
                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)page.GetBackgroundImage())
                    {
                        Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(10, 10, 200, 200);
                        raster.Crop(cropRect);

                        string outputPath = Path.Combine(outputDir, $"page_{i}.bmp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        raster.Save(outputPath, new BmpOptions());
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
 * 1. When you need to extract a specific region from each page of a multi‑page DjVu document and save it as a BMP for further processing.
 * 2. When you are building a .NET application that converts scanned DjVu files into bitmap thumbnails with a predefined crop area.
 * 3. When you must preprocess DjVu pages by removing margins before feeding the images into an OCR engine that only accepts BMP format.
 * 4. When you want to automate batch conversion of DjVu archives into BMP files while keeping only the central portion of each page.
 * 5. When you are integrating legacy Windows software that requires BMP input, and you need to supply cropped images extracted from DjVu source files.
 */
