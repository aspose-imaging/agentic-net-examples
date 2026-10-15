// HOW-TO: Apply Gaussian Blur to JPEG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                raster.Filter(raster.Bounds, blurOptions);
                var saveOptions = new JpegOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically soften photos before uploading them to a web gallery, applying a Gaussian blur and saving as JPEG simplifies the workflow.
 * 2. When you want to hide sensitive details such as faces or license plates in an image, a Gaussian blur filter in C# can obscure those areas before distribution.
 * 3. When generating preview thumbnails that require a subtle blur effect for aesthetic purposes, this code converts the source to JPEG and applies the blur in one step.
 * 4. When preprocessing images for a machine‑learning pipeline that expects blurred backgrounds, the Gaussian blur operation prepares the JPEG files efficiently.
 * 5. When creating a batch job to convert raw pictures to JPEG while adding an artistic blur, this Aspose.Imaging solution automates the entire process.
 */
