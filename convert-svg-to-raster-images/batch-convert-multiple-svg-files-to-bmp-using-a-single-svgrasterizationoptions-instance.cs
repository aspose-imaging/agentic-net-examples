// HOW-TO: Batch Convert Multiple SVG Files to BMP Using One Rasterization Options in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "input_svgs";
            string outputDirectory = "output_bmps";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Single SvgRasterizationOptions instance for all conversions
            var rasterOptions = new SvgRasterizationOptions();

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a web application needs to generate thumbnail BMP images from a large collection of SVG icons for legacy Windows software.
 * 2. When an automated build pipeline must convert design assets stored as SVG into BMP format for inclusion in a game engine that only supports bitmap textures.
 * 3. When a reporting tool has to batch‑process vector diagrams into BMP files to embed them in PDF reports that require raster images.
 * 4. When a migration script moves SVG logos to a legacy database that stores images as BMP, requiring efficient conversion with a single rasterization settings object.
 * 5. When a desktop utility needs to quickly rasterize multiple SVG charts into BMP files for printing on devices that do not support vector formats.
 */
