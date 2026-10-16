// HOW-TO: Convert ODG File To PNG In MemoryStream Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

namespace OdgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input path
                string inputPath = "input.odg";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the ODG file
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG options
                    var pngOptions = new PngOptions();

                    // Convert to PNG and write to a MemoryStream
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, pngOptions);

                        // Optionally, you can use the MemoryStream here.
                        // For demonstration, we output the size of the generated PNG.
                        Console.WriteLine($"PNG data size: {memoryStream.Length} bytes");
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
 * 1. When you need to generate a PNG thumbnail of an ODG diagram on the server without writing temporary files to disk.
 * 2. When a web service must return a converted PNG image directly from an uploaded ODG file as a byte array.
 * 3. When you are building a Windows application that stores converted PNG data in a database for later retrieval.
 * 4. When you want to stream a PNG version of an ODG document to a client browser in an ASP.NET response.
 * 5. When you need to validate the size of a PNG conversion of an ODG file before saving it to cloud storage.
 */
