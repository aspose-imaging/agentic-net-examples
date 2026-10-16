// HOW-TO: Convert JPEG to PNG with Aspose.Imaging and Safe Disposal in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Image image = null;
            try
            {
                image = Image.Load(inputPath);
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Conversion error: {ex.Message}");
            }
            finally
            {
                if (image != null)
                {
                    image.Dispose();
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
 * 1. When a web service needs to transform uploaded JPEG photos to PNG format while guaranteeing that image resources are released even if conversion fails.
 * 2. When a desktop application processes user‑selected images and must create an output folder automatically before saving the PNG version.
 * 3. When a batch job validates the existence of source files and logs meaningful errors without crashing the whole process.
 * 4. When a background worker converts images and wants to prevent memory leaks by disposing the Image object in a finally block.
 * 5. When an automated pipeline integrates Aspose.Imaging to convert images and requires robust error handling to continue processing other files.
 */
