// HOW-TO: Unit Test Mask Inversion for White and Black PNG Masks in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string inputWhitePath = "input/whiteMask.png";
            string inputBlackPath = "input/blackMask.png";
            string outputWhiteInvertedPath = "output/invertedWhite.png";
            string outputBlackInvertedPath = "output/invertedBlack.png";

            // Ensure input directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(inputWhitePath));
            Directory.CreateDirectory(Path.GetDirectoryName(inputBlackPath));

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputWhiteInvertedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBlackInvertedPath));

            // Create a white mask image (100x100)
            using (RasterImage whiteImg = (RasterImage)Image.Create(
                new PngOptions { ColorType = PngColorType.TruecolorWithAlpha, Source = new FileCreateSource(inputWhitePath, false) },
                100, 100))
            {
                int[] whitePixels = new int[100 * 100];
                for (int i = 0; i < whitePixels.Length; i++) whitePixels[i] = unchecked((int)0xFFFFFFFF); // ARGB white
                whiteImg.SaveArgb32Pixels(new Rectangle(0, 0, 100, 100), whitePixels);
                whiteImg.Save();
            }

            // Create a black mask image (100x100)
            using (RasterImage blackImg = (RasterImage)Image.Create(
                new PngOptions { ColorType = PngColorType.TruecolorWithAlpha, Source = new FileCreateSource(inputBlackPath, false) },
                100, 100))
            {
                int[] blackPixels = new int[100 * 100];
                for (int i = 0; i < blackPixels.Length; i++) blackPixels[i] = 0; // ARGB black
                blackImg.SaveArgb32Pixels(new Rectangle(0, 0, 100, 100), blackPixels);
                blackImg.Save();
            }

            // Verify input files exist
            if (!File.Exists(inputWhitePath))
            {
                Console.Error.WriteLine($"File not found: {inputWhitePath}");
                return;
            }
            if (!File.Exists(inputBlackPath))
            {
                Console.Error.WriteLine($"File not found: {inputBlackPath}");
                return;
            }

            // Process white mask inversion
            using (RasterImage imgWhite = (RasterImage)Image.Load(inputWhitePath))
            {
                MagicWandTool.Select(imgWhite, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();

                imgWhite.Save(outputWhiteInvertedPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                int[] resultWhite = imgWhite.LoadArgb32Pixels(new Rectangle(0, 0, imgWhite.Width, imgWhite.Height));
                bool isBlack = true;
                foreach (int pixel in resultWhite)
                {
                    if (pixel != 0)
                    {
                        isBlack = false;
                        break;
                    }
                }
                Console.WriteLine(isBlack ? "White mask inversion passed" : "White mask inversion failed");
            }

            // Process black mask inversion
            using (RasterImage imgBlack = (RasterImage)Image.Load(inputBlackPath))
            {
                MagicWandTool.Select(imgBlack, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();

                imgBlack.Save(outputBlackInvertedPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                int[] resultBlack = imgBlack.LoadArgb32Pixels(new Rectangle(0, 0, imgBlack.Width, imgBlack.Height));
                bool isWhite = true;
                foreach (int pixel in resultBlack)
                {
                    if (pixel != unchecked((int)0xFFFFFFFF))
                    {
                        isWhite = false;
                        break;
                    }
                }
                Console.WriteLine(isWhite ? "Black mask inversion passed" : "Black mask inversion failed");
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
 * 1. When you need to verify that a binary image mask correctly flips from opaque to transparent using Aspose.Imaging unit tests in C#.
 * 2. When automating quality checks for generated PNG masks that start fully white or fully black before applying image compositing.
 * 3. When ensuring that mask inversion logic works for both alpha‑filled and empty masks in a graphics pipeline that uses Aspose.Imaging.
 * 4. When creating CI/CD pipelines that run C# tests to detect regressions in mask processing for PNG files with truecolor with alpha.
 * 5. When debugging image‑mask transformations in a .NET application that relies on accurate inversion of white and black mask layers.
 */
