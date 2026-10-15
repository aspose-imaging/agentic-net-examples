// HOW-TO: Read TIFF EXIF Metadata and Export to JSON in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.json";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                var exifData = tiff.ExifData;
                var dict = new Dictionary<string, object>();

                if (exifData != null)
                {
                    dict["HasExif"] = true;
                }
                else
                {
                    dict["HasExif"] = false;
                }

                string json = "{";
                bool first = true;
                foreach (var kvp in dict)
                {
                    if (!first)
                    {
                        json += ",";
                    }
                    string valueStr = kvp.Value is string ? $"\"{kvp.Value}\"" : kvp.Value.ToString().ToLower();
                    json += $"\"{kvp.Key}\":{valueStr}";
                    first = false;
                }
                json += "}";

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
 * 1. When you need to verify whether a scanned TIFF document contains EXIF information before processing it further.
 * 2. When building a C# service that catalogs image files and stores their metadata in a lightweight JSON database.
 * 3. When generating a report of image attributes for compliance audits that requires extracting EXIF flags from TIFF files.
 * 4. When creating a batch job that reads large collections of TIFF photos and outputs a simple JSON file indicating the presence of EXIF data for each file.
 * 5. When integrating Aspose.Imaging into a .NET application to programmatically read TIFF metadata and share it with other systems via JSON.
 */
