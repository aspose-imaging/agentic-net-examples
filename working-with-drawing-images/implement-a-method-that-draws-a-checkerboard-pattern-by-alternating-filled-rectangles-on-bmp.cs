// HOW-TO: Create a Checkerboard BMP Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "output/checkerboard.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                int boardSize = 8;
                int squareSize = 50;
                int width = boardSize * squareSize;
                int height = boardSize * squareSize;

                BmpOptions bmpOptions = new BmpOptions();

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    for (int y = 0; y < boardSize; y++)
                    {
                        for (int x = 0; x < boardSize; x++)
                        {
                            Aspose.Imaging.Color fillColor = ((x + y) % 2 == 0) ? Aspose.Imaging.Color.White : Aspose.Imaging.Color.Black;
                            using (SolidBrush brush = new SolidBrush(fillColor))
                            {
                                graphics.FillRectangle(brush, x * squareSize, y * squareSize, squareSize, squareSize);
                            }
                        }
                    }

                    image.Save(outputPath, bmpOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a black‑and‑white checkerboard background for game boards or UI testing directly in C#.
 * 2. When you want to programmatically create a BMP file for printing calibration patterns without using external image editors.
 * 3. When you need to produce a tiled pattern image for texture mapping in a graphics engine using Aspose.Imaging.
 * 4. When you are building automated tests that require a known pixel layout to verify image processing algorithms.
 * 5. When you must generate a simple high‑contrast pattern for computer vision training data in .NET.
 */
