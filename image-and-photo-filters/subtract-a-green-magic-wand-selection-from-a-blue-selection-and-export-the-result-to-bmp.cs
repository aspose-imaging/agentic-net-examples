// HOW-TO: Subtract Green Selection from Blue Region and Save as BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Select blue region (example point 10,10) and subtract green region (example point 20,20)
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Subtract(new MagicWandSettings(20, 20))
                    .Apply();

                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to remove a green object from a blue background in a PNG and export the cleaned image as a BMP for legacy Windows applications.
 * 2. When creating a mask that excludes a specific color region (green) from another selected area (blue) before saving the result in a format that preserves uncompressed pixel data.
 * 3. When automating batch processing to isolate and delete green highlights from scanned diagrams that are primarily blue, then storing the final files as BMP for further analysis.
 * 4. When integrating Aspose.Imaging into a C# tool that extracts a blue region, subtracts overlapping green elements, and outputs the composition as a BMP for use in GIS or CAD workflows.
 * 5. When developing a graphics pipeline that requires precise color‑based selection subtraction using the Magic Wand tool and needs the resulting image in BMP format for compatibility with older imaging libraries.
 */
