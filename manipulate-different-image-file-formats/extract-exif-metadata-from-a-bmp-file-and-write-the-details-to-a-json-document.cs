// HOW-TO: Extract BMP Image Dimensions and Save as JSON in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/metadata.json";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var exifData = new Dictionary<string, string>();

                // BMP format does not support EXIF; include basic image info instead
                exifData["Format"] = "BMP";
                exifData["Width"] = image.Width.ToString();
                exifData["Height"] = image.Height.ToString();

                string json = "{" + string.Join(",", exifData.Select(kv => $"\"{kv.Key}\":\"{kv.Value}\"")) + "}";

                File.WriteAllText(outputPath, json);
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
 * 1. When you need to log basic properties of BMP files, such as width and height, into a JSON file for downstream reporting or analytics.
 * 2. When a legacy system only provides BMP images and you must generate a lightweight metadata file for integration with a web service that consumes JSON.
 * 3. When you are building a batch process that validates image dimensions before converting BMPs to other formats, and you want to store the validation results in JSON.
 * 4. When you need to create an inventory of image assets by extracting format and size information from BMP files without relying on EXIF data.
 * 5. When you are troubleshooting image handling issues and want to quickly export BMP image details to JSON for sharing with support or logging purposes.
 */
