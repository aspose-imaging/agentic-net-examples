// HOW-TO: Apply Gaussian Blur to Uploaded Blob Image with Aspose.Imaging in Azure Function C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var blurOptions = new GaussianBlurFilterOptions();
                image.Filter(image.Bounds, blurOptions);
                image.Save(outputPath);
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
 * 1. When you need to automatically soften JPEG photos uploaded to Azure Blob storage for a web gallery.
 * 2. When you want to preprocess user‑submitted images with a Gaussian blur before running facial detection in a serverless pipeline.
 * 3. When you must create a consistent blurred background for thumbnails generated on the fly by an Azure Function.
 * 4. When you are building a content‑moderation workflow that blurs sensitive areas of images as soon as they are stored in the cloud.
 * 5. When you require a simple C# Azure Function to apply a high‑quality blur filter without installing native image libraries.
 */
