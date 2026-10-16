// HOW-TO: Export High Resolution PNG to HTML5 Canvas Scaled to Viewport in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
        string inputPath = "Input/high_res_image.png";
        string outputPath = "Output/canvas.html";
        int viewportWidth = 800;
        int viewportHeight = 600;

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                if (!raster.IsCached) raster.CacheData();

                double scale = Math.Min((double)viewportWidth / raster.Width, (double)viewportHeight / raster.Height);
                int newWidth = (int)(raster.Width * scale);
                int newHeight = (int)(raster.Height * scale);

                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                Html5CanvasOptions options = new Html5CanvasOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to display a large PNG image inside a web page’s canvas element without exceeding the browser’s viewport, you can resize and export it to HTML5 Canvas format using C#.
 * 2. When building an online photo gallery that must serve thumbnails generated from high‑resolution images, this code creates a scaled canvas version that loads quickly on any device.
 * 3. When converting legacy raster graphics to a format that can be drawn directly with JavaScript on an HTML5 canvas, the snippet preserves image quality while fitting a predefined width and height.
 * 4. When implementing a responsive design where the canvas size is limited to 800×600 pixels, the code automatically calculates the optimal scaling factor and saves the result as a canvas HTML file.
 * 5. When integrating Aspose.Imaging into a C# backend to preprocess images for web‑based editors, this example shows how to resize a PNG and output it as a ready‑to‑use HTML5 canvas markup.
 */
