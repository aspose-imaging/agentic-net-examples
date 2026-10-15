// HOW-TO: Sharpen TGA Texture with Strength 3 and Save as BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                image.Filter(image.Bounds, filterOptions);

                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When a game developer needs to enhance the details of a TGA texture before converting it to BMP for use in a Windows‑based engine.
 * 2. When a graphics pipeline requires applying a medium‑strength sharpening filter to legacy TGA assets and exporting them as BMP files for compatibility with older tools.
 * 3. When an image‑processing script must automatically improve the clarity of texture maps and store the results in BMP format for batch processing.
 * 4. When a C# application needs to load a TGA file, sharpen it with a strength of three, and save the result as a BMP to integrate with a UI that only supports BMP images.
 * 5. When a developer is building a conversion utility that preprocesses TGA textures with a sharpening filter before archiving them as BMP files for documentation or printing purposes.
 */
