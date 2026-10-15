// HOW-TO: Extract 64x64 PNG Frames From TGA Sprite Sheet In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "spritesheet.tga");
            string outputDirectory = Path.Combine("Output");

            Directory.CreateDirectory(outputDirectory);

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.Image sheetImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int sheetWidth = sheetImage.Width;
                int sheetHeight = sheetImage.Height;
                int tileSize = 64;
                int frameIndex = 0;

                for (int y = 0; y < sheetHeight; y += tileSize)
                {
                    for (int x = 0; x < sheetWidth; x += tileSize)
                    {
                        int tileWidth = Math.Min(tileSize, sheetWidth - x);
                        int tileHeight = Math.Min(tileSize, sheetHeight - y);

                        using (Aspose.Imaging.Image tileImage = Aspose.Imaging.Image.Load(inputPath))
                        {
                            Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(x, y, tileWidth, tileHeight);
                            ((Aspose.Imaging.RasterImage)tileImage).Crop(rect);

                            string outputPath = Path.Combine(outputDirectory, $"frame_{frameIndex:D4}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            using (var pngOptions = new PngOptions())
                            {
                                tileImage.Save(outputPath, pngOptions);
                            }

                            frameIndex++;
                        }
                    }
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
 * 1. When you need to break a large TGA sprite sheet into individual 64‑pixel PNG images for game animation.
 * 2. When you want to automate the extraction of sprite frames for a 2D game engine that only supports PNG textures.
 * 3. When you have legacy TGA assets and must convert each tile to PNG to integrate with modern UI frameworks.
 * 4. When you need to generate a sequence of PNG files from a tiled sprite sheet for use in video editing or GIF creation.
 * 5. When you are building a batch processing tool that slices any sized sprite sheet into fixed‑size PNG tiles for texture atlases.
 */
