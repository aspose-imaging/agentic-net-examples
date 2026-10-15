// HOW-TO: Remove Background from EMF File Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output\\output.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                VectorImage vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    var settings = new RemoveBackgroundSettings();
                    vectorImage.RemoveBackground(settings);
                }

                var emfOptions = new EmfOptions();
                image.Save(outputPath, emfOptions);
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
 * 1. When you need to clean up scanned vector graphics by eliminating unwanted white margins from EMF files before embedding them in a report.
 * 2. When an application must programmatically replace a logo’s background color in EMF icons to match a custom UI theme.
 * 3. When generating printable documents, you may want to strip out background shapes from EMF diagrams to reduce file size and improve rendering speed.
 * 4. When converting legacy EMF assets for a web portal, removing the background ensures transparent overlays display correctly on different page backgrounds.
 * 5. When automating batch processing of engineering drawings, you can use this code to delete background layers from each EMF file to meet corporate branding guidelines.
 */
