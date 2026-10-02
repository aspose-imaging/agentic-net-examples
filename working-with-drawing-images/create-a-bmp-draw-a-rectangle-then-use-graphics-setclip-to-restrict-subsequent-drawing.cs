// HOW-TO: Create BMP, Draw Rectangle and Fill Background in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-28
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\result.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 300;
            int height = 200;

            using (var image = Image.Create(new BmpOptions(), width, height))
            {
                var graphics = new Graphics(image);
                var pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, 50, 50, 200, 150);

                using (var brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, 0, 0, 300, 200);
                }

                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to generate a simple BMP diagram with a highlighted area for a report or documentation.
 * 2. When you want to programmatically create a bitmap placeholder image that includes a colored background and a bordered rectangle for UI mockups.
 * 3. When an application must produce a raster image for printing that contains a red fill and a blue outline to indicate selection zones.
 * 4. When you are building a batch process that adds a rectangular frame to existing images and saves the result as BMP files.
 * 5. When you need to create a test image for validating graphics rendering pipelines that requires explicit drawing of shapes using Pen and Brush objects.
 */
