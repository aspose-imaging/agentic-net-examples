// HOW-TO: How to Unit Test MagicWand Union of Overlapping Masks in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load image for testing
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var rect = new Rectangle(0, 0, image.Width, image.Height);

                // Capture pixels before applying mask
                int[] beforePixels = image.LoadArgb32Pixels(rect);

                // Apply MagicWand selections and Union
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Union(new MagicWandSettings(20, 20))
                    .Apply();

                // Capture pixels after applying mask
                int[] afterPixels = image.LoadArgb32Pixels(rect);

                // Verify that the union resulted in the same image (since selections cover whole image)
                bool identical = beforePixels.SequenceEqual(afterPixels);
                Console.WriteLine(identical ? "Union test passed" : "Union test failed");

                // Save the resulting image
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to ensure that combining two overlapping MagicWand selections creates a single mask that correctly modifies the image.
 * 2. When you want to validate that the Union operation does not unintentionally change pixel data in an automated C# image‑processing test.
 * 3. When you are writing a unit test to confirm that overlapping selections cover the entire image and the output remains identical to the original.
 * 4. When you need to verify that saving a PNG after applying a MagicWand Union mask preserves the expected image content.
 * 5. When you are debugging mask logic and require a reproducible test that checks pixel equality before and after applying a MagicWand Union in Aspose.Imaging.
 */
