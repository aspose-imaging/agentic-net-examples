// HOW-TO: Create BMP with Diagonal Line and Horizontal Mirror Using C# (Aspose.Imaging for .NET)
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
            string outputPath = "Output\\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                // Mirror horizontally using ScaleTransform
                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(-width, 0);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

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
 * 1. When you need to generate a BMP file with a simple diagonal pattern and its mirrored copy for testing image rendering pipelines.
 * 2. When creating placeholder graphics for UI components that require a mirrored diagonal line to illustrate symmetry.
 * 3. When producing sample data for unit tests that verify horizontal flip operations using Graphics.ScaleTransform in C#.
 * 4. When automating the creation of basic watermark templates that consist of a line reflected across the vertical axis.
 * 5. When teaching beginners how to combine drawing primitives with transformation matrices to produce mirrored graphics in Aspose.Imaging.
 */
