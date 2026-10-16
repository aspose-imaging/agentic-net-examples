// HOW-TO: How to Create and Save a BMP with Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 100;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 60));

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
 * 1. When you need to generate a simple BMP file with a blue rectangle for a report or UI preview without leaving unmanaged resources hanging.
 * 2. When you want to programmatically draw shapes on an image in C# and ensure the Graphics and Image objects are properly disposed to avoid memory leaks.
 * 3. When you are building a batch process that creates BMP assets for a game or application and must manage file streams efficiently.
 * 4. When you need to produce a white‑background BMP with custom dimensions and a bordered rectangle for automated testing of image processing pipelines.
 * 5. When you are integrating Aspose.Imaging into a .NET service that creates temporary images and must guarantee cleanup of graphics resources after saving.
 */
