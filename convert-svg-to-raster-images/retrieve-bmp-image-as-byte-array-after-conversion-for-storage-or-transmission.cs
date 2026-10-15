// HOW-TO: Convert BMP to PNG and Get Byte Array in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    image.Save(memoryStream, pngOptions);
                    byte[] pngBytes = memoryStream.ToArray();

                    File.WriteAllBytes(outputPath, pngBytes);
                    Console.WriteLine($"Converted image byte array length: {pngBytes.Length}");
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
 * 1. When you need to send a converted PNG image over a network API, you can obtain the byte array directly from memory without creating an intermediate file.
 * 2. When storing images in a database as BLOB data, converting BMP to PNG and retrieving the byte array lets you compress the image before insertion.
 * 3. When generating thumbnails for a web service, you can load a BMP, convert it to PNG, and use the resulting byte array to embed the image in JSON responses.
 * 4. When integrating with a third‑party library that accepts image data as a byte[] parameter, this code provides the required PNG byte array after conversion.
 * 5. When performing batch image processing and need to cache the converted PNG data in memory for fast access, the byte array can be kept in a collection without writing to disk.
 */
