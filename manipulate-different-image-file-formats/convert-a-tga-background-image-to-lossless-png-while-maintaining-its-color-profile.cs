// HOW-TO: Convert TGA Background Image to Lossless PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.tga";
        string outputPath = "Output\\image.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                tgaImage.Save(outputPath, options);
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
 * 1. When you need to prepare game textures stored as TGA files for web delivery without losing color fidelity, you can convert them to lossless PNG using Aspose.Imaging in C#.
 * 2. When archiving legacy graphics from a design pipeline, converting TGA background images to PNG preserves the original color profile while reducing file size.
 * 3. When a desktop application must display TGA assets on platforms that only support PNG, this code enables seamless runtime conversion in C#.
 * 4. When automating a batch process that ingests TGA screenshots and stores them as PNG for further analysis, the snippet ensures lossless output and maintains accurate colors.
 * 5. When integrating a content management system that receives TGA uploads, converting them to PNG on the server guarantees compatibility with browsers and retains the original color information.
 */
