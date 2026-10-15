// HOW-TO: Convert TIFF to PNG and Get Byte Array in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversionApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.tiff";
                string outputPath = "output\\output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                byte[] pngBytes = ConvertTiffToPngByteArray(inputPath);
                File.WriteAllBytes(outputPath, pngBytes);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static byte[] ConvertTiffToPngByteArray(string inputPath)
        {
            using (Image image = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    image.Save(ms, pngOptions);
                    return ms.ToArray();
                }
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to load a multi‑page TIFF, convert it to a PNG and send the image over a web API without writing a temporary file.
 * 2. When an ASP.NET service must generate a PNG thumbnail from a TIFF stored in a database and return it as a byte[] to the client.
 * 3. When you are building a batch job that reads TIFF files, converts them to PNG in memory and stores the resulting byte arrays in a NoSQL document store.
 * 4. When you want to embed a converted PNG into an email attachment directly from memory to avoid disk I/O.
 * 5. When a cloud function processes uploaded TIFF images, converts them to PNG and streams the byte array to another microservice for further analysis.
 */
