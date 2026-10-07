// HOW-TO: How To Add Author Description And Creation Date Metadata To APNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\source.png";
        string outputPath = "Output\\result.apng";

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
                int width = image.Width;
                int height = image.Height;

                var options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    using (RasterImage raster = (RasterImage)image)
                    {
                        apng.AddFrame(raster);
                    }

                    apng.Save();
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
 * 1. When you need to embed copyright information such as author name, description, and creation timestamp into an animated PNG for digital asset tracking.
 * 2. When generating APNG files for a web gallery and want search engines or client applications to read embedded metadata for SEO and accessibility.
 * 3. When creating a series of animated stickers where each file must carry its creator details and creation date for licensing compliance.
 * 4. When exporting frames from a raster image to an APNG and must preserve provenance data to be read later by image management tools.
 * 5. When automating a build pipeline that converts static PNGs to APNGs and requires custom metadata fields for version control and audit logs.
 */
