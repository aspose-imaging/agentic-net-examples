// HOW-TO: Crop 10 Pixels From Top Left Of EMF Image In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        const string inputPath = "input.emf";
        const string outputPath = "output\\cropped.emf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                // Remove 10 pixels from the left and top borders
                image.Crop(10, 0, 10, 0);
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
 * 1. When you need to remove unwanted margins from a vector EMF logo before embedding it in a report generated with C#.
 * 2. When preparing EMF diagrams for printing and you must trim a 10‑pixel border to align them with page layout constraints.
 * 3. When converting legacy EMF files to other formats and want to ensure the cropped image fits within a UI component without extra whitespace.
 * 4. When automating batch processing of EMF assets in a .NET application and need to standardize the top‑left offset for all images.
 * 5. When integrating Aspose.Imaging into a C# workflow to clean up scanned EMF drawings by cropping the top and left edges programmatically.
 */
