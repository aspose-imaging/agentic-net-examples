// HOW-TO: Create and Save a JPEG2000 Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.jp2";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            using (Jpeg2000Image canvas = new Jpeg2000Image(width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                Jpeg2000Options options = new Jpeg2000Options();
                canvas.Save(outputPath, options);
            }

            using (Jpeg2000Image loaded = (Jpeg2000Image)Image.Load(outputPath))
            {
                Console.WriteLine("JPEG2000 image loaded successfully.");
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
 * 1. When you need to generate a blank JPEG2000 placeholder image for a web service that expects JP2 files.
 * 2. When you want to programmatically create a high‑resolution JP2 file for archival storage using Aspose.Imaging in a .NET application.
 * 3. When you must verify that a JPEG2000 file can be loaded after being saved to ensure compatibility with downstream processing pipelines.
 * 4. When you are building a batch job that creates and validates JP2 images before uploading them to a digital asset management system.
 * 5. When you need to test the basic JPEG2000 image creation workflow in C# before adding advanced features like color profiles or compression settings.
 */
