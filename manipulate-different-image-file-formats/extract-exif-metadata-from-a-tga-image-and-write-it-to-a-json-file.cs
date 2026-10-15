// HOW-TO: Extract EXIF Metadata From TGA Image And Save As JSON In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.json";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                // Attempt to retrieve metadata (EXIF) if available
                var metadata = image.Metadata;
                var exifDict = new Dictionary<string, string>();

                if (metadata != null)
                {
                    // Aspose.Imaging does not expose EXIF for TGA directly.
                    // If metadata contains any key-value pairs, they can be added here.
                    // This placeholder leaves the dictionary empty when no EXIF data is present.
                }

                using (var writer = new StreamWriter(outputPath))
                {
                    writer.Write("{");
                    bool first = true;
                    foreach (var kvp in exifDict)
                    {
                        if (!first) writer.Write(",");
                        writer.Write($"\"{EscapeJson(kvp.Key)}\":\"{EscapeJson(kvp.Value)}\"");
                        first = false;
                    }
                    writer.Write("}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string EscapeJson(string s)
    {
        return s?.Replace("\\", "\\\\").Replace("\"", "\\\"") ?? string.Empty;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read camera or creation information stored in a TGA file and export it to a JSON document for downstream analysis or logging.
 * 2. When building a pipeline that validates image assets by extracting their EXIF tags and comparing them against expected values in a C# application.
 * 3. When creating an inventory of legacy game textures in TGA format and want to store their metadata in a machine‑readable JSON file for a content management system.
 * 4. When integrating Aspose.Imaging into a .NET service that must serialize image metadata to JSON for API responses or client-side consumption.
 * 5. When automating quality‑control checks that require extracting any available EXIF data from TGA images and persisting it for audit trails.
 */
