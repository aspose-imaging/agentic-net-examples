// HOW-TO: Batch Convert EMF to PNG with Transparent Background and Timing in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(outputFolder);

            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");
            foreach (string emfPath in emfFiles)
            {
                if (!File.Exists(emfPath))
                {
                    Console.Error.WriteLine($"File not found: {emfPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(emfPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Stopwatch sw = Stopwatch.StartNew();

                using (Image image = Image.Load(emfPath))
                {
                    VectorImage vectorImage = image as VectorImage;
                    if (vectorImage != null)
                    {
                        vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                    }

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.Transparent,
                            PageSize = image.Size
                        }
                    };

                    image.Save(outputPath, pngOptions);
                }

                sw.Stop();
                Console.WriteLine($"Processed {emfPath} in {sw.ElapsedMilliseconds} ms");
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
 * 1. When you need to process a folder of vector EMF drawings and generate PNG thumbnails with a transparent background for web previews.
 * 2. When you want to automatically strip any background color from legacy EMF icons before embedding them in a UI that uses alpha blending.
 * 3. When you have to measure the performance of rasterizing vector graphics to raster images in a batch job for capacity planning.
 * 4. When you are building a migration tool that converts old Windows Metafile assets to modern PNG files while preserving size and transparency.
 * 5. When you need to log the time taken for each conversion to identify slow‑processing files in a large graphics pipeline.
 */
