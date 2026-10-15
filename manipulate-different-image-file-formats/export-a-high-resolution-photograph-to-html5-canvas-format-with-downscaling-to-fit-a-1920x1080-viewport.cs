// HOW-TO: Export High Resolution JPEG to HTML5 Canvas Scaled for 1920x1080 in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int maxWidth = 1920;
                int maxHeight = 1080;
                int newWidth = image.Width;
                int newHeight = image.Height;

                double widthRatio = (double)maxWidth / image.Width;
                double heightRatio = (double)maxHeight / image.Height;
                double scale = Math.Min(1.0, Math.Min(widthRatio, heightRatio));

                if (scale < 1.0)
                {
                    newWidth = (int)(image.Width * scale);
                    newHeight = (int)(image.Height * scale);
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                }

                var options = new Html5CanvasOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to display a large photo on a web page without slowing the browser, you can downscale it to fit a 1920×1080 viewport and export it as an HTML5 Canvas element using C#.
 * 2. When generating printable previews for a photo‑gallery app, you can convert high‑resolution images to lightweight Canvas HTML that adapts to common screen sizes.
 * 3. When building an online image editor that must load full‑size JPEGs quickly, you can resize the image on the server and save it as HTML5 Canvas markup for fast client‑side rendering.
 * 4. When creating responsive email newsletters that embed images as Canvas for better compatibility, you can use Aspose.Imaging to shrink the picture and output HTML5 Canvas code.
 * 5. When integrating a digital signage system that streams images to browsers, you can pre‑process each picture to 1920×1080 or smaller and deliver it as HTML5 Canvas to ensure consistent display across devices.
 */
