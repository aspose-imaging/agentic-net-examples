// HOW-TO: Get Width and Height of EMF Image in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                Console.WriteLine($"Width: {width}, Height: {height}");
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
 * 1. When you need to display or validate the size of a vector EMF file before converting it to another format.
 * 2. When a reporting tool must calculate layout dimensions of an EMF diagram to fit it into a PDF page.
 * 3. When a batch process logs the dimensions of multiple EMF assets to generate a size inventory for asset management.
 * 4. When a web service validates uploaded EMF graphics by checking their width and height against allowed limits.
 * 5. When a desktop application shows image metadata to users, retrieving the EMF image’s width and height for UI display.
 */
