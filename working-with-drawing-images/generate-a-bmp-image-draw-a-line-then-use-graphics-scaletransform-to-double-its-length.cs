// HOW-TO: Create BMP Image and Draw Scaled Line With Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
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
            string outputPath = "output\\generated.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                int[] whitePixels = Enumerable.Repeat(Aspose.Imaging.Color.White.ToArgb(), width * height).ToArray();
                var rect = new Rectangle(0, 0, width, height);
                image.SaveArgb32Pixels(rect, whitePixels);

                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 2);

                graphics.DrawLine(pen, 10, 10, 100, 10);
                graphics.ScaleTransform(2.0f, 1.0f);
                graphics.DrawLine(pen, 10, 30, 100, 30);

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
 * 1. When you need to generate a blank BMP file and programmatically add simple graphics such as lines for a custom report or diagram.
 * 2. When you want to apply a scaling transformation to drawn shapes so that the second line appears twice as long without manually calculating new coordinates.
 * 3. When you are building a C# utility that creates thumbnail‑style images in BMP format for legacy systems that only accept that format.
 * 4. When you need to automate the creation of test images with precise pixel dimensions and colors for image‑processing unit tests.
 * 5. When you are developing a graphics editor that lets users draw and stretch lines on a bitmap canvas using Aspose.Imaging.
 */
