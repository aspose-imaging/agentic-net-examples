// HOW-TO: Save JPEG As Grayscale PSD Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.jpg");
            string outputPath = Path.Combine("Output", "output.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PsdOptions options = new PsdOptions();
                options.ColorMode = ColorModes.Grayscale;
                image.Save(outputPath, options);
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
 * 1. When you need to convert color JPEG photos to monochrome PSD files for printing press workflows using C# and Aspose.Imaging.
 * 2. When you want to generate lightweight grayscale PSD assets for web design mockups without manual Photoshop editing.
 * 3. When an automated batch process must create PSD files with a specific grayscale color mode for archival storage of scanned documents.
 * 4. When a desktop application requires saving user‑uploaded images as PSD with grayscale mode to ensure consistent color handling across platforms.
 * 5. When integrating a C# service that prepares images for laser engraving, converting them to grayscale PSD to match the device’s input requirements.
 */
