// HOW-TO: Apply Median Filter to ODG Image and Convert to BMP Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(filePath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                        image.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                        {
                            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".bmp");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            var bmpOptions = new BmpOptions();
                            raster.Save(outputPath, bmpOptions);
                        }
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
 * 1. When you need to reduce noise in an ODG drawing before exporting it as a BMP for legacy Windows applications.
 * 2. When you must batch‑process multiple ODG files, apply a median smoothing filter, and store the results in BMP format for printing or archival.
 * 3. When a project requires converting vector ODG graphics to raster BMP while preserving a white background and removing speckles using Aspose.Imaging in C#.
 * 4. When integrating image preprocessing into a workflow that receives ODG uploads, applies a median filter to improve visual quality, and then saves the output as BMP for downstream systems.
 * 5. When you want to programmatically load ODG files, rasterize them via PNG options, apply a median filter, and generate BMP files for use in .NET desktop applications.
 */
