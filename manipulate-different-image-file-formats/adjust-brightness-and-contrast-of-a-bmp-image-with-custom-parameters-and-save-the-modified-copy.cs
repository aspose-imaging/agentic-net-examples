// HOW-TO: Adjust Brightness and Contrast of a BMP Image in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\modified.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int brightness = 50; // custom brightness value between -255 and 255
            int contrast = 30;   // custom contrast value between -100 and 100

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.AdjustBrightness(brightness);
                image.AdjustContrast(contrast);
                image.Save(outputPath);
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
 * 1. When you need to enhance the visual clarity of scanned BMP documents before OCR by programmatically increasing brightness and contrast in a C# application.
 * 2. When a game developer wants to dynamically adjust the lighting of BMP texture assets at runtime using Aspose.Imaging to match different in‑game environments.
 * 3. When an automated batch‑processing service must normalize the exposure of user‑uploaded BMP photos for a web gallery, applying custom brightness and contrast settings before saving them.
 * 4. When a medical imaging system requires preprocessing of BMP X‑ray images to improve detail visibility by tweaking brightness and contrast via C# code.
 * 5. When a desktop utility needs to create a brighter, higher‑contrast copy of a BMP screenshot for presentation slides, preserving the original file unchanged.
 */
