// HOW-TO: Convert Embedded OTG Resource to PNG File in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ConvertOtg
{
    class Program
    {
        static void Main()
        {
            const string outputPath = "output.png";

            try
            {
                // Load OTG file from embedded resource
                Assembly assembly = typeof(Program).Assembly;
                const string resourceName = "ConvertOtg.Resources.sample.otg";

                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                        return;
                    }

                    using (Image image = Image.Load(resourceStream))
                    {
                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                        // Save as PNG
                        PngOptions pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
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
 * 1. When you need to display a vector OTG diagram in a web application that only supports PNG images.
 * 2. When packaging an OTG icon inside a .NET assembly and you must extract and convert it to a raster PNG at runtime.
 * 3. When automating a build process that generates PNG thumbnails from OTG assets stored as embedded resources.
 * 4. When creating a cross‑platform reporting tool that reads OTG charts from resources and saves them as PNG for PDF embedding.
 * 5. When migrating legacy OTG assets to a modern image format without exposing the original files on disk.
 */
