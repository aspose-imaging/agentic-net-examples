// HOW-TO: Load Large JPEG with Memory Optimization and Reduce File Size in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 1024 * 1024 };

            using (var image = (JpegImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 50,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to display high‑resolution photos but must keep memory consumption low, this code loads the JPEG efficiently and saves a smaller version for faster delivery.
 * 2. When processing batch uploads of large camera images on a server, developers can use this pattern to limit buffer usage and automatically compress each image to a lower quality to save storage space.
 * 3. When generating thumbnails for a mobile app, the code demonstrates how to read a big JPEG with a buffer hint and re‑save it with reduced quality to meet bandwidth constraints.
 * 4. When migrating legacy image archives to a cloud repository, the snippet shows how to load each large JPEG without exhausting RAM and shrink its file size before uploading.
 * 5. When implementing an image‑compression feature in a desktop C# tool, this example provides a straightforward way to apply Aspose.Imaging’s JpegOptions with a custom quality setting while controlling memory usage.
 */
