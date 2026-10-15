// HOW-TO: Apply Median Filter to JPEG and Save with Quality in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var rect = new Aspose.Imaging.Rectangle(0, 0, image.Width, image.Height);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(rect, filterOptions);

                var source = new FileCreateSource(outputPath, false);
                var jpegOptions = new JpegOptions { Source = source, Quality = 90 };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce noise in a large JPEG photo before archiving it, you can apply a median filter and save the result with a specific quality setting using Aspose.Imaging in C#.
 * 2. When processing user‑uploaded images in a web service, lazy‑loading the file and applying a median filter only when required helps conserve memory and improve response time.
 * 3. When converting high‑resolution scans to compressed JPEGs while preserving edge details, you can filter the entire image area and set the JPEG quality to balance size and visual fidelity.
 * 4. When building a batch‑processing tool that applies the same noise‑reduction filter to many pictures, the code demonstrates how to automate loading, filtering, and saving each file programmatically.
 * 5. When integrating image cleanup into a desktop application that edits photos, the example shows how to use Aspose.Imaging’s Rectangle and FilterOptions classes to target the whole image and output a JPEG with controlled compression.
 */
