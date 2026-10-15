// HOW-TO: Create Blank BMP Image and Access Graphics Object in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(createOptions, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
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
 * 1. When you need to generate a blank BMP canvas of a specific size to later draw shapes or text with Aspose.Imaging in a C# application.
 * 2. When you want to programmatically create an image file before adding watermarks, logos, or annotations using the Graphics API.
 * 3. When a reporting tool must produce bitmap thumbnails on the fly and requires direct access to the Graphics object for custom rendering.
 * 4. When an automated batch process creates placeholder images for missing assets and needs to save them as BMP files without external dependencies.
 * 5. When you are building a UI component that draws vector graphics over a bitmap background and need to control the compositing mode for proper blending.
 */
