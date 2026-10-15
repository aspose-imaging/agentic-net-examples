// HOW-TO: Interactively Adjust Feather Radius and Preview Mask with Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            while (true)
            {
                Console.Write("Enter feather radius (or 'exit' to quit): ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line) || line.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (!int.TryParse(line, out int radius) || radius < 0)
                {
                    Console.WriteLine("Invalid radius. Please enter a non‑negative integer.");
                    continue;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                        .GetFeathered(new FeatheringSettings() { Size = radius })
                        .Apply();

                    string previewPath = Path.Combine(outputDirectory, $"preview_{radius}.png");
                    image.Save(previewPath, new PngOptions());
                    Console.WriteLine($"Preview saved to: {previewPath}");
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
 * 1. When you need to let users fine‑tune the softness of a selection edge and see the result instantly for photo editing tools.
 * 2. When building a desktop application that creates masks for background removal and requires real‑time preview of different feather sizes.
 * 3. When automating batch processing but want to test the optimal feather radius on a sample image before applying it to the whole set.
 * 4. When integrating Aspose.Imaging into a UI that lets designers experiment with mask feathering without writing separate scripts.
 * 5. When developing a command‑line utility for graphic designers to quickly generate PNG previews of feathered selections at various radii.
 */
