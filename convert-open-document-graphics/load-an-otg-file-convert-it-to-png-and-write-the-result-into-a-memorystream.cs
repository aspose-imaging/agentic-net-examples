// HOW-TO: Convert OTG Image To PNG And Store In MemoryStream Using C# (Aspose.Imaging for .NET)
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

namespace OtgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.otg";
                string outputPath = "output.png";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load OTG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG options
                    PngOptions pngOptions = new PngOptions();

                    // Convert to PNG and write into a MemoryStream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, pngOptions);

                        // Optionally, write the PNG to disk
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());

                        // The MemoryStream now contains the PNG data
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
 * 1. When you need to display an OTG graphic on a web page that only supports PNG, you can convert it to PNG in memory before sending it to the client.
 * 2. When processing batch image conversions on a server, you can load each OTG file, convert it to PNG, and keep the result in a MemoryStream for further manipulation without creating temporary files.
 * 3. When integrating with an API that requires image data as a byte array, you can convert an OTG file to PNG and retrieve the bytes from the MemoryStream to include in the request.
 * 4. When generating thumbnails for OTG documents in a desktop application, converting to PNG in a MemoryStream allows you to quickly render the thumbnail without writing intermediate files.
 * 5. When storing converted images in a database or cloud storage, you can convert OTG to PNG and use the MemoryStream’s content to upload the image directly.
 */
