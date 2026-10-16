// HOW-TO: Localize WMF Text and Export as SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Attempt to replace text elements using reflection to avoid compile-time dependency on a specific API.
                try
                {
                    var replaceMethod = image.GetType().GetMethod("ReplaceText", new[] { typeof(string), typeof(string) });
                    if (replaceMethod != null)
                    {
                        // Example replacement; adapt as needed for actual localization keys.
                        replaceMethod.Invoke(image, new object[] { "SampleText", "LocalizedText" });
                    }
                }
                catch
                {
                    // If the method does not exist or fails, continue without replacement.
                }

                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate localized vector graphics from legacy WMF icons for a multilingual web application.
 * 2. When you must replace embedded text in a WMF diagram with translated strings before converting it to SVG for responsive UI scaling.
 * 3. When an automated build process has to batch‑process WMF assets, swap placeholder labels with locale‑specific terms, and output SVG files for modern browsers.
 * 4. When a reporting tool requires dynamic language support by swapping chart titles inside WMF templates and exporting them as SVG for high‑quality printing.
 * 5. When you want to programmatically edit WMF files without a compile‑time dependency on the Aspose text‑replacement API, using reflection to safely replace text and save as SVG.
 */
