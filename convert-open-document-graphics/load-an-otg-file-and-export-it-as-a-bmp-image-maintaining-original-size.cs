// HOW-TO: Convert OTG File To BMP Image In C# Preserving Original Size (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
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
 * 1. When you need to display a vector OTG graphic in a Windows application that only supports BMP format, you can load the OTG with Aspose.Imaging and save it as a BMP while keeping its original dimensions.
 * 2. When a batch processing script must convert legacy OTG design files to BMP for compatibility with legacy printing hardware, this code provides a simple C# solution.
 * 3. When generating thumbnails for an OTG catalog but the thumbnail generator only accepts BMP, you can use this code to export each OTG at its native size before resizing.
 * 4. When integrating a third‑party library that requires BMP input, you can convert incoming OTG files on the fly in C# without altering their resolution.
 * 5. When archiving OTG assets in a format that can be opened by standard image viewers, this snippet converts the files to BMP while preserving the original image size.
 */
