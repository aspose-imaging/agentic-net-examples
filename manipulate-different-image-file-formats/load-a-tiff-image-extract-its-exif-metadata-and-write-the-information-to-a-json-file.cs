// HOW-TO: Extract EXIF Metadata From TIFF and Save As JSON In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
        string outputPath = "exif.json";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var tiff = image as Aspose.Imaging.FileFormats.Tiff.TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The file is not a TIFF image.");
                    return;
                }

                var exif = tiff.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found.");
                    return;
                }

                var dict = new Dictionary<string, object>();
                var type = exif.GetType();
                foreach (var prop in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    var value = prop.GetValue(exif);
                    if (value != null)
                    {
                        dict[prop.Name] = value;
                    }
                }

                string json = System.Text.Json.JsonSerializer.Serialize(dict, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
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
 * 1. When you need to read camera settings stored in a TIFF file and export them for analysis or reporting.
 * 2. When a batch job must collect EXIF tags from scanned documents and store them in a machine‑readable JSON format.
 * 3. When integrating image assets into a digital asset management system that requires metadata to be supplied as JSON.
 * 4. When debugging or auditing image provenance by programmatically comparing EXIF values across multiple TIFF files.
 * 5. When creating a lightweight metadata cache for a web service that serves TIFF images but only needs the EXIF data in JSON.
 */
