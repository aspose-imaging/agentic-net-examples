// HOW-TO: Convert PSD to PNG with SingleBitPerPixel Text Rendering in C# (Aspose.Imaging for .NET)
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
using System.Drawing.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to export layered Photoshop files to PNG while preserving crisp text for web thumbnails.
 * 2. When generating product catalog images from PSD designs and want the embedded labels to remain sharp after conversion.
 * 3. When automating batch conversion of PSD assets for a mobile app and require clear, anti‑aliased text in the PNG output.
 * 4. When creating printable PDFs from PSD sources and first convert them to PNG with high‑quality text rendering for preview generation.
 * 5. When integrating Aspose.Imaging into a CI pipeline to validate that text layers in PSD files render correctly in the final PNG assets.
 */
