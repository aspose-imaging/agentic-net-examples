// HOW-TO: Rotate PNG 30 Degrees and Save as GIF Using MemoryStream in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage rasterImage)
                {
                    // Rotate 30 degrees, resize proportionally, fill background with black
                    rasterImage.Rotate(30f, true, Color.Black);

                    using (var memoryStream = new MemoryStream())
                    {
                        var gifOptions = new GifOptions();
                        rasterImage.Save(memoryStream, gifOptions);
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
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
 * 1. When you need to generate a rotated GIF thumbnail from a PNG for web display without writing intermediate files.
 * 2. When you must rotate an image by a specific angle and preserve a solid background color for animated GIF creation.
 * 3. When you want to process images in memory to avoid disk I/O before saving the result as a GIF in a .NET application.
 * 4. When you are converting raster images to GIF format after applying transformations such as rotation and background fill.
 * 5. When you need to ensure the output GIF fits a specific orientation and background for email newsletters or social media posts.
 */
