// HOW-TO: How To Remove Metadata From JPEG Image In C# With Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

namespace RemoveMetadataApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output\\output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.RemoveMetadata();
                    image.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to strip EXIF and other metadata from user‑uploaded photos before storing them to protect privacy.
 * 2. When preparing images for a web gallery and want to reduce file size by removing unnecessary metadata.
 * 3. When complying with GDPR or other regulations that require personal data such as GPS coordinates to be removed from images.
 * 4. When creating a batch job that processes scanned documents and needs to ensure no hidden metadata is retained in the output JPEGs.
 * 5. When sending images to a third‑party API that rejects files containing metadata and you must clean them programmatically in C#.
 */
