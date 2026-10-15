// HOW-TO: Flip BMP Image Horizontally and Vertically Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

namespace ImageProcessing
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPathHorizontal = "output\\horizontal.bmp";
                string outputPathVertical = "output\\vertical.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPathHorizontal));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathVertical));

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    image.Save(outputPathHorizontal);
                }

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    image.Save(outputPathVertical);
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
 * 1. When creating mirrored UI icons for left‑to‑right and right‑to‑left layouts, you can flip a BMP file to generate the required assets automatically.
 * 2. When a game needs a sprite’s opposite orientation for character movement, this code produces horizontal and vertical BMP copies without manual editing.
 * 3. When preparing print‑ready graphics that must be reversed for embossing or stamping, the RotateFlip operation quickly generates the flipped versions.
 * 4. When a legacy system stores textures as BMP and you must provide both normal and flipped versions for a responsive design, the example shows how to do it in C#.
 * 5. When automating batch processing of UI assets, you can use this snippet to create mirrored BMP files for theme variations or accessibility support.
 */
