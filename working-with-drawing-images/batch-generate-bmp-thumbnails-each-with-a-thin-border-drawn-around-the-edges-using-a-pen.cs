// HOW-TO: Create BMP Thumbnails with Black Border Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(outputDir);

            string[] files = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    int thumbWidth = 100;
                    int thumbHeight = 100;
                    image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    Graphics graphics = new Graphics(image);
                    Pen pen = new Pen(Color.Black, 1);
                    graphics.DrawRectangle(pen, 0, 0, image.Width - 1, image.Height - 1);

                    BmpOptions options = new BmpOptions();
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to generate small preview BMP images for a file‑explorer grid view.
 * 2. When you want to add a consistent thin black border around each thumbnail to improve visual separation in a gallery.
 * 3. When you have to process an entire folder of legacy BMP assets automatically and store the resized versions in a separate output directory.
 * 4. When you are building a .NET desktop application that must display fast‑loading BMP previews without altering the original files.
 * 5. When you require a simple batch script to resize BMP images to a fixed size and save them with a naming convention for further processing.
 */
