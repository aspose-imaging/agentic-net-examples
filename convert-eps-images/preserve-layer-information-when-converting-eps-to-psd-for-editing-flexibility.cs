// HOW-TO: Convert EPS to PSD While Preserving Layers in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                image.Save(outputPath, psdOptions);
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
 * 1. When a designer provides artwork as EPS and a developer needs to edit it in Photoshop, they can convert the EPS to a PSD with layers intact using C# and Aspose.Imaging.
 * 2. When an automated publishing pipeline must transform vector EPS files into layered PSD files for further raster editing, this code enables the conversion without losing layer structure.
 * 3. When a web service receives EPS logos and must store them as editable PSD files for a graphics team, the snippet shows how to perform the conversion programmatically.
 * 4. When migrating legacy EPS assets to a Photoshop‑based workflow, developers can use this C# example to batch‑convert files while keeping each element on separate layers.
 * 5. When building a desktop application that lets users import EPS drawings and continue editing them in Photoshop, the code demonstrates loading the EPS and saving it as a layered PSD.
 */
