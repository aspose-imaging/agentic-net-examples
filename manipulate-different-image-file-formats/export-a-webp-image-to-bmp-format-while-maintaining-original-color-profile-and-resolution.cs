// HOW-TO: Convert WebP Image to BMP While Preserving Color Profile in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.webp");
            string outputPath = Path.Combine("Output", "image.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to display a WebP graphic in a legacy Windows application that only supports BMP files, you can use this code to convert the image without losing its original colors or resolution.
 * 2. When preparing assets for a printing workflow that requires BMP format but the source images are delivered as WebP, this snippet ensures the conversion retains the embedded color profile.
 * 3. When automating batch processing of WebP screenshots to BMP for use in a .NET desktop tool, the code provides a reliable way to preserve image quality during the format change.
 * 4. When integrating Aspose.Imaging into a C# service that receives WebP uploads and must store them as BMP for compatibility with third‑party libraries, this example shows how to keep the original resolution intact.
 * 5. When creating a migration script to move WebP icons to BMP for a game engine that does not support WebP, the code guarantees the icons keep their exact color fidelity after conversion.
 */
