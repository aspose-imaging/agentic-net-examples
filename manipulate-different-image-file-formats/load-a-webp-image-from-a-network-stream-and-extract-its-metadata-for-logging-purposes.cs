// HOW-TO: Read WebP Image Metadata and Properties in C# With Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "image.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                Console.WriteLine($"Format: {image.FileFormat}");
                Console.WriteLine($"Width: {image.Width}");
                Console.WriteLine($"Height: {image.Height}");
                Console.WriteLine($"BitsPerPixel: {image.BitsPerPixel}");

                var metadata = image.Metadata;
                if (metadata != null)
                {
                    Console.WriteLine($"Metadata: {metadata}");
                }

                WebPImage webp = image as WebPImage;
                if (webp != null)
                {
                    Console.WriteLine("WebPImage loaded successfully.");
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
 * 1. When you need to log basic information such as format, dimensions, and color depth of a WebP file before processing it further.
 * 2. When you want to verify that a downloaded WebP image can be successfully parsed by Aspose.Imaging in a C# application.
 * 3. When you need to extract and store the embedded metadata of a WebP image for auditing or analytics.
 * 4. When you are building a server‑side service that validates incoming WebP uploads by checking their properties and metadata.
 * 5. When you need to confirm the image type at runtime (e.g., cast to WebPImage) to apply WebP‑specific operations in .NET.
 */
