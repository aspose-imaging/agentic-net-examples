// HOW-TO: Create BMP with Rotated Rectangle Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 100, 50));

                graphics.RotateTransform(45f);

                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawRectangle(pen2, new Rectangle(20, 20, 100, 50));

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
 * 1. When you need to generate a BMP file with a rotated shape for a custom diagram or UI element in a C# application.
 * 2. When creating sample images to test rotation algorithms or graphics pipelines that require precise control over drawing order.
 * 3. When producing annotated screenshots where a rotated rectangle highlights a region of interest in a Windows desktop tool.
 * 4. When building a batch process that adds rotated overlays to BMP assets for game sprites or map tiles.
 * 5. When demonstrating Aspose.Imaging’s Graphics.RotateTransform feature in tutorials or documentation for C# developers.
 */
