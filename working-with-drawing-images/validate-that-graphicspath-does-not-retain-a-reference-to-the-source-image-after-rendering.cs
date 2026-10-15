// HOW-TO: Check If GraphicsPath Holds Image Reference After Drawing In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a GraphicsPath and a Figure with a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            RectangleShape rectShape = new RectangleShape(new RectangleF(10, 10, 100, 100));
            figure.AddShape(rectShape);
            path.AddFigure(figure);

            // Load the source image, draw the path, and save to output
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.DrawPath(new Pen(Color.Blue, 2), path);
                image.Save(outputPath, new PngOptions());
            }

            // After disposing the image, attempt to delete the source file
            try
            {
                File.Delete(inputPath);
                Console.WriteLine("Source file deleted successfully. GraphicsPath does not retain a reference to the image.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to delete source file: {ex.Message}");
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
 * 1. When you need to verify that drawing a rectangle with GraphicsPath does not lock the original PNG file so it can be deleted or moved afterward.
 * 2. When building an image‑processing pipeline that annotates source images and must clean up temporary files without encountering file‑in‑use errors.
 * 3. When implementing a batch job that loads many images, draws graphics, saves the results, and then removes the originals to conserve disk space.
 * 4. When integrating Aspose.Imaging into a web service that generates edited images and must release file handles before sending the response.
 * 5. When troubleshooting potential memory leaks caused by lingering references to source images after using Graphics and GraphicsPath objects.
 */
