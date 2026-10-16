// HOW-TO: Apply Median Filter to PNG and Overwrite Original in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/image.png";
            string outputPath = "templates/image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(image.Bounds, filterOptions);

                var options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to reduce noise in template PNG assets before generating final graphics while keeping the original file name.
 * 2. When an automated build process must apply a median filter to UI icons stored in a templates directory and save the cleaned images back in place.
 * 3. When a web application dynamically preprocesses uploaded PNG images by smoothing them and overwriting the source file to save storage space.
 * 4. When a batch script processes a collection of PNG templates, applying a 3‑pixel median filter using Aspose.Imaging in C# without creating duplicate files.
 * 5. When you want to ensure consistent image quality across all PNG resources by filtering and saving them directly to their original location in a .NET project.
 */
