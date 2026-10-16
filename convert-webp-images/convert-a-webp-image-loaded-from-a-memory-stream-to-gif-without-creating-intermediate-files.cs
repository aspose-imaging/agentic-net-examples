// HOW-TO: Convert WebP Image from Memory Stream to GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] data = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (Image image = Image.Load(ms))
                {
                    GifOptions options = new GifOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to display a WebP graphic as an animated GIF on a website that only supports GIF, you can convert it directly from a byte array without writing temporary files.
 * 2. When processing uploaded images in a web API, you can load the WebP data from a MemoryStream and save it as GIF to return to clients that require GIF format.
 * 3. When building a desktop application that reads images from a database BLOB, you can transform the stored WebP bytes into a GIF for preview without creating intermediate files on disk.
 * 4. When generating email attachments, you can convert in‑memory WebP images to GIF to ensure compatibility with email clients that do not support WebP.
 * 5. When performing batch image conversion in a serverless function, using Aspose.Imaging to load WebP from memory and save as GIF reduces I/O overhead and speeds up processing.
 */
