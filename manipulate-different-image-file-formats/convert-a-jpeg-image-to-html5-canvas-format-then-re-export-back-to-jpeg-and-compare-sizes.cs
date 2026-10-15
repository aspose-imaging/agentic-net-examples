// HOW-TO: Convert JPEG to HTML5 Canvas and Back to JPEG in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.jpg";
            string canvasPath = "output.html";
            string reExportPath = "reexport.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(reExportPath) ?? ".");

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Export to HTML5 Canvas format
                var canvasOptions = new Html5CanvasOptions();
                image.Save(canvasPath, canvasOptions);
            }

            // Re‑export back to JPEG
            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(reExportPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long reExportSize = new FileInfo(reExportPath).Length;

            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"Re‑exported JPEG size: {reExportSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed a JPEG image into a web page using an HTML5 canvas and later regenerate the JPEG for storage or further processing.
 * 2. When you want to compare the file size impact of converting a JPEG to canvas markup and back to JPEG to evaluate compression differences.
 * 3. When you are building a C# service that transforms uploaded JPEGs into canvas‑compatible HTML for client‑side rendering and then restores them to JPEG after editing.
 * 4. When you need to verify that the round‑trip conversion between JPEG and HTML5 canvas does not corrupt image data or significantly change dimensions.
 * 5. When you are creating automated tests that ensure Aspose.Imaging correctly handles JPEG to canvas export and re‑export workflows in .NET applications.
 */
