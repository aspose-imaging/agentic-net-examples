// HOW-TO: Create a Teal BMP with Centered White Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            int width = 400;
            int height = 300;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Teal);

                int ellipseWidth = width / 2;
                int ellipseHeight = height / 2;
                int x = (width - ellipseWidth) / 2;
                int y = (height - ellipseHeight) / 2;

                Pen pen = new Pen(Color.White, 3);
                graphics.DrawEllipse(pen, x, y, ellipseWidth, ellipseHeight);

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
 * 1. When you need to generate a simple placeholder image for a UI component, such as a button background, in BMP format with a teal fill and a white ellipse.
 * 2. When creating test assets for image‑processing pipelines that require a known color background and a geometric shape to verify detection algorithms.
 * 3. When producing a BMP badge or icon for a Windows desktop application where a teal canvas and a centered white ellipse represent a status symbol.
 * 4. When automating the creation of graphics for documentation or reports that need a consistent teal background with a highlighted white ellipse.
 * 5. When building a batch process that generates multiple BMP files with the same teal background and centered ellipse for use in game sprites or tile sets.
 */
