// HOW-TO: Create PNG Image with Light Gray Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\cleared_image.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.FromArgb(255, 211, 211, 211));
                image.Save();
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
 * 1. When generating placeholder images for a web application, you can create a 200×200 PNG with a light gray background to indicate loading or missing content.
 * 2. When preparing report PDFs that embed charts, you may need a solid‑color PNG canvas as a background layer before drawing the chart graphics.
 * 3. When building a thumbnail generator, you can start with a light gray canvas to ensure consistent background color for images that have transparent areas.
 * 4. When automating UI testing, you might create a blank PNG with a known background color to compare against screenshots for visual regression.
 * 5. When designing email templates, a light gray PNG can serve as a background element for icons or logos that require a uniform backdrop.
 */
