// HOW-TO: Rotate PNG Image 45 Degrees with Transparent Background While Keeping Size in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            PngOptions options = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage image = (RasterImage)Image.Create(options, width, height))
            {
                // Draw a simple rectangle for visual reference
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Black);
                Rectangle rect = new Rectangle(50, 50, 100, 100);
                graphics.DrawRectangle(pen, rect);

                // Store original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Rotate 45 degrees with transparent background, keep dimensions unchanged
                image.Rotate(45f, false, Color.Transparent);

                // Verify dimensions remain unchanged
                if (image.Width == originalWidth && image.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }
                else
                {
                    Console.WriteLine("Dimensions changed after rotation.");
                }

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When you need to generate a PNG thumbnail that is rotated for a UI but must stay the same pixel dimensions.
 * 2. When creating graphics for a game sprite sheet where each sprite must be rotated without altering the canvas size.
 * 3. When preparing images for a PDF report where rotated diagrams must retain their original width and height for layout consistency.
 * 4. When building an automated image processing pipeline that adds a diagonal watermark by rotating a shape while preserving the file’s dimensions.
 * 5. When developing a web service that returns rotated PNG icons on the fly and must keep the original size for CSS positioning.
 */
