// HOW-TO: Create Multiple BMP Images with Centered Colored Square in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define size specifications (width, height)
            List<(int width, int height)> sizes = new List<(int, int)>
            {
                (200, 300),
                (400, 400),
                (500, 250)
            };

            for (int i = 0; i < sizes.Count; i++)
            {
                int width = sizes[i].width;
                int height = sizes[i].height;

                string outputPath = $"output_{i}.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
                {
                    // Create graphics object
                    Graphics graphics = new Graphics(canvas);

                    // Determine centered square dimensions
                    int squareSize = Math.Min(width, height);
                    int offsetX = (width - squareSize) / 2;
                    int offsetY = (height - squareSize) / 2;

                    // Fill centered square with a solid color
                    using (SolidBrush brush = new SolidBrush(Color.Blue))
                    {
                        graphics.FillRectangle(brush, new Rectangle(offsetX, offsetY, squareSize, squareSize));
                    }

                    // Save the bound image
                    canvas.Save();
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
 * 1. When you need to generate a set of BMP thumbnails of varying dimensions with a consistent centered logo or color block for UI placeholders.
 * 2. When automating the creation of test images for a graphics pipeline that requires different canvas sizes but a fixed central element.
 * 3. When producing batch assets for a game where each level uses a different resolution background but the same centered icon.
 * 4. When preparing sample BMP files for documentation or tutorials that demonstrate drawing shapes with Aspose.Imaging in C#.
 * 5. When building a server‑side service that creates custom‑sized BMP badges with a centered colored square for user profiles.
 */
