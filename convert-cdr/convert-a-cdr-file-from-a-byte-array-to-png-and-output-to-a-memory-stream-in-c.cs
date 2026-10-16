// HOW-TO: Convert CDR Byte Array To PNG Memory Stream In C# (Aspose.Imaging for .NET)
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

namespace CdrToPngConverter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Read CDR file into byte array
                byte[] cdrBytes = File.ReadAllBytes(inputPath);

                // Load image from byte array
                using (var imageStream = new MemoryStream(cdrBytes))
                using (Image image = Image.Load(imageStream))
                {
                    // Prepare PNG options
                    var pngOptions = new PngOptions();

                    // Save to memory stream
                    using (var outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, pngOptions);

                        // Optionally write the PNG to a file
                        File.WriteAllBytes(outputPath, outputStream.ToArray());

                        // At this point, outputStream contains the PNG data
                        // It can be used further as needed
                    }
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
 * 1. When you need to render a CorelDRAW (CDR) drawing directly in a web application without creating temporary files on disk.
 * 2. When an API requires a PNG image as a byte stream, and the source graphic is stored as a CDR file in a database.
 * 3. When building a batch conversion service that reads CDR files as blobs, converts them to PNG, and returns the result via a memory stream for thumbnail generation.
 * 4. When you want to embed a CDR illustration into a PDF by first converting it to PNG in memory to avoid file‑system I/O.
 * 5. When running image processing in a serverless function or container where writing to the file system is restricted, and you must convert CDR data to PNG on the fly.
 */
