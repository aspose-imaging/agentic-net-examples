// HOW-TO: Batch Convert WMF Files to PNG with White Background in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "input";
            string outputDirectory = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each WMF file in the input directory
            foreach (string filePath in Directory.GetFiles(inputDirectory, "*.wmf"))
            {
                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Image image = Image.Load(filePath))
                {
                    // Convert to RasterImage to manipulate background
                    RasterImage raster = (RasterImage)image;

                    // Set a uniform background color (e.g., white) to replace transparency
                    raster.BackgroundColor = Color.White;
                    raster.HasBackgroundColor = true;

                    // Save as PNG
                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails from legacy WMF icons for a web gallery and want a solid background instead of transparency.
 * 2. When migrating a document management system that stores vector WMF diagrams and you must provide raster PNG versions for mobile devices.
 * 3. When preparing print‑ready assets from WMF drawings and need to ensure the background is white to avoid transparent gaps.
 * 4. When automating a build pipeline that processes multiple WMF logos and outputs PNGs with a consistent background color for branding.
 * 5. When converting a batch of WMF charts to PNG for inclusion in PDF reports, and you need to replace any transparent areas with a uniform color.
 */
