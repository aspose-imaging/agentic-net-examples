// HOW-TO: Fill Entire PNG Image With Red Color Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, new RectangleF(0, 0, image.Width, image.Height));
                }

                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to replace the background of an existing PNG with a solid red color before further processing.
 * 2. When generating a red placeholder image of the same dimensions as an original file for testing UI layouts.
 * 3. When creating a red overlay for a PNG to highlight areas in a report or presentation.
 * 4. When batch‑processing images to ensure they all have a uniform red background for branding consistency.
 * 5. When converting a PNG to a new file while applying a solid color fill to reset its pixel data.
 */
