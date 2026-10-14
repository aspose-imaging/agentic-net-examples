// HOW-TO: Save PNG Image to MemoryStream for Network Transmission in C# (Aspose.Imaging for .NET)
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

namespace ImageConversionExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input/compressed_image.png";
            string outputPath = "output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        image.Save(memoryStream, pngOptions);

                        // Reset stream position if needed for further processing
                        memoryStream.Position = 0;

                        // Example: write the PNG bytes to a file (optional)
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());

                        // The memoryStream now contains the PNG image ready for network transmission
                        // byte[] pngData = memoryStream.ToArray();
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
 * 1. When you need to convert a local PNG file into a byte array for sending it over a REST API without writing intermediate files.
 * 2. When you want to embed a PNG image into a message queue payload such as RabbitMQ or Azure Service Bus.
 * 3. When you are building a real‑time streaming service that streams PNG frames directly from memory to a client application.
 * 4. When you must pass a PNG image to another .NET component that expects a Stream, such as an email attachment or a cloud storage SDK.
 * 5. When you are implementing a microservice that receives an image, processes it with Aspose.Imaging, and returns the result as a MemoryStream to the caller.
 */
